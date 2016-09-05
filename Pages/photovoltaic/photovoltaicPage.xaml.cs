using SolstatProjectUI.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bytescout.Spreadsheet;
using SolstatProject.Models;
using Microsoft.Win32;
using FirstFloor.ModernUI.Windows.Controls;

namespace SolstatProjectUI.Pages.photovoltaic
{
    /// <summary>
    /// Interaction logic for photovoltaicPage.xaml
    /// </summary>
    public partial class photovoltaicPage : UserControl
    {
        public static Dictionary<String, Dictionary<String, String>> photovoltaicData { get; set; }
        public photovoltaicPage()
        {
            InitializeComponent();
            photovoltaicData = new Dictionary<string, Dictionary<String, String>>();
            fillPanels();
        }
        //TAB 2 PHOTOVOLTAIC
        private void mainComponentListPhoto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainPhotoComponent photoComp = (MainPhotoComponent)mainComponentListPhoto.SelectedItem;
            try
            {
                fillPhotoSecondaryComponentsList(photoComp.id);
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un error con la Base de datos. Tipo de error: " + error.GetType().ToString(), "¡Error!", MessageBoxButton.OK);
            }
        }

        public void fillPhotoSecondaryComponentsList(int panelID)
        {
            secondaryComponentListPhoto.Items.Clear();
            DataModel phSecondaryComponent = new DataModel();
            var query = from photoInfo in phSecondaryComponent.photosecondarycomponents where photoInfo.panelID == panelID orderby photoInfo.models select photoInfo;
            var panelName = from panelInfo in phSecondaryComponent.photocomponents where panelInfo.id == panelID select panelInfo.panels;
            foreach (var photoResult in query.ToList())
            {
                secondaryComponentListPhoto.Items.Add(new SecondaryPhotoComponents() { id = int.Parse(photoResult.id.ToString()), model = photoResult.models.ToString(), inverter = photoResult.inverter.ToString(), regulator = photoResult.regulator.ToString(), batery = photoResult.batery.ToString(), bidirectional_meter = photoResult.C_bidirectional_meter.ToString(), monitoring_system = photoResult.monitoring_system.ToString(), panelName = panelName.First<string>() });
            }
            phSecondaryComponent.Dispose();
        }

        private void photoUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Spreadsheet document = new Spreadsheet();
                document.LoadFromFile(System.IO.Path.GetFullPath(showDialogAndGetFilePath()));
                Worksheet workSheet = document.Workbook.Worksheets.ByName("Components");
                int panelID = 0;
                string models, inversor, regulator, batery, bidirectional_meter, monitoring_system;
                DataModel context = new DataModel();
                for (int i = 2; i < workSheet.UsedRangeRowMax; i++)
                {
                    if (!String.IsNullOrEmpty(workSheet.Cell("A" + i).ToString()))
                    {
                        panelID = insertPanelToDB(workSheet.Cell("A" + i));
                        models = (!String.IsNullOrEmpty(workSheet.Cell("B" + i).ToString())) ? workSheet.Cell("B" + i).ToString() : " ";
                        inversor = (!String.IsNullOrEmpty(workSheet.Cell("C" + i).ToString())) ? workSheet.Cell("C" + i).ToString() : " ";
                        regulator = (!String.IsNullOrEmpty(workSheet.Cell("D" + i).ToString())) ? workSheet.Cell("D" + i).ToString() : " ";
                        batery = (!String.IsNullOrEmpty(workSheet.Cell("E" + i).ToString())) ? workSheet.Cell("E" + i).ToString() : " ";
                        bidirectional_meter = (!String.IsNullOrEmpty(workSheet.Cell("F" + i).ToString())) ? workSheet.Cell("F" + i).ToString() : " ";
                        monitoring_system = (!String.IsNullOrEmpty(workSheet.Cell("G" + i).ToString())) ? workSheet.Cell("G" + i).ToString() : " ";
                        photosecondarycomponent secondThComp = new photosecondarycomponent
                        {
                            panelID = panelID,
                            models = models,
                            inverter = inversor,
                            regulator = regulator,
                            batery = batery,
                            C_bidirectional_meter = bidirectional_meter,
                            monitoring_system = monitoring_system
                        };
                        context.photosecondarycomponents.Add(secondThComp);
                        context.SaveChanges();
                    }
                }
                document.Close();
                mainComponentListPhoto.Items.Clear();
                secondaryComponentListPhoto.Items.Clear();
                outputListPhoto.Items.Clear();
            }
            catch(Exception ex)
            {
                ModernDialog.ShowMessage("Archivo no seleccionado. " + ex.GetType().ToString(), "¡Error de Archivo!", System.Windows.MessageBoxButton.OK);
            }
            fillPanels();

        }

        private void secondaryComponentListPhoto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SecondaryPhotoComponents selectedComponent = (SecondaryPhotoComponents)secondaryComponentListPhoto.SelectedItem;
            outputListPhoto.Items.Add(new SecondaryPhotoComponents() { id = selectedComponent.id, panelName = selectedComponent.panelName, model = selectedComponent.model });
            //outputListPhoto.Items.
            fillDictionary();
        }

        private void fillDictionary()
        {
            photovoltaicData.Clear();
            Dictionary<String, String> componentData = new Dictionary<String, String>();
            foreach (SecondaryPhotoComponents component in outputListPhoto.Items)
            {
                componentData.Add("panelName", component.panelName.ToString());
                componentData.Add("model", component.model.ToString());
                componentData.Add("monitoring_system", component.monitoring_system.ToString());
                componentData.Add("regulator", component.regulator.ToString());
                componentData.Add("inverter", component.inverter.ToString());
                //componentData.Add("price", component.inverter.ToString());
                photovoltaicData.Add(component.id.ToString(), componentData);
            }
        }

        public int insertPanelToDB(Cell panelCell)
        {
            int panelID = 0;
            DataModel context = new DataModel();
            string panelName = panelCell.ToString();
            var panelExists = from panelInfo in context.photocomponents where panelInfo.panels == panelName select panelInfo.id;
            if (panelExists.Count() == 0)
            {
                photocomponent mainThComp = new photocomponent
                {
                    panels = panelName
                };
                context.photocomponents.Add(mainThComp);
                context.SaveChanges();
                panelExists = from panelInfo in context.photocomponents where panelInfo.panels == panelName select panelInfo.id;
                panelID = panelExists.First<int>();
            }
            else
            {
                panelID = panelExists.First<int>();
            }
            return panelID;
        }

        ////////////////////////////////////////

        //HELPER METHODS
        public string showDialogAndGetFilePath()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Selecciona el archivo Excel";
            op.Filter = "All Excel Excel Files| *.xls; *.xlsx; *.xlsm;";
            bool? myResult;
            myResult = op.ShowDialog();
            return op.FileName;
        }

        public void fillPanels()
        {
            try
            {
                DataModel photoComponentInfo = new DataModel();
                var query = from panelInfo in photoComponentInfo.photocomponents orderby panelInfo.panels select new { panelInfo.id, panelInfo.panels };
                foreach (var photoResult in query.ToList())
                {
                    mainComponentListPhoto.Items.Add(new MainPhotoComponent() { id = int.Parse(photoResult.id.ToString()), Panels = photoResult.panels.ToString() });
                }
                photoComponentInfo.Dispose();
            }
            catch(Exception exc)
            {
                ModernDialog.ShowMessage("Hubo un error con la base de datos. Tipo de error: " + exc.GetType().ToString(), "¡Error!", System.Windows.MessageBoxButton.OK);
            }
        }
        //////////////////////////////////////////
    }
}
