using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.BattleLogic
{
    class BattlePuppetSquad
    {
        public List<BattlePuppet> puppets = new List<BattlePuppet>();

        public void setDestination(Point destination)
        {
            foreach(BattlePuppet puppet in puppets)
            {
                puppet.overrideTarget(destination);
            }
        }
    }
}
