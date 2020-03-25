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
        public Unit[] units;
        public Squad() : this(5) { }
        public Squad(int maxSize)
        {
            this.maxSize = maxSize;
            units = new Unit [maxSize];
        }

        public int MaxSize { 
            get { return maxSize; } 
            set 
            { 
                //if max size is increased, recreate the array
                if (value > maxSize)
                {
                    maxSize = value;
                    Unit[] temp = new Unit[value];
                    for(int i = 0; i < units.Length;i++)
                    {
                        temp[i] = units[i];
                    }
                    units = temp;
                }
            } }

        public void addUnit(int position, Unit unit)
        {
            if (!unit.IsInSquad) {
                units[position] = unit;
                unit.IsInSquad = true;
                Console.WriteLine("[Squad] A unit was added!");
            }
        }
        public void removeUnit(int position)
        {
            if (units[position] != null)
            {
                units[position].IsInSquad = false;
                units[position] = null;
                Console.WriteLine("[Squad] A unit was removed!");
            }
        }
    }
}
