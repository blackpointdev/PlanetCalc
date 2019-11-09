using PlanetCalc.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PlanetCalc.ViewModel
{
    class MainWindowModel : INotifyPropertyChanged
    {
        private ObservableCollection<Planet> _planets;
        public ObservableCollection<Planet> Planets
        {
            get { return _planets; }
            set
            {
                _planets = value;
                OnPropertyChanged("Planets");
            }
        }

        public void LoadPlanets(DBConnection db)
        {
            Planets = new ObservableCollection<Planet>(db.FetchData());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
