using System;
using System.ComponentModel;

namespace PlanetCalc.Model
{
    public class Planet : INotifyPropertyChanged
    {
        public int Id { get; private set; }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private double _radius;
        public double Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                if (_radius != value)
                {
                    _radius = value;
                    OnPropertyChanged("Radius");
                }
            }
        }
        private double _mass;
        public double Mass
        {
            get
            {
                return _mass;
            }
            set
            {
                if (_mass != value)
                {
                    _mass = value;
                    OnPropertyChanged("Mass");
                }
            }
        }


        private double? _OrbitalVelocity = null;
        public double OrbitalVelocity
        {
            get
            {
                if (_OrbitalVelocity == null)
                {
                    _OrbitalVelocity = CalculateOrbitalVelocity();
                }
                return (double)_OrbitalVelocity;
            }
        }

        private double? _escapeVelocity = null;
        public double EscapeVelocity
        {
            get
            {
                if (_escapeVelocity == null)
                {
                    _escapeVelocity = CalculateEscapeVelocity();
                }
                return (double)_escapeVelocity;
            }
        }

        private double? _accelerationOfGravity = null;
        public double AccelerationOfGravity
        {
            get
            {
                if (_accelerationOfGravity == null)
                {
                    _accelerationOfGravity = CalculateAccelerationOfGravity();
                }
                return (double)_accelerationOfGravity;
            }
        }

        private const double _g = 6.67E-11;

        public Planet()
        {
            //TODO Planet parametreless constructor
        }

        public Planet(string name, double radius, double mass)
        {
            this.Name = name;
            this.Radius = radius;
            this.Mass = mass;
        }

        private double CalculateOrbitalVelocity()
        {
            return Math.Round(Math.Sqrt((_g * Mass)/(Radius*1000))/1000, 3);
        }

        private double CalculateEscapeVelocity()
        {
            return Math.Round(Math.Sqrt(2)*OrbitalVelocity, 3);
        }

        private double CalculateAccelerationOfGravity()
        {
            return Math.Round(_g * (Mass/((Radius*1000+100)* (Radius * 1000 + 100))), 3);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

    }
}
