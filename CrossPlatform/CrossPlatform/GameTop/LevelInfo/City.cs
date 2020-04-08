using CrossPlatform.GameTop.ArmyInfo;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.LevelInfo
{
    class City
    {
        CityMap Map { get; set; }
        public Army StationedArmy { get; set; }
        public String CityName { get; set; }
        public String CityOwner { get; set; }
        public Point MapLocation { get; set; }

        public City(CityMap map)
        {
            Map = map;

            StationedArmy = new Army();
            Unit firstUnit = new Unit();
            StationedArmy.addUnit(firstUnit);
            StationedArmy.squads[0, 0].addUnit(0, firstUnit);
            StationedArmy.squads[3, 3].addUnit(0, firstUnit);

            CityName = "Bad City";
            CityOwner = "Enemy";

            MapLocation = new Point(Map.MapRect.Width / 2, Map.MapRect.Height / 2);

            //TODO: add units to army like this?
            Map.Cities.Add(this);

        }
    }
}
