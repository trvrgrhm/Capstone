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

        private Army stationedArmy;
        private string cityOwner;

        public String CityName { get; set; }


        public Point MapLocation { get; set; }

        public City(CityMap map,Point location,string cityName,string cityOwner)
        {
            Map = map;

            SetStationedArmy(new Army(cityOwner));
            Unit firstUnit = new Unit();
            Unit secondUnit = new Unit();
            Unit thirdUnit = new Unit();
            Unit fourthUnit = new Unit();
            Unit fifthUnit = new Unit();
            Unit sixthUnit = new Unit();
            GetStationedArmy().addUnit(firstUnit);
            GetStationedArmy().squads[3, 0].addUnit(0, firstUnit);
            GetStationedArmy().squads[3, 3].addUnit(0, secondUnit);
            GetStationedArmy().squads[3, 2].addUnit(0, fifthUnit);
            GetStationedArmy().squads[3, 2].addUnit(1, thirdUnit);
            GetStationedArmy().squads[3, 2].addUnit(2, fourthUnit);
            GetStationedArmy().squads[3, 1].addUnit(0, sixthUnit);

            CityName = cityName;

            MapLocation = location;

            //TODO: add units to army like this?
            Map.Cities.Add(this);

        }

        public Army GetStationedArmy()
        {
            return stationedArmy;
        }

        public void SetStationedArmy(Army army)
        {
            stationedArmy = army;
            cityOwner = army.Owner;
        }
        public string GetCityOwner()
        {
            return cityOwner;
        }

        //public void SetCityOwner(string value, Army army)
        //{
        //    cityOwner = value;
        //}
    }
}
