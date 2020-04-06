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
            Unit special = new Unit();
            special.Type = UnitType.Miku;
            special.Picture = TextureName.MikuWarrior;
            special.MaxHealth += 50;
            special.Attack += 10;
            special.AttackSpeed += 1;
            PlayerArmy.addUnit(firstUnit);
            PlayerArmy.addUnit(special);
            for(int i = 0;i < 10; i++)
            {
                PlayerArmy.addUnit(new Unit());
            }
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
