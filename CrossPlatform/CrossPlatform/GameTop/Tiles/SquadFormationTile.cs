using CrossPlatform.GameTop.ArmyInfo;
using CrossPlatform.GameTop.UI;
using CrossPlatform.GameTop.UIElements;
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
        DraggableElement[,] buttons;
        public Squad SelectedSquad { get { return selectedSquad; } set { selectedSquad = value; NewSquadSelected = true; } }
        private Squad selectedSquad;
        public bool NewSquadSelected { get; set; }
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
            buttons = new DraggableElement[Rows,Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j< Columns; j++)
                {
                    buttons[i, j] = new DraggableElement(screen, renderer, new Rectangle(i * rowUnit+TileRect.X, j * colUnit+TileRect.Y, rowUnit, colUnit));
                    buttons[i, j].DragOrigin.changeTexture(TextureName.Ball);
                    buttons[i, j].DragIcon.setVisibility(false);
                    if (army.squads[i, j] != null)
                    {
                        addSquadTile(i, j);
                    }
                }
            }

        }
        public void addSquadTile(int row, int col)
        {
            if (army.squads[row, col] != null)
            {
                buttons[row, col].DragIcon.Texture = army.squads[row, col].units[0].Picture;
                buttons[row, col].DragOrigin.clickableElement.setOnClickStart(() => { SelectedSquad = army.squads[row, col]; return true; });
                buttons[row, col].DragIcon.setVisibility(true);
            }
        }
        public void removeSquadTile(int row, int col)
        {
            buttons[row, col].DragIcon.setVisibility(false);
            buttons[row, col].DragOrigin.clickableElement.setOnClickStart(null);
        }


    }
}
