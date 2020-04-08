using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Tiles
{
    class BattleInfoTile
    {
        HoverableElement Background { get; set; }
        TextElement BattleInfo { get; set; }
        public BattleInfoTile(Screen screen, Renderer renderer, Rectangle rect)
        {
            Background = new HoverableElement(screen, renderer, rect);
            BattleInfo = new TextElement(screen, renderer, rect, "Battle Information");

        }
    }
}
