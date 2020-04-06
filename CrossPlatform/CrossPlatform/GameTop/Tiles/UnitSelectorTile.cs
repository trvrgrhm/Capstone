using CrossPlatform.GameTop.ArmyInfo;
using CrossPlatform.GameTop.Interfaces;
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
    class UnitSelectorTile: IUpdatable
    {
        Screen Screen { get; set; }
        Renderer Renderer { get; set; }
        Rectangle Rect { get { return rect; } set { updateButtonPositions(value.Y - rect.Y); rect = value;   } }
        Rectangle rect;
        public ScrollableElement ScrollableTile { get; set; }
        public Unit SelectedUnit { get { return selectedUnit; } set { selectedUnit = value; NewUnitSelected = true;  } }
        private Unit selectedUnit;
        public bool NewUnitSelected { get; set; }
        List<Unit> DisplayableUnits { get; set; }
        List<Button> buttons;
        Army army;
        private bool needToUpdate;
        private int buttonSideSize;
        public bool unitTilesReset;

        public UnitSelectorTile(Screen screen, Renderer renderer, Rectangle rect, PlayerInfo info)
        {
            Screen = screen;
            Renderer = renderer;
            ScrollableTile = new ScrollableElement(screen, renderer, rect);
            army = info.PlayerArmy;
            buttons = new List<Button>();
            Rect = rect;
            buttonSideSize = Rect.Width / 4;
            unitTilesReset = false;
            initUnits();



            needToUpdate = true;
            Screen.updatableChildren.Add(this);
        }

        private void initUnits()
        {
            DisplayableUnits = new List<Unit>();
            List<Unit> unitsInSquads = new List<Unit>();
            foreach(Squad squad in army.squads)
            {
                if (squad != null)
                {
                    foreach (Unit unit in squad.units)
                    {
                        unitsInSquads.Add(unit);
                    }
                }

            }
            DisplayableUnits = army.units.Except(unitsInSquads).ToList();
        }

        public void addUnitToTile(Unit unit)
        {
            DisplayableUnits.Add(unit);
            needToUpdate = true;
        }
        public void removeUnitFromTile(Unit unit)
        {
            DisplayableUnits.Remove(unit);
            needToUpdate = true;
        }

        public void updateButtons()
        {
            foreach(Button button in buttons)
            {
                button.destroy();
            }
            buttons.Clear();
            int i = 0;
            int j = 0;
            foreach(Unit unit in DisplayableUnits)
            {

                Button temp = new Button(Screen, Renderer, new Rectangle((i*buttonSideSize)+this.Rect.X, (j * buttonSideSize) + this.Rect.Y,buttonSideSize,buttonSideSize));
                //temp.DragOrigin.changeTexture(unit.Picture);
                temp.setIconTexture(unit.Picture);
                temp.setIconVisibility(true);
                temp.clickableElement.setOnClickStartHere(() => { SelectedUnit = unit; return true; });
                //temp.setOnDragRelease(() => { SelectedUnit = unit; return true; });
                buttons.Add(temp);
                ScrollableTile.changeScrollingHeight((j+1)* buttonSideSize);
                i++;
                if(i % 4 == 0)
                {
                    i = 0;
                    j++;
                }
            }
            unitTilesReset = true;
        }
        public void updateButtonPositions(int howMuch)
        {
            foreach (Button button in buttons)
            {
                button.changeLocation(button.Rect.X, button.Rect.Y + howMuch);
            }
        }

        public void update()
        {
            if (needToUpdate)
            {
                //update
                updateButtons();
                needToUpdate = false;
            }
            if (Rect.Y != ScrollableTile.ScrollingFrame.Rect.Y)
            {
                this.Rect = ScrollableTile.ScrollingFrame.Rect;
            }
            
        }
        public void destroy()
        {
            Screen.updatableChildren.Remove(this);
            ScrollableTile.destroy();
        }

        
    }
}
