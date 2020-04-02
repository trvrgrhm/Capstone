using CrossPlatform.GameTop.ArmyInfo;
using CrossPlatform.GameTop.UIElements;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Tiles
{
    class UnitSelectorTile
    {
        public ScrollableElement ScrollableTile { get; set; }
        Army army;

        public UnitSelectorTile(Screen screen, Renderer renderer, Rectangle rect, PlayerInfo info)
        {
            ScrollableTile = new ScrollableElement(screen, renderer, rect);
            army = info.PlayerArmy;
        }
    }
}
