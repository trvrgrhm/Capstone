using CrossPlatform.GameTop.ArmyInfo;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.BattleLogic
{
    class Battle
    {
        Rectangle BattleArea { get; set; }
        Army PlayerArmy { get; set; }
        Army EnemyArmy { get; set; }
        public List<BattlePuppet> PlayerPuppets { get; set; }
        public List<BattlePuppet> EnemyPuppets { get; set; }
        public Battle(Army player, Army enemy, Rectangle battleArea)
        {
            BattleArea = battleArea;
            PlayerArmy = player;
            EnemyArmy = enemy;
            PlayerPuppets = new List<BattlePuppet>();
            EnemyPuppets = new List<BattlePuppet>();
            generatePlayerPuppets(player,new Point(BattleArea.X, BattleArea.Y + BattleArea.Height / 4));
            generateEnemyPuppets(enemy,new Point(BattleArea.X+BattleArea.Width-(BattleArea.Width/2), BattleArea.Y + BattleArea.Height / 4));
        }

        public void update()
        {
            foreach (BattlePuppet puppet in PlayerPuppets)
            {
                puppet.update();
            }
            foreach (BattlePuppet puppet in EnemyPuppets)
            {
                puppet.update();
            }

        }
        private void generatePlayerPuppets(Army army, Point startPosition)
        {
            foreach (Squad squad in army.squads)
            {
                if (squad != null)
                {
                    Rectangle squadRect = new Rectangle(startPosition.X + squad.Row * BattleArea.Height / 8, startPosition.Y + squad.Column * BattleArea.Height / 8, BattleArea.Height / 8, BattleArea.Height / 8);
                    for (int i = 0; i < squad.MaxSize; i++)
                    {
                        if (squad.units[i] != null)
                        {
                            PlayerPuppets.Add(new BattlePuppet(squad.units[i], squadRect.X + squadRect.Width - (i * (squadRect.Width / squad.MaxSize)), squadRect.Y + (squadRect.Height / 2), BattleArea.Center));
                            ////leader
                            //if (i == 0)
                            //{
                            //    PlayerPuppets.Add(new BattlePuppet(squad.units[i], squadRect.X + squadRect.Width - (squadRect.Width / 4), squadRect.Y + (squadRect.Height / 3), BattleArea.Center));
                            //}
                            ////others
                            //else
                            //{
                            //    PlayerPuppets.Add(new BattlePuppet(squad.units[i], squadRect.X + squadRect.Width - (squadRect.Width / 4), squadRect.Y + (squadRect.Height / 3), BattleArea.Center));
                            //}
                        }
                    }
                    //        foreach (Unit unit in squad.units)
                    //        {
                    //            if (unit != null) 
                    //            {
                    //                //get init position from squad
                    //                BattlePuppet puppet = new BattlePuppet(unit, 0, 0, 2);
                    //                puppets.Add(puppet);
                    //            }
                    //        }
                }
            }
        }
        private void generateEnemyPuppets(Army army, Point startPosition)
        {
            int squadX;
            int squadY;
            foreach (Squad squad in army.squads)
            {
                if (squad != null)
                {
                    Rectangle squadRect = new Rectangle(startPosition.X + squad.Row * BattleArea.Height / 8, startPosition.Y + squad.Column * BattleArea.Height / 8, BattleArea.Height / 8, BattleArea.Height / 8);
                    for (int i = 0; i < squad.MaxSize; i++)
                    {
                        if (squad.units[i] != null)
                        {
                            EnemyPuppets.Add(new BattlePuppet(squad.units[i], squadRect.X + squadRect.Width - (i * (squadRect.Width / squad.MaxSize)), squadRect.Y + (squadRect.Height / 2), BattleArea.Center));
                        }
                    }
                }
            }
        }
    }
}
