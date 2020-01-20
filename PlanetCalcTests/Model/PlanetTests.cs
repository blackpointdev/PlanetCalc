using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanetCalc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetCalc.Model.Tests
{
    [TestClass()]
    public class PlanetTests
    {
        [TestMethod()]
        public void CalculateOrbitalVelocityTest()
        {
            double radius = 1;
            double mass = 1;
            string name = "test";
            double expected = Math.Round(Math.Sqrt(6.67E-11), 3);
            Planet planet = new Planet(name, radius, mass);

            Assert.AreEqual(expected, planet.CalculateOrbitalVelocity(), 3);
        }

        [TestMethod()]
        public void CalculateEscapeVelocityTest()
        {
            double radius = 2343;
            double mass = 95483;
            string name = "test";
            double orbitalVelocity = Math.Round(Math.Sqrt((6.67E-11 * mass) / radius), 3);
            double expected = Math.Round(Math.Sqrt(2) * orbitalVelocity, 3);
            Planet planet = new Planet(name, radius, mass);

            Assert.AreEqual(expected, planet.CalculateEscapeVelocity(), 3);
        }

        [TestMethod()]
        public void CalculateAccelerationOfGravityTest()
        {
            double radius = 2343;
            double mass = 95483;
            string name = "test";
            double expected = Math.Round(6.67E-11 * (mass / ((radius * 1000 + 100) * (radius * 1000 + 100))), 3);
            Planet planet = new Planet(name, radius, mass);

            Assert.AreEqual(expected, planet.CalculateAccelerationOfGravity(), 3);
        }
    }
}