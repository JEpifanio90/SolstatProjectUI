using FirstFloor.ModernUI.Windows.Controls;
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

namespace SolstatProjectUI.Pages.arrays
{
    /// <summary>
    /// Interaction logic for arraysPage.xaml
    /// </summary>
    public partial class arraysPage : UserControl
    {
        public arraysPage()
        {
            InitializeComponent();
            fillComponentList();
            
        }

        private void fillComponentList()
        {
            if (!checkPhotovoltaicData() && !checkThermosolarData())
                ModernDialog.ShowMessage("Por favor elige unos componentes de la pestaña de 'Termosolar' o 'Fotovoltaíco'", "¡Peligro!", MessageBoxButton.OK);

        }

        private Boolean checkPhotovoltaicData()
        {
            try
            {
                if (photovoltaic.photovoltaicPage.photovoltaicData.Count > 0)
                {
                    loopOverList(photovoltaic.photovoltaicPage.photovoltaicData);
                }
                return true;
            }
            catch(Exception exc)
            {
                Console.WriteLine("DEBUG- " + exc);
                return false;
            }
        }

        private Boolean checkThermosolarData()
        {
            try
            {
                if (thermosolar.thermosolarPage.thermosolarData.Count > 0)
                {
                    loopOverList(thermosolar.thermosolarPage.thermosolarData);
                }
                return true;
            }
            catch (Exception exc)
            {
                Console.WriteLine("DEBUG- " + exc);
                return false;
            }
        }

        private void loopOverList(Dictionary<String, Dictionary<String, String>> componentsList)
        {
            foreach (KeyValuePair<String, Dictionary<String, String>> parentComponent in componentsList)
            {
                int idComponent = int.Parse(parentComponent.Key);
                double componentPrice = 0.00;
                string componentName = "";
                foreach(KeyValuePair<String, String> component in parentComponent.Value)
                {
                    if ("panelName" == component.Key.ToString() || "brandName" == component.Key.ToString())
                        componentName = component.Value;

                    if ("price" == component.Key.ToString())
                        componentPrice = double.Parse(component.Value);
                }
                componentList.Items.Add(new genericComponent() { id = idComponent, name = componentName, price = componentPrice, quantity = 1, total = 1*componentPrice});
            }
        }
        
        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sliderChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /*Slider sliderRange = sender as Slider;
            var item = sliderRange.DataContext;
            var component = (genericComponent)item;
            component.total = 100 * e.NewValue;*/
        }
    }
}
