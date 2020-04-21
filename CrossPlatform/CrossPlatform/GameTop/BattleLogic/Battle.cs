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
        public List<BattlePuppetSquad> PlayerSquads { get; set; }
        public List<BattlePuppet> EnemyPuppets { get; set; }

        public bool battleOver;
        public int battleOverDelay;

        public Army Winner { get; set; }

        public Battle(Army player, Army enemy, Rectangle battleArea)
        {
            BattleArea = battleArea;
            PlayerArmy = player;
            EnemyArmy = enemy;
            PlayerPuppets = new List<BattlePuppet>();
            PlayerSquads = new List<BattlePuppetSquad>();
            EnemyPuppets = new List<BattlePuppet>();
            generatePlayerPuppets(player,new Point(BattleArea.X, BattleArea.Y + BattleArea.Height / 4));
            generateEnemyPuppets(enemy,new Point(BattleArea.X+BattleArea.Width-(BattleArea.Width/2), BattleArea.Y + BattleArea.Height / 4));
            giveThemBadGuys(PlayerPuppets,EnemyPuppets);
            giveThemBadGuys(EnemyPuppets, PlayerPuppets);
            battleOver = false;
            battleOverDelay = 10;
            Winner = null;
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

            if (battleOver)
            {
                checkWinner();
                battleOverDelay--;
            }
        }
        private void generatePlayerPuppets(Army army, Point startPosition)
        {
            foreach (Squad squad in army.squads)
            {
                if (squad != null)
                {
                    BattlePuppetSquad puppetSquad = new BattlePuppetSquad();

                    Rectangle squadRect = new Rectangle(startPosition.X + squad.Row * BattleArea.Height / 8, startPosition.Y + squad.Column * BattleArea.Height / 8, BattleArea.Height / 8, BattleArea.Height / 8);
                    for (int i = 0; i < squad.MaxSize; i++)
                    {
                        if (squad.units[i] != null)
                        {
                            BattlePuppet temp = new BattlePuppet(this, squad.units[i], squadRect.X + squadRect.Width - (i * (squadRect.Width / squad.MaxSize)), squadRect.Y + (squadRect.Height / 2), BattleArea.Center);
                            temp.Destination = new Point(BattleArea.Right,temp.HitBox.Y);
                            PlayerPuppets.Add(temp);
                            puppetSquad.puppets.Add(temp);
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
                    PlayerSquads.Add(puppetSquad);
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
            foreach (Squad squad in army.squads)
            {
                if (squad != null)
                {
                    Rectangle squadRect = new Rectangle(startPosition.X + squad.Row * BattleArea.Height / 8, startPosition.Y + squad.Column * BattleArea.Height / 8, BattleArea.Height / 8, BattleArea.Height / 8);
                    for (int i = 0; i < squad.MaxSize; i++)
                    {
                        if (squad.units[i] != null)
                        {
                            EnemyPuppets.Add(new BattlePuppet(this,squad.units[i], squadRect.X + squadRect.Width - (i * (squadRect.Width / squad.MaxSize)), squadRect.Y + (squadRect.Height / 2),new Point( BattleArea.Left, squadRect.Y + (squadRect.Height / 2))));
                        }
                    }
                }
            }
        }
        private void giveThemBadGuys(List<BattlePuppet> goodGuys, List<BattlePuppet> BadGuys)
        {
            foreach (BattlePuppet goodGuy in goodGuys)
            {
                foreach(BattlePuppet badGuy in BadGuys)
                {
                    goodGuy.Enemies.Add(badGuy);
                }
            }
        }

        private void checkWinner()
        {
            foreach (BattlePuppet puppet in PlayerPuppets)
            {
                if (!puppet.isDead)
                {
                    Winner = PlayerArmy;
                }
            }
            foreach (BattlePuppet puppet in EnemyPuppets)
            {
                if (!puppet.isDead)
                {
                    Winner = EnemyArmy;
                }
            }
        }
    }
}
