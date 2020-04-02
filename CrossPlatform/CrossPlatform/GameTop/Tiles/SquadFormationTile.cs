using CrossPlatform.GameTop.ArmyInfo;
using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Tiles
{
    class SquadFormationTile
    {
        Button[,] buttons;
        Army army;
        Rectangle TileRect { get; set; }
        public int Rows { get { return rows; } set { rows = value; rowUnit = TileRect.Width/ rows; } }
        public int Columns { get { return columns; } set { columns = value; colUnit = TileRect.Height / columns; } }
        int rows;
        int columns;
        int rowUnit;
        int colUnit;
        public SquadFormationTile(Screen screen, Renderer renderer, Rectangle rect, PlayerInfo info)
        {
            TileRect = rect;
            army = info.PlayerArmy;
            Rows = army.squads.GetLength(0);
            Columns = army.squads.GetLength(1);
            buttons = new Button[Rows,Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j< Columns; j++)
                {
                    buttons[i, j] = new Button(screen, renderer, new Rectangle(i * rowUnit+TileRect.X, j * colUnit+TileRect.Y, rowUnit, colUnit));
                    buttons[i, j].changeTexture(TextureName.Ball);
                    if (army.squads[i, j] != null)
                    {
                        buttons[i, j].changeTexture(TextureName.BasicDude);
                    }
                }
            }

        }


    }
}
