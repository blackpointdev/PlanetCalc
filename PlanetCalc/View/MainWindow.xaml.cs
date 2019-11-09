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
        public MainWindow()
        {
            DBConnection db = new DBConnection("PlanetsRepository.db");

            // MVVM stuff
            MainWindowModel mainWindowModel = new MainWindowModel();
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

            CircularValueLabel.Content = planet.CircularVelocity + " KM/s";
            EscapeValueLabel.Content = planet.EscapeVelocity + " KM/s";
            AccelerationValueLabel.Content = planet.AccelerationOfGravity + " m/s^2";
        }
    }
}
