using PlanetCalc.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PlanetCalc.ViewModel
{
    public class MainWindowModel
    {
        public string Path { get; set; }
        public ObservableCollection<Planet> Planets { get; set; }

        public void LoadPlanets(ref DBConnection db)
        {
            Planets = new ObservableCollection<Planet>(db.FetchData());
        }
    }
}
