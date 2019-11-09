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
            mainWindowModel.LoadPlanets(db);
            Debug.WriteLine(mainWindowModel.Planets[0].Name);
            
            InitializeComponent();

            this.DataContext = mainWindowModel;
        }
    }
}
