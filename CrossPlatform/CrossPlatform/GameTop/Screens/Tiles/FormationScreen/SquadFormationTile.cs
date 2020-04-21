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
        SquadTile[,] buttons;
        public Squad SelectedSquad { get { return selectedSquad; } set { if(selectedSquad != null)changeSelectedSquadBackground(TextureName.Ball); selectedSquad = value; if (selectedSquad != null) changeSelectedSquadBackground(TextureName.BasicButtonHover); NewSquadSelected = true; } }
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
            buttons = new SquadTile[Rows,Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j< Columns; j++)
                {
                    SquadTile leButton = new SquadTile();
                    leButton.button = new DraggableElement(screen, renderer, new Rectangle(i * rowUnit+TileRect.X, j * colUnit+TileRect.Y, rowUnit, colUnit));
                    leButton.button.DragOrigin.setTexture(TextureName.Ball);
                    leButton.button.OriginIcon.setVisibility(false);
                    leButton.button.setCursorVisibility(false);
                    leButton.row = i;
                    leButton.col = j;
                    leButton.button.DragOrigin.clickableElement.setOnClickEndHere(() => { if(SelectedSquad.units[0] != null) swapTiles(leButton.row, leButton.col);});
                    buttons[i, j] = leButton;
                    addSquadTile(i, j);

                }
            }

        }
        public void addSquadTile(int row, int col)
        {
            if (army.squads[row, col].units[0] != null)
            {
                buttons[row, col].button.DragIcon.Texture = army.squads[row, col].units[0].Picture;
                buttons[row, col].button.OriginIcon.Texture = army.squads[row, col].units[0].Picture;
                buttons[row, col].button.OriginIcon.setVisibility(true);
                buttons[row, col].button.setCursorVisibility(true);
            }

            buttons[row, col].button.DragOrigin.clickableElement.setOnClickStartHere(() => { SelectedSquad = army.squads[row, col];/* changeSelectedSquadBackground(TextureName.BasicButtonHover) ;*/ return true; });
        }
        public void removeSquadTile(int row, int col)
        {
            buttons[row, col].button.setCursorVisibility(false);
            buttons[row, col].button.OriginIcon.setVisibility(false);
            buttons[row, col].button.DragOrigin.clickableElement.setOnClickStartHere(null);
        }

        public void changeSelectedSquadBackground(TextureName texture)
        {
            buttons[SelectedSquad.Row, SelectedSquad.Column].button.DragOrigin.setTexture(texture);
        }
        public void swapTiles(int newRow, int newCol)
        {
            changeSelectedSquadBackground(TextureName.Ball);
            Console.WriteLine("attemptint to move squad to " + newRow + ", " + newCol);
            int tempRow = SelectedSquad.Row;
            int tempCol = SelectedSquad.Column;
            //Squad newSquad = army.squads[newRow, newCol];
            removeSquadTile(tempRow, tempCol);
            removeSquadTile(newRow, newCol);
            army.swapSquads(tempRow, tempCol, newRow, newCol);
            addSquadTile(tempRow, tempCol);
            addSquadTile(newRow, newCol);
            SelectedSquad = SelectedSquad;
            //return true;
        }


    }
    class SquadTile
    {
        public DraggableElement button;
        public int row;
        public int col;

    }
}
