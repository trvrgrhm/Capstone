using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Tiles
{
    class BasicTile
    {

        HoverableElement background;
        public BasicTile(Screen screen, Renderer renderer, Rectangle rect)
        {
            background = new HoverableElement(screen, renderer, rect);

        }
    }
}
