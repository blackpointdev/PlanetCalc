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

namespace PlanetCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DBConnection db = new DBConnection("PlanetsRepository.db");

            List<Planet> planets = db.FetchData();
            List<PlanetListItem> items = new List<PlanetListItem>();

            foreach (var i in planets)
            {
                items.Add(new PlanetListItem { Name = i.Name });
            }
            //List<string> itemsNames = planets.Select(o => o.Name).ToList();

            
            InitializeComponent();
            PlanetsList.ItemsSource = items;
        }
    }

    public class PlanetListItem
    { 
        public string Name { get; set; }
    }
}
