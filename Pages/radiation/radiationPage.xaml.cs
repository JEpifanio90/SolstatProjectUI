using FirstFloor.ModernUI.Windows;
using Microsoft.Maps.MapControl.WPF;
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
using FirstFloor.ModernUI.Windows.Navigation;
using FirstFloor.ModernUI.Windows.Controls;

namespace SolstatProjectUI.Pages.radiation
{
    /// <summary>
    /// Interaction logic for radiationPage.xaml
    /// </summary>
    public partial class radiationPage : UserControl
    {
        public Dictionary<string, string> countyCoordinatesList = new Dictionary<string, string>(); //<---There should be a way to avoid this
        public Dictionary<string, string> resultInfo = new Dictionary<string, string>(); //<---- and this ... and yo' face.
        public radiationPage()
        {
            InitializeComponent();
            fillCounties();
        }

        public void fillCounties()
        {
            try
            {
                DataModel countyLocation = new DataModel();
                var query = from county in countyLocation.countieslocations orderby county.name select new { county.name, county.lat, county.lng };
                if (query != null)
                {
                    foreach (var countyInfo in query.ToList())
                    {
                        if (!countyCoordinatesList.ContainsKey(countyInfo.name))
                        {
                            countyCoordinatesList.Add(countyInfo.name, countyInfo.lat.ToString() + "&" + countyInfo.lng.ToString());
                            CountyList.Items.Add(countyInfo.name.ToString());
                        }
                    }
                }
                countyLocation.Dispose();
            }
            catch(Exception exc)
            {
                ModernDialog.ShowMessage("Hubo un error en la base de datos. Tipo de error: " + exc.GetType().ToString(), "¡Error!", System.Windows.MessageBoxButton.OK);
            }
        }

        //MAIN TAB 0 AND TAB 1----
        public Boolean checkAllDigits(String text)
        {
            Boolean allDigits = false;
            foreach (char singleCharacter in text)
            {
                if (singleCharacter == '.' || singleCharacter == '-')
                {
                    //Console.WriteLine("ES UN PUNTO o el signo de menos");
                    continue;
                }
                else
                {
                    int val = (int)Char.GetNumericValue(singleCharacter);
                    if (val == -1)
                    {
                        //Console.WriteLine("IT'S a String");
                        allDigits = false;
                        break;
                    }
                    else
                    {
                        //Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",singleCharacter.GetType().Name, singleCharacter,val.GetType().Name, val);
                        allDigits = true;
                    }
                }
            }
            return allDigits;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Double latitude = 0.00, longitude = 0.00;
            var brush = new BrushConverter();
            longitudeTB.Background = (Brush)brush.ConvertFrom("#FFFFFF");
            latitudeTB.Background = (Brush)brush.ConvertFrom("#FFFFFF");
            if (!startDate.SelectedDate.HasValue || !endDate.SelectedDate.HasValue)
            {
                startDate.Background = (Brush)brush.ConvertFrom("#FF3333");
                endDate.Background = (Brush)brush.ConvertFrom("#FF3333");
                MessageBox.Show("Check your Start Date and End Date", "Warning", MessageBoxButton.OK);
            }
            else
            {
                startDate.Background = (Brush)brush.ConvertFrom("#FFFFFF");
                endDate.Background = (Brush)brush.ConvertFrom("#FFFFFF");
                try
                {
                    latitude = Double.Parse(latitudeTB.Text.ToString());
                    longitude = Double.Parse(longitudeTB.Text.ToString());
                    results res = new results(startDate.SelectedDate.Value, endDate.SelectedDate.Value, latitude, longitude);
                    Dictionary<string, string> costValues = new Dictionary<string, string>();
                    costValues.Add("generatedEnergy", res.getH0().ToString());
                    costValues.Add("totalYears", res.getYears().ToString());
                    costValues.Add("startDate", startDate.SelectedDate.Value.ToString());
                    costValues.Add("endDate", endDate.SelectedDate.Value.ToString());
                    //TODO: find  a way to transfer this dictionary to the costs view.
                }
                catch (Exception exc)
                {
                    longitudeTB.Background = (Brush)brush.ConvertFrom("#FF3333");
                    latitudeTB.Background = (Brush)brush.ConvertFrom("#FF3333");
                    MessageBox.Show("Check your coordinates" + exc.ToString(), "Warning", MessageBoxButton.OK);
                }
            }
        }

        private void CountyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sender as ListView;

            foreach (KeyValuePair<string, string> countyInfo in countyCoordinatesList)
            {
                string[] splitted = countyInfo.Value.Split('&');
                if (countyInfo.Key.Equals(item.SelectedItem))
                {
                    Pushpin pin = new Pushpin();
                    pin.Location = new Location(Double.Parse(splitted[0]), Double.Parse(splitted[1]));
                    bmap.Center = new Location(Double.Parse(splitted[0]), Double.Parse(splitted[1]));
                    bmap.ZoomLevel = 6;
                    latitudeTB.Text = splitted[0];
                    longitudeTB.Text = splitted[1];
                }
            }
        }

        private void latitudeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var brush = new BrushConverter();
            if (!String.IsNullOrEmpty(textBox.Text))
            {
                Boolean allDigits = checkAllDigits(textBox.Text);
                if (!allDigits)
                {
                    textBox.Background = (Brush)brush.ConvertFrom("#FF3333");
                }
                else
                {
                    textBox.Background = (Brush)brush.ConvertFrom("#FFFFFF");
                    if (longitudeTB != null)
                    {
                        if (!String.IsNullOrEmpty(textBox.Text) && !String.IsNullOrEmpty(longitudeTB.Text))
                        {
                            Pushpin pin = new Pushpin();
                            pin.Location = new Location(Double.Parse(textBox.Text), Double.Parse(longitudeTB.Text));
                            if (bmap != null)
                            {
                                bmap.Children.Clear();
                                bmap.SetView(pin.Location, 5);
                                bmap.Children.Add(pin);
                            }
                        }
                    }
                }
            }
            else
            {
                textBox.Background = (Brush)brush.ConvertFrom("#FFFFFF");
            }
        }

        private void longitudeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            var brush = new BrushConverter();
            if (!String.IsNullOrEmpty(textBox.Text))
            {
                Boolean allDigits = checkAllDigits(textBox.Text);
                if (!allDigits)
                {
                    textBox.Background = (Brush)brush.ConvertFrom("#FF3333");
                }
                else
                {
                    textBox.Background = (Brush)brush.ConvertFrom("#FFFFFF");
                    if (longitudeTB != null)
                    {
                        if (!String.IsNullOrEmpty(textBox.Text) && !String.IsNullOrEmpty(longitudeTB.Text))
                        {
                            Pushpin pin = new Pushpin();
                            pin.Location = new Location(Double.Parse(textBox.Text), Double.Parse(longitudeTB.Text));
                            if (bmap != null)
                            {
                                bmap.Children.Clear();
                                bmap.SetView(pin.Location, 5);
                                bmap.Children.Add(pin);
                            }
                        }
                    }
                }
            }
            else
            {
                textBox.Background = (Brush)brush.ConvertFrom("#FFFFFF");
            }
        }
        
        ////////////////////////////////////////


    }
}


