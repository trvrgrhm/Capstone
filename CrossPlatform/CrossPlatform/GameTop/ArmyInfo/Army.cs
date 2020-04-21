using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.ArmyInfo
{
    class Army
    {
        public String Owner { get; set; }
        public Squad[,] squads;
        public List<Unit> units;

        public Army(string owner)
        {
            Owner = owner;
            squads = new Squad[4,4];
            for(int i = 0;i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    squads[i, j] = new Squad(i,j);
                }
            }
            units = new List<Unit>();
        }

        //public void addSquad(int row, int col, Squad squad)
        //{
        //    if (squads[row, col] == null)
        //    {
        //        squads[row, col] = squad;
        //        squad.Row = row;
        //        squad.Column = col;
        //        Console.WriteLine("[Army] A squad was placed at " + row + "," + col + "!");
        //        return;
        //    }
        //    else
        //    {
        //        Console.WriteLine("[Army] Squads must be removed from a spot before a new one can be placed!");
        //        return;
        //    }
        //}

        //public void removeSquad(int row, int col)
        //{
        //    if (squads[row, col] == null)
        //    {
        //        Console.WriteLine("[Army] There is no squad to remove!");
        //        return;
        //    }
        //    else
        //    {
        //        squads[row, col].removeAllUnits();
        //        squads[row, col] = null;
        //        Console.WriteLine("[Army] A squad was removed at "+row+","+col+"!");
        //        return;
        //    }
        //}
        
        private void swapSquads(ref Squad squad1, ref Squad squad2)
        {
            //TODO check this...
            //Console.WriteLine("Squad 1: row,column : " + squad1.Row + ", " + squad1.Column + ", Squad 2: row,column : " + squad2.Row + ", " + squad2.Column);
            Squad temp = squad1;
            squad1 = squad2;
            squad2 = temp;
            //Console.WriteLine("Squad 1: row,column : " + squad1.Row + ", " + squad1.Column + ", Squad 2: row,column : " + squad2.Row + ", " + squad2.Column);
        }
        public void swapSquads(Squad squad1, Squad squad2)
        {
            swapSquads(squad1.Row, squad1.Column, squad2.Row, squad2.Column);
        }
        public void swapSquads(int row1, int col1, int row2, int col2)
        {
            ref Squad squad1 = ref squads[row1, col1];
            ref Squad squad2 = ref squads[row2, col2];
            swapSquads(ref squad1, ref squad2);
            if (squads[row1, col1] != null)
            {
                squads[row1, col1].Row = row1;
                squads[row1, col1].Column = col1;
            }
            if (squads[row2, col2] != null)
            {
                squads[row2, col2].Row = row2;
                squads[row2, col2].Column = col2;
            }
        }
        //return true if successful; false if not
        public bool addUnitToSquad(Unit unit, Squad squad)
        {
            return addUnitToSquad(unit, squad.Row, squad.Column);
        }
        public bool addUnitToSquad(Unit unit ,int row, int col)
        {
            ref Squad squad = ref squads[row, col];
            //if unit is in army
            if(units.Contains(unit))
            {
                //if squad doesn't exist, create one; this shouldn't happen though...
                if(squad == null)
                {
                    squad = new Squad(row,col);
                    squad.addUnit(0,unit);
                    return true;
                }
                //if squad is full, don't allow
                else if (squad.isFull())
                {
                    return false;
                }
                //otherwise try to insert the unit into the squad
                else
                {
                    for(int i = 0; i < squad.MaxSize; i++)
                    {
                        if (squad.units[i] == null)
                        {
                            //stop trying if there is an empty spot in the squad
                            squad.addUnit(i, unit);
                            //squad.units[i] = unit;
                            return true;
                        }
                    }
                    //otherwise something went wrong...
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //return true if successfull, false if not
        public bool removeUnitFromSquad(int unitPosition, Squad squad)
        {
            return removeUnitFromSquad(unitPosition, squad.Row, squad.Column);
        }
        public bool removeUnitFromSquad(int unitPosition, int row, int col)
        {
            ref Squad squad = ref squads[row, col];
            if (squad != null)
            {
                squad.removeUnit(unitPosition);
                return true;
            }
            return false;
        }

        public bool removeUnitFromSquad(Unit unit, Squad squad)
        {
            if (squad.containsUnit(unit))
            {
                return removeUnitFromSquad(unit.SquadPosition, squad);
            }
            return false;
        }


        public Unit removeRandomUnitFromArmy()
        {
            Random rnd = new Random();
            Unit chosenUnit = units[rnd.Next(units.Count)];
            if (removeUnitFromArmy(chosenUnit))
            {
                Console.WriteLine("successfully added a unit to an army");
                return chosenUnit;
            }
            chosenUnit = units[0];
            if (removeUnitFromArmy(chosenUnit))
            {
                Console.WriteLine("successfully added a unit to an army");
                return chosenUnit;
            }
            Console.WriteLine("failed to add a unit to an army");
            return null;
            

        }


        public void addUnit(Unit unit)
        {
            if (unit != null)
            {
                units.Add(unit);
            }
        }

        private bool removeUnitFromArmy(Unit unit)
        {
            if (containsUnit(unit))
            {
                foreach (Squad squad in squads)
                {
                    if (squad.containsUnit(unit))
                    {
                        if (removeUnitFromSquad(unit, squad))
                        {
                            units.Remove(unit);
                            return true;
                        }
                    }
                }
                units.Remove(unit);
                return true;
            }
            return false;
        }
        public bool containsUnit(Unit unit)
        {
            foreach(Unit unitCheck in units)
            {
                if(unit == unitCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
