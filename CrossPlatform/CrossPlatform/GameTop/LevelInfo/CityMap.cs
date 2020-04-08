using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.LevelInfo
{
    class CityMap
    {
        public List<City> Cities { get; set; }
        public Rectangle MapRect { get; set; }
        public CityMap()
        {
            //TODO: fix how to add cites to map, I don't think I like this way...
            MapRect = new Rectangle(0, 0, 200, 200);
            Cities = new List<City>();
            City startCity = new City(this);
        }
    }
}
