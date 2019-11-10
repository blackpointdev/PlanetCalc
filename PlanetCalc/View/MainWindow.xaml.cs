using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using PlanetCalc.Model;
using PlanetCalc.ViewModel;

namespace PlanetCalc.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowModel mainWindowModel;
        private string dbPath;
        public MainWindow()
        {
            dbPath = "PlanetsRepository.db";
            DBConnection db = new DBConnection(dbPath);

            // MVVM stuff
            mainWindowModel = new MainWindowModel();
            mainWindowModel.LoadPlanets(ref db);
            
            InitializeComponent();

            // Binding data to my view model
            //TODO Create separate UserControl for list and data display part.
            this.DataContext = mainWindowModel;

            PlanetsList.SelectedIndex = 0;
        }

        private void PlanetsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Planet planet = (Planet)PlanetsList.SelectedItem;

            if (planet != null)
            {
                CircularValueLabel.Content = planet.CircularVelocity + " KM/s";
                EscapeValueLabel.Content = planet.EscapeVelocity + " KM/s";
                AccelerationValueLabel.Content = planet.AccelerationOfGravity + " m/s^2";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPlanetWindow addPlanetWindow = new AddPlanetWindow();
            addPlanetWindow.Show();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Planet planet = (Planet)PlanetsList.SelectedItem;

            if (PlanetsList.SelectedIndex > 0)
            {
                PlanetsList.SelectedIndex = PlanetsList.SelectedIndex - 1;
            }

            mainWindowModel.Planets.Remove(planet);

            DBConnection db = new DBConnection(dbPath);
            db.RemovePlanet(planet);
        }
    }
}
