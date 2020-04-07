using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.ArmyInfo
{
    class Squad
    {
        
        private int maxSize;

        public int Row { get; set; }
        public int Column { get; set; }
        public Unit[] units;
        public Squad(int row, int col) : this(row,col,5) { }
        public Squad(int row, int col, int maxSize)
        {
            this.maxSize = maxSize;
            units = new Unit [maxSize];
            Row = row;
            Column = col;
        }

        public int MaxSize
        {
            get { return maxSize; }
            set
            {
                //if max size is increased, recreate the array
                if (value > maxSize)
                {
                    maxSize = value;
                    Unit[] temp = new Unit[value];
                    for (int i = 0; i < units.Length; i++)
                    {
                        temp[i] = units[i];
                    }
                    units = temp;
                }
            }
        }
        public bool containsUnit(Unit unit)
        {
            return units.Contains(unit);
        }

        public bool addUnit(int position, Unit unit)
        {
            if (!unit.IsInSquad&&!this.isFull()) {
                unit.IsInSquad = true;
                unit.SquadPosition = position;
                units[position] = unit;
                Console.WriteLine("[Squad] A unit was added!");
                return true;
            }
            return false;
        }
        public void removeUnit(int position)
        {
            if (units[position] != null)
            {
                //if (position ==0 && units[position + 1] != null)
                //{
                    //removeUnitForSure(position);
                    units[position].IsInSquad = false;
                    units[position].SquadPosition = -1;
                    units[position] = null;
                    Console.WriteLine("[Squad] A unit was removed!");
                    shiftUnitsLeft(position);
                //}
                //else
                //{
                //    removeUnitForSure(position);
                //}

            }
        }
        //private void removeUnitForSure(int position)
        //{

        //units[position].IsInSquad = false;
        //            units[position].SquadPosition = -1;
        //            units[position] = null;
        //            Console.WriteLine("[Squad] A unit was removed!");
            
        //}
        //shift units left from a certain position
        private void shiftUnitsLeft(int position)
        {
            for(int i = position+1; i < maxSize; i++)
            {
                units[i - 1] = units[i];
                if (units[i - 1] != null)
                {
                    units[i - 1].SquadPosition = i - 1;
                }
                if(i == maxSize - 1)
                {
                    units[i] = null;
                }
            }
        }
        public void removeAllUnits()
        {
            for(int i = 0; i < units.Length; i++)
            {
                removeUnit(i);
            }
        }
        public bool isFull()
        {
            foreach(Unit unit in units)
            {
                if (unit == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
