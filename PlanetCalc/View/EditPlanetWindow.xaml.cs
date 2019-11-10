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
using System.Windows.Shapes;
using PlanetCalc.Model;
using PlanetCalc.ViewModel;

namespace PlanetCalc.View
{
    /// <summary>
    /// Logika interakcji dla klasy EditPlanetWindow.xaml
    /// </summary>
    public partial class EditPlanetWindow : Window
    {
        private MainWindowModel mainWindowModel;
        private Planet selectedPlanet;
        public EditPlanetWindow(ref MainWindowModel model, int id)
        {
            InitializeComponent();

            mainWindowModel = model;
            selectedPlanet = mainWindowModel.Planets.First(i => i.Id == id);
            NameInput.Text = selectedPlanet.Name;
            RadiusInput.Text = selectedPlanet.Radius.ToString();
            MassInput.Text = selectedPlanet.Mass.ToString();
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

            selectedPlanet.Name = name;
            selectedPlanet.Radius = radius;
            selectedPlanet.Mass = mass;

            DBConnection db = new DBConnection(mainWindowModel.Path);
            db.UpdatePlanet(selectedPlanet);

            this.Close();
        }
    }
}
