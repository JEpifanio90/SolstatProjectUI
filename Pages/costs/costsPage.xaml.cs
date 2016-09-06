using Bytescout.Spreadsheet;
using Microsoft.Win32;
using SolstatProject.Models;
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
using SolstatProjectUI.HelperClasses;

namespace SolstatProjectUI.Pages.costs
{
    /// <summary>
    /// Interaction logic for costsPage.xaml
    /// </summary>
    public partial class costsPage : UserControl
    {
        private EvaluacionEconomicaServices _EEService = new EvaluacionEconomicaServices();

        public costsPage()
        {
            InitializeComponent();
        }

        //TAB 5 Costos
        private void exportData(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Exporting to PDF");
        }

        private void newCalculation(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("New calculation");
        }
        private void components_eeUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Spreadsheet document = new Spreadsheet();
                document.LoadFromFile(System.IO.Path.GetFullPath(showDialogAndGetFilePath()));
                Worksheet workSheet = document.Workbook.Worksheets.ByName("Base");
                components_EE component = new components_EE();
                string marcaComercial;
                string componente;
                string costo;
                int codigo = 0;
                double cost = 0;


                using (DataModel context = new DataModel())
                {
                    for (var i = 2; i <= workSheet.UsedRangeRowMax; i++)
                    {
                        marcaComercial = workSheet.Cell("B" + i).ToString();
                        componente = workSheet.Cell("D" + i).ToString();
                        costo = workSheet.Cell("F" + i).ToString().Replace("$", "");
                        if (!string.IsNullOrEmpty(marcaComercial) && !string.IsNullOrEmpty(componente) && int.TryParse(workSheet.Cell("H" + i).ToString(), out codigo) && double.TryParse(costo, out cost))
                        {

                            component.codigo = codigo;
                            component.componente = componente;
                            component.marcaComercial = marcaComercial;
                            component.costo = cost;
                            component.tipoMoneda = workSheet.Cell("G" + i).ToString();
                            component.tipo = workSheet.Cell("I" + i).ToString();

                            context.componentsEntity.Add(component);

                            context.SaveChanges();


                        };
                        component = new components_EE();
                        costo = componente = marcaComercial = string.Empty;

                    };
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Hubo un error con al actualizar la base de datos. Tipo de error: " + error.GetType().ToString(), "¡Error!", MessageBoxButton.OK);

            }
        }
        private void calculateVPN_Click(object sender, RoutedEventArgs e)
        {
            double discountRate = double.Parse(tasaDescuentoTxt.Text);
            List<double> incomes = _EEService.CalculateIncomes(100);
            double vpn = _EEService.CalculateVPN(1000, incomes, (discountRate / 100));
            vpnTxt.Text = vpn.ToString();
        }
        /////////////////////////////////////////

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
        /////////////////////////////////////////
    }
}
