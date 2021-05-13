using GenericStrategyGame.GameTop.ArmyInfo;
using GenericStrategyGame.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.Tiles
{
    class ArmyInfoTile
    {
        public Army SelectedArmy { get { return selectedArmy; } set { selectedArmy = value; updateArmyInfo(); } }
        private Army selectedArmy;
        Rectangle Rect { get; set; }
        RenderableElement background;
        TextElement armyStats;

        public ArmyInfoTile(Screen screen, Renderer renderer, Rectangle rect)
        {
            Rect = rect;
            background = new RenderableElement(screen, renderer, Rect);
            armyStats = new TextElement(screen, renderer, Rect, "Enemy Army Information");
        }
        void updateArmyInfo()
        {
            if (SelectedArmy == null)
            {
                armyStats.Text = "No City Selected";
            }
            else
            {
                armyStats.Text = "Army Information";
            }
        }

    }
}
