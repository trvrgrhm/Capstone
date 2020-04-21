using CrossPlatform.GameTop.ArmyInfo;
using CrossPlatform.GameTop.LevelInfo;
using System;
using System.Collections.Generic;

namespace CrossPlatform.GameTop.Storage
{
    class WrapperManager
    {
        public ArmyWrapper generateWrapperFromArmy(Army army)
        {
            ArmyWrapper wrapper = new ArmyWrapper();
            wrapper.squads = new List<SquadWrapper>();
            wrapper.extraUnits = new List<UnitWrapper>();
            wrapper.owner = army.Owner;
            //add squads and units in squads
            foreach (Squad squad in army.squads)
            {
                SquadWrapper squadWrapper = new SquadWrapper();
                squadWrapper.units = new List<UnitWrapper>();
                squadWrapper.row = squad.Row;
                squadWrapper.col = squad.Column;
                foreach (Unit unit in squad.units)
                {
                    if (unit != null)
                    {
                        UnitWrapper unitWrapper = new UnitWrapper();
                        unitWrapper.type = unit.Type.ToString();
                        squadWrapper.units.Add(unitWrapper);
                    }
                }
                wrapper.squads.Add(squadWrapper);
            }
            //add units that aren't in squads
            foreach (Unit unit in army.units)
            {
                if (!unit.IsInSquad)
                {
                    UnitWrapper unitWrapper = new UnitWrapper();
                    unitWrapper.type = unit.Type.ToString();
                    wrapper.extraUnits.Add(unitWrapper);
                }
            }
            return wrapper;
        }

        public Army generateArmyFromWrapper(ArmyWrapper wrapper)
        {
            Army army = new Army(wrapper.owner);
            //add squads and units in squads
            foreach (SquadWrapper squadWrapper in wrapper.squads)
            {
                int i = 0;
                foreach (UnitWrapper unitWrapper in squadWrapper.units)
                {
                    Unit unit = new Unit(unitWrapper.type);
                    army.squads[squadWrapper.row, squadWrapper.col].addUnit(i, unit);
                    i++;
                }
            }
            //add extra units
            foreach (UnitWrapper unitWrapper in wrapper.extraUnits)
            {
                Unit unit = new Unit(unitWrapper.type);
                army.addUnit(unit);
            }
            return army;
        }

        public MapWrapper generateWrapperFromMap(CityMap map)
        {
            MapWrapper wrapper = new MapWrapper();
            wrapper.cities = new List<CityWrapper>();
            foreach(City city in map.Cities)
            {
                wrapper.cities.Add(generateWrapperFromCity(city));
            }
            return wrapper;
        }
        public CityMap generateMapFromWrapper(MapWrapper wrapper)
        {
            CityMap map = new CityMap();
            foreach(CityWrapper city in wrapper.cities)
            {
                Army tempArmy = generateArmyFromWrapper(city.army);
                City temp = new City(map, new Microsoft.Xna.Framework.Point(city.xPosition, city.yPosition), city.name,tempArmy.Owner);
                temp.SetStationedArmy(tempArmy);
                //map.Cities.Add(temp);
            }
            return map;
        }

        public CityWrapper generateWrapperFromCity(City city)
        {
            CityWrapper wrapper = new CityWrapper();
            wrapper.name = city.CityName;
            wrapper.xPosition = city.MapLocation.X;
            wrapper.yPosition = city.MapLocation.Y;
            wrapper.army = generateWrapperFromArmy(city.GetStationedArmy());
            return wrapper;
        }
    }

    [Serializable]
    public struct ArmyWrapper
    {
        public string owner;
        public List<SquadWrapper> squads;
        public List<UnitWrapper> extraUnits;
    }
    [Serializable]
    public struct SquadWrapper
    {
        public int row;
        public int col;
        public List<UnitWrapper> units;
    }
    [Serializable]
    public struct UnitWrapper
    {
        public string type;
    }
    [Serializable]
    public struct MapWrapper
    {
        public List<CityWrapper> cities;
    }
    [Serializable]
    public struct CityWrapper
    {
        public string name;
        public int xPosition;
        public int yPosition;
        public ArmyWrapper army;
    }


}
