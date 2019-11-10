using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using PlanetCalc.Model;
using PlanetCalc.ViewModel;

namespace PlanetCalc.View
{
    /// <summary>
    /// Interaction logic for AddPlanetWindow.xaml
    /// </summary>
    public partial class AddPlanetWindow : Window
    {
        private MainWindowModel mainWindowModel;
        public AddPlanetWindow(ref MainWindowModel viewModel)
        {
            InitializeComponent();

            // Style = (Style)FindResource(typeof(Window));
            mainWindowModel = viewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text;
            double radius;
            double mass;

            if (!double.TryParse(RadiusInput.Text, out radius))
            {
                MessageBox.Show("Incorrect radius value.", "Error");
                return;
            }

            if (!double.TryParse(MassInput.Text, out mass))
            {
                MessageBox.Show("Incorrect mass value.", "Error");
                return;
            }

            Planet planet = new Planet(name, radius, mass);
            mainWindowModel.Planets.Add(planet);

            DBConnection db = new DBConnection(mainWindowModel.Path);
            db.AddPlanet(planet);

            this.Close();
        }
    }
}
