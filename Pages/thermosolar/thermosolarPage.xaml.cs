using Bytescout.Spreadsheet;
using FirstFloor.ModernUI.Windows.Controls;
using Microsoft.Win32;
using SolstatProject.Models;
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

namespace SolstatProjectUI.Pages.thermosolar
{
    /// <summary>
    /// Interaction logic for thermosolarPage.xaml
    /// </summary>
    public partial class thermosolarPage : UserControl
    {
        public thermosolarPage()
        {
            InitializeComponent();
            fillBrands();
        }

        //TAB 3 THERMO
        private void mainComponentListThermo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainThermoComponent thermoComp = (MainThermoComponent)mainComponentListThermo.SelectedItem;
            try
            {
                fillThermoSecondaryComponentsList(thermoComp.id);
            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un error con la Base de datos. Tipo de error: " + error.GetType().ToString(), "¡Error!", MessageBoxButton.OK);
            }
        }

        public void fillThermoSecondaryComponentsList(int brandID)
        {
            secondaryComponentListThermo.Items.Clear();
            DataModel thSecondaryComponent = new DataModel();
            var query = from thermoInfo in thSecondaryComponent.thermosecondarycomponents where thermoInfo.brandID == brandID orderby thermoInfo.components select thermoInfo;
            var brandName = from brandInfo in thSecondaryComponent.thermocomponents where brandInfo.id == brandID select brandInfo.brand;
            foreach (var thermoResult in query.ToList())
            {
                secondaryComponentListThermo.Items.Add(new SecondaryThermoComponents() { id = int.Parse(thermoResult.id.ToString()), component = thermoResult.components.ToString(), comments = thermoResult.comments.ToString(), efficiency = double.Parse(thermoResult.efficiency.ToString()), brandName = brandName.First<string>().ToString() });
            }
        }

        private void thermoBackBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void thermoUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Spreadsheet document = new Spreadsheet();
                document.LoadFromFile(System.IO.Path.GetFullPath(showDialogAndGetFilePath()));
                Worksheet workSheet = document.Workbook.Worksheets.ByName("Components");
                int brandID = 0;
                double efficiencyExcel;
                string componentsExcel = " ", commentsExcel = " ";
                DataModel context = new DataModel();
                for (int i = 2; i < workSheet.UsedRangeRowMax; i++)
                {
                    if (!String.IsNullOrEmpty(workSheet.Cell("A" + i).ToString()))
                    {
                        brandID = insertBrandToDB(workSheet.Cell("A" + i));
                        efficiencyExcel = (!String.IsNullOrEmpty(workSheet.Cell("B" + i).ToString())) ? double.Parse(workSheet.Cell("B" + i).ToString().Replace("%", " ")) : 0.00;
                        componentsExcel = (!String.IsNullOrEmpty(workSheet.Cell("C" + i).ToString())) ? workSheet.Cell("C" + i).ToString() : " ";
                        commentsExcel = (!String.IsNullOrEmpty(workSheet.Cell("C" + i).ToString())) ? workSheet.Cell("C" + i).ToString() : " ";
                        thermosecondarycomponent secondThComp = new thermosecondarycomponent
                        {
                            brandID = brandID,
                            comments = commentsExcel,
                            components = componentsExcel,
                            efficiency = efficiencyExcel
                        };
                        context.thermosecondarycomponents.Add(secondThComp);
                        context.SaveChanges();
                    }
                }
                document.Close();
                mainComponentListThermo.Items.Clear();
                secondaryComponentListThermo.Items.Clear();
                outputListThermo.Items.Clear();
            }
            catch(Exception ex)
            {
                ModernDialog.ShowMessage("Archivo no seleccionado." + ex.GetType().ToString(), "¡Error de archivo!!", System.Windows.MessageBoxButton.OK);
            }
            fillBrands();
        }

        private void thermoNextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void secondaryComponentListThermo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SecondaryThermoComponents selectedItem = (SecondaryThermoComponents)secondaryComponentListThermo.SelectedItem;
            //outputListThermo.Items.Clear(); --> Uncomment if the user wants a single element 
            outputListThermo.Items.Add(new SecondaryThermoComponents() { id = selectedItem.id, brandName = selectedItem.brandName, efficiency = selectedItem.efficiency });
        }
        /// <summary>
        ///  First check if the brand exists. If it does it returns the ID of that one, if doesn't exist 
        ///  it will insert it to the DB and return the ID
        /// </summary>
        /// <param cell="brandCell"></param>
        /// <returns>brandID</returns>
        public int insertBrandToDB(Cell brandCell)
        {
            int brandID = 0;
            DataModel context = new DataModel();
            string brandName = brandCell.ToString();
            var brandExists = from brandInfo in context.thermocomponents where brandInfo.brand == brandName select brandInfo.id;
            if (brandExists.Count() == 0)
            {
                thermocomponent mainThComp = new thermocomponent
                {
                    brand = brandName
                };
                context.thermocomponents.Add(mainThComp);
                context.SaveChanges();
                brandExists = from brandInfo in context.thermocomponents where brandInfo.brand == brandName select brandInfo.id;
                brandID = brandExists.First<int>();
            }
            else
            {
                brandID = brandExists.First<int>();
            }
            return brandID;
        }
        //////////////////////////////////////////

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

        public void fillBrands()
        {
            try
            {
                DataModel thermoComponentInfo = new DataModel();
                var query = from thermoInfo in thermoComponentInfo.thermocomponents orderby thermoInfo.brand select new { thermoInfo.id, thermoInfo.brand };
                foreach (var thermoResult in query.ToList())
                {
                    mainComponentListThermo.Items.Add(new MainThermoComponent() { id = int.Parse(thermoResult.id.ToString()), brand = thermoResult.brand.ToString() });
                }
                thermoComponentInfo.Dispose();
            }
            catch(Exception exc)
            {
                ModernDialog.ShowMessage("Hubo un error con la base de datos. Tipo de error: " + exc.GetType().ToString(), "¡Error!", System.Windows.MessageBoxButton.OK);
            }
        }
        //////////////////////////////////////////
    }
}
