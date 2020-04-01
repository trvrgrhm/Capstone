using CrossPlatform.GameTop.ArmyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop
{
    class PlayerInfo
    {
        public Army PlayerArmy { get; set; }
        //settings?

        public PlayerInfo() : this(new Army())
        {
            Unit firstUnit = new Unit();
            PlayerArmy.addUnit(firstUnit);
            Squad firstSquad = new Squad(2,2);
            firstSquad.addUnit(0, firstUnit);
            PlayerArmy.addSquad(0,0,firstSquad);
        }
        public PlayerInfo(Army army)
        {
            PlayerArmy = army;
        }
    }
}
