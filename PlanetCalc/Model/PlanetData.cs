using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetCalc.Model
{
    public static class PlanetData
    {
        public static List<Planet> Generate()
        {
            List<Planet> planets = new List<Planet>();

            planets.Add(new Planet(
                                    "Merkury",
                                    2.4397E3,
                                    3.285E23));
            planets.Add(new Planet(
                                    "Wenus",
                                    6.0518E3,
                                    4.867E24));
            planets.Add(new Planet(
                                    "Ziemia",
                                    6.371E3,
                                    5.972E24));
            return planets;
        }
    }
}
