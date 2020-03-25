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
        List<BattlePuppet> puppets { get; set; }
        public Battle(Army player, Army enemy)
        {
            PlayerArmy = player;
            EnemyArmy = enemy;
            puppets = new List<BattlePuppet>();
        }

        private void generatePuppets(Army army)
        {
            foreach (Squad squad in army.squads)
            {
                foreach(Unit unit in squad.units)
                {
                    //get init position from squad
                    BattlePuppet puppet = new BattlePuppet(unit, 0, 0);
                }
            }
        }



    }
}
