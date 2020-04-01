﻿using CrossPlatform.GameTop.BattleLogic;
using CrossPlatform.GameTop.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Tiles
{
    class BattleTile
    {
        Battle battle;
        RenderableElement[] renderables;
        public BattleTile(Screen screen, Renderer renderer, Microsoft.Xna.Framework.Rectangle rect, ArmyInfo.Army player, ArmyInfo.Army enemy)
        {
            battle = new Battle(player, enemy);
        }

        public void populateRenderables()
        {
            //remove all items from renderer's renderables
            //update animations
            //add renderables in order from least Y to greatest Y from battleObjects
            renderables = renderables.OrderBy( item => item.Rect.Y).ToArray();
            
        }
    }
}
