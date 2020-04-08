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
    class SelectedUnitTile
    {
        public Unit SelectedUnit { get { return selectedUnit; } set { selectedUnit = value; setUpNewUnit(value); } }
        private Unit selectedUnit;

        //army screen functionality
        public bool removeUnitFromSquad;
        public bool addUnitToSquad;

        public Rectangle Rect { get; set; }

        Button Tile { get; set; }
        Button SquadButton { get; set; }
        RenderableElement UnitPicture { get; set; }
        TextElement UnitName { get; set; }
        TextElement SquadInfo { get; set; }
        public SelectedUnitTile(Screen screen, Renderer renderer, Rectangle rect)
        {
            Rect = rect;
            Tile = new Button(screen, renderer, Rect);

            Rectangle picRect = new Rectangle(rect.X, rect.Y, rect.Width / 4, rect.Height);
            int picSide = (picRect.Width < picRect.Height) ? picRect.Width : picRect.Height;
            UnitPicture = new RenderableElement(screen, renderer, new Rectangle(picRect.X+(picRect.Width-picSide)/2, picRect.Y+(picRect.Height-picSide)/2,picSide,picSide));

            UnitName = new TextElement(screen, renderer, rect, "No Unit Selected");

            SquadButton = new Button(screen, renderer, new Rectangle(rect.X + rect.Width - (int)(rect.Width *.25), rect.Y + rect.Height - (int)(rect.Height*.2), (int)(rect.Width * .25), (int)(rect.Height * .2)),"Squad");

            SquadButton.Rect = new Rectangle(rect.X + rect.Width - (int)(rect.Width * .25), rect.Y + rect.Height - (int)(rect.Height * .2), (int)(rect.Width * .25), (int)(rect.Height * .2));

            SquadInfo = new TextElement(screen, renderer, new Rectangle(rect.X + UnitPicture.Rect.Width, rect.Y + rect.Height - rect.Height / 5, rect.Width / 2, rect.Height / 5), "No Unit Selected");
            removeUnitFromSquad = false;
            addUnitToSquad = false;
            setUpNewUnit(null);

        }
        public SelectedUnitTile(SelectedUnitTile tile)
        {
            
            SelectedUnit = tile.SelectedUnit;
        }
        public void reset()
        {
            Tile.reset();
            UnitPicture.reset();
            UnitName.reset();
            SquadButton.reset();
            SquadInfo.reset();
        }

        private void setUpNewUnit(Unit unit)
        {
            if (unit == null)
            {
                UnitPicture.setVisibility(false);
                UnitName.Text = "No Unit Selected";
                SquadButton.setVisibility(false);
                SquadInfo.setVisibility(false);
                SquadButton.setClick(() => { Console.WriteLine("no button here..."); return true; });
            }
            else
            {
                UnitPicture.Texture = unit.Picture;
                UnitPicture.setVisibility(true);
                if (unit.IsInSquad)
                {
                    SquadInfo.setText("Currently in Squad");
                    SquadButton.setText("Remove");
                    SquadButton.setClick(() => { Console.WriteLine("remove unit button clicked"); removeUnitFromSquad = true; return true; });
                }
                else
                {
                    SquadInfo.setText("Not in Squad");
                    SquadButton.setText("Add");
                    SquadButton.setClick(() => { Console.WriteLine("add unit button clicked"); addUnitToSquad = true; return true; });
                }
                SquadButton.setVisibility(true);
                SquadButton.hoverableTile.Highlight = true;
                SquadInfo.setVisibility(true);
            }
        }
        public void destroy()
        {
            Tile.destroy();
            SquadButton.destroy();
            UnitPicture.destroy();
            UnitName.destroy();
            SquadInfo.destroy();
        }


    }
}
