using CrossPlatform.GameTop.ArmyInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.BattleLogic
{
    class Battle
    {
        Army PlayerArmy { get; set; }
        Army EnemyArmy { get; set; }
        public Battle(Army player, Army enemy)
        {
            PlayerArmy = player;
            EnemyArmy = enemy;
        }




    }
}
