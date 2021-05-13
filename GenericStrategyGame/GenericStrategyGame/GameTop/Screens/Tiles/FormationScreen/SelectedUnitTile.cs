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
        TextElement Health { get; set; }
        TextElement Attack { get; set; }
        TextElement Range { get; set; }
        Button LevelButton { get; set; }
        TextElement SquadInfo { get; set; }
        public SelectedUnitTile(Screen screen, Renderer renderer, Rectangle rect)
        {
            Rect = rect;
            Tile = new Button(screen, renderer, Rect);

            Rectangle picRect = new Rectangle(rect.X, rect.Y, rect.Width / 4, rect.Height);
            int picSide = (picRect.Width < picRect.Height) ? picRect.Width : picRect.Height;
            UnitPicture = new RenderableElement(screen, renderer, new Rectangle(picRect.X+(picRect.Width-picSide)/2, picRect.Y+(picRect.Height-picSide)/2,picSide,picSide));

            UnitName = new TextElement(screen, renderer, new Rectangle(picRect.X + picRect.Width, picRect.Y, (int)(rect.Width * (3.0 / 8)), picRect.Height / 4), "No Unit Selected");
            Health = new TextElement(screen, renderer, new Rectangle(picRect.X + picRect.Width, picRect.Y+ (int)(picRect.Height*(.25)), (int)(rect.Width * (3.0 / 8)), picRect.Height / 4), "Health:");
            Attack = new TextElement(screen, renderer, new Rectangle(Health.Rect.X + Health.Rect.Width, Health.Rect.Y, Health.Rect.Width, Health.Rect.Height), "Attack:");
            Range = new TextElement(screen, renderer, new Rectangle(Health.Rect.X, Health.Rect.Y + Health.Rect.Height, Health.Rect.Width, Health.Rect.Height), "Range: ");
            LevelButton = new Button(screen, renderer, new Rectangle(Health.Rect.X + Health.Rect.Width, Health.Rect.Y + Health.Rect.Height, Health.Rect.Width, Health.Rect.Height), "Level: ");


            SquadButton = new Button(screen, renderer, new Rectangle(rect.X + rect.Width - (int)(rect.Width *.25), rect.Y + rect.Height - (int)(rect.Height*.2), (int)(rect.Width * .25), (int)(rect.Height * .2)),"Squad");

            SquadButton.Rect = new Rectangle(rect.X + rect.Width - (int)(rect.Width * .25), rect.Y + rect.Height - (int)(rect.Height * .2), (int)(rect.Width * .25), (int)(rect.Height * .2));

            SquadInfo = new TextElement(screen, renderer, new Rectangle(rect.X + UnitPicture.Rect.Width, rect.Y + rect.Height - rect.Height / 5, rect.Width / 2, rect.Height / 5), "No Unit Selected");
            removeUnitFromSquad = false;
            addUnitToSquad = false;
            setUpNewUnit(null);

        }
        public void reset()
        {
            Tile.reset();
            UnitPicture.reset();
            UnitName.reset();
            Health.reset();
            Attack.reset();
            Range.reset();
            LevelButton.reset();
            SquadButton.reset();
            SquadInfo.reset();
        }

        private void setUpNewUnit(Unit unit)
        {
            if (unit == null)
            {
                UnitPicture.setVisibility(false);
                UnitName.Text = "No Unit Selected";

                Health.setText("Health: " );
                Attack.setText("Attack: " );
                Range.setText("Range: ");
                LevelButton.setText("Level: ");
                SquadButton.setVisibility(false);
                SquadInfo.setVisibility(false);
                SquadButton.setClick(() => { Console.WriteLine("no button here..."); return true; });
                LevelButton.setClick(() => { Console.WriteLine("no button here..."); return true; });
            }
            else
            {

                UnitName.Text = unit.Name;
                UnitPicture.Texture = unit.Picture; 
                Health.setText("Health: " + unit.MaxHealth);
                Attack.setText("Attack: " + unit.Attack);
                Range.setText("Range: " + unit.Range);
                LevelButton.setText("Level: "+ unit.Level);
                LevelButton.setClick(() => { unit.Level++; return true; });

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
