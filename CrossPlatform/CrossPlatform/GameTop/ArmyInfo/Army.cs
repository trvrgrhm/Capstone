using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.ArmyInfo
{
    class Army
    {
        Squad[,] squads;
        List<Unit> units;

        public Army()
        {
            squads = new Squad[5,4];
            units = new List<Unit>();
        }

        public void addSquad(int row, int col, Squad squad)
        {
            if (squads[row, col] == null)
            {
                squads[row, col] = squad;
                Console.WriteLine("[Army] A squad was placed at " + row + "," + col + "!");
                return;
            }
            else
            {
                Console.WriteLine("[Army] Squads must be removed from a spot before a new one can be placed!");
                return;
            }
        }

        public void removeSquad(int row, int col)
        {
            if (squads[row, col] == null)
            {
                Console.WriteLine("[Army] There is no squad to remove!");
                return;
            }
            else
            {
                squads[row, col] = null;
                Console.WriteLine("[Army] A squad was removed at "+row+","+col+"!");
                return;
            }
        }

        public void addUnit(Unit unit)
        {
            units.Add(unit);
        }

        public void remove(Unit unit)
        {
            units.Remove(unit);
        }
    }
}
