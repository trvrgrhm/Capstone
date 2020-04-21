using CrossPlatform.GameTop.ArmyInfo;
using System;
using System.Collections.Generic;

namespace CrossPlatform.GameTop.Storage
{
    class WrapperManager
    {
        public ArmyWrapper generateArmyWrapper(Army army)
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
}
