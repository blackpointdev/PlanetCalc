using LiteDB;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace PlanetCalc.Model
{
    class DBConnection
    {
        private string _path;
        public DBConnection(string path)
        {
            _path = path;
            if (!File.Exists(@path))
            {
                using (var db = new LiteDatabase(@_path))
                {
                    var planets = db.GetCollection<Planet>("planets");

                    List<Planet> planetsList = new List<Planet>();
                    planetsList = PlanetData.Generate();

                    planets.Insert(planetsList);
                }
            }
        }

        public List<Planet> FetchData()
        {
            using (var db = new LiteDatabase(@_path))
            {
                var planets = db.GetCollection<Planet>("planets");
                return planets.FindAll().ToList();
            }
        }
    }
}
