
using System;

namespace PlanetCalc.Model
{
    public class Planet
    {
        public int Id { get; private set; }

        public string Name { get; set; }
        public double Radius { get; set; }
        public double Mass { get; set; }


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

    }
}
