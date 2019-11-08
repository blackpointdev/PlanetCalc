using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetCalc.Model
{
    public class Planet
    {
        public int Id { get; private set; }

        public string Name { get; set; }
        public double Radius { get; set; }
        public double Mass { get; set; }


        private double? _circularVelocity = null;
        public double CircularVelocity
        {
            get
            {
                if (_circularVelocity == null)
                {
                    _circularVelocity = CalculateCircularVelocity();
                }
                return (double)_circularVelocity;
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

        public Planet()
        {
            //TODO
        }

        public Planet(string name, double radius, double mass)
        {
            this.Name = name;
            this.Radius = radius;
            this.Mass = mass;
        }

        private double CalculateCircularVelocity()
        {
            //TODO
            return 0;
        }

        private double CalculateEscapeVelocity()
        {
            //TODO
            return 0;
        }

        private double CalculateAccelerationOfGravity()
        {
            //TODO
            return 0;
        }

    }
}
