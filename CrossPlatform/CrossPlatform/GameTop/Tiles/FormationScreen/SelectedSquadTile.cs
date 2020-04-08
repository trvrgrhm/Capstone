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
    class SelectedSquadTile
    {
        public Squad SelectedSquad { get { return selectedSquad; } set { selectedSquad = value; populateWithSquad(value); } }
        private Squad selectedSquad;
        public Unit SelectedUnit { get { return selectedUnit; } set { selectedUnit = value; NewUnitSelected = true; } }
        private Unit selectedUnit;
        public bool NewUnitSelected { get; set; }

        RenderableElement Background { get; set; }
        Button LeaderButton { get; set; }
        RenderableElement LeaderPicture { get; set; }
        Button[] UnitButtonPanel { get; set; }
        RenderableElement[] UnitPictures;

        public SelectedSquadTile(Screen screen, Renderer renderer, Rectangle frame)
        {
            Background = new RenderableElement(screen, renderer, frame);
            Background.Texture = TextureName.MainScreenBackground;

            LeaderButton = new Button(screen, renderer, new Rectangle(frame.X,frame.Y,frame.Width/4,frame.Height));
            UnitButtonPanel = new Button[6];
            int panelButtonWidth = frame.Width / 4;
            int panelButtonHeight = frame.Height / 2;
            for(int i = 0; i < 3; i++)
            {
                int j = 0;
                UnitButtonPanel[i] = new Button(screen, renderer, new Rectangle(i*panelButtonWidth+frame.X+LeaderButton.Rect.Width,j*panelButtonHeight+frame.Y,panelButtonWidth,panelButtonHeight));
                j = 1;
                UnitButtonPanel[i+3] = new Button(screen, renderer, new Rectangle(i * panelButtonWidth + frame.X + LeaderButton.Rect.Width, j * panelButtonHeight + frame.Y, panelButtonWidth, panelButtonHeight));

            }
            LeaderPicture = new RenderableElement(screen, renderer, new Rectangle(LeaderButton.Rect.X, LeaderButton.Rect.Y, LeaderButton.Rect.Width, LeaderButton.Rect.Width));
            LeaderPicture.setVisibility(false);
            LeaderButton.hoverableTile.Highlight = false;
            UnitPictures = new RenderableElement[6];
            for (int i = 0; i < 6; i++)
            {
                int picSide = (panelButtonWidth <= panelButtonHeight) ? panelButtonWidth : panelButtonHeight;
                //center on button
                int picOffsetX = (UnitButtonPanel[i].Rect.Width - picSide) / 2;
                int picOffsetY = (UnitButtonPanel[i].Rect.Height - picSide) / 2;
                UnitPictures[i] = new RenderableElement(screen, renderer, new Rectangle(UnitButtonPanel[i].Rect.X + picOffsetX, UnitButtonPanel[i].Rect.Y + picOffsetY, picSide, picSide));
                UnitPictures[i].setVisibility(false);
                UnitButtonPanel[i].hoverableTile.Highlight = false;
            }
        }

        public void populateWithSquad(Squad squad)
        {
            
                if (squad.units[0] != null)
                {
                    //leader
                    LeaderPicture.Texture = (squad.units[0].Picture);
                    LeaderPicture.setVisibility(true);
                    LeaderButton.hoverableTile.Highlight = true;
                    LeaderButton.clickableElement.setOnClick(()=> { SelectedUnit = squad.units[0]; return true; });
                    //units
                    for (int i = 0; i < squad.MaxSize - 1; i++)
                    {
                        if (squad.units[i + 1] != null)
                        {
                            Unit temp = squad.units[i + 1];
                            UnitPictures[i].Texture = (temp.Picture);
                            UnitPictures[i].setVisibility(true);
                            UnitButtonPanel[i].hoverableTile.Highlight = true;
                            UnitButtonPanel[i].clickableElement.setOnClick(() => { SelectedUnit = temp; return true; });
                        }
                        else
                        {

                            UnitPictures[i].setVisibility(false);
                            UnitButtonPanel[i].hoverableTile.Highlight = false;
                            UnitButtonPanel[i].clickableElement.setOnClick(() => { return true; });
                        }
                        //UnitButtonPanel[i-1].clickableElement
                    }
                }
            else
            {
                //squad is empty
                LeaderPicture.setVisibility(false);
                LeaderButton.hoverableTile.Highlight = false;
                LeaderButton.clickableElement.setOnClick(() => { return true; });
                foreach (RenderableElement picture in UnitPictures)
                {
                    picture.setVisibility(false);
                }
                foreach (Button button in UnitButtonPanel)
                {
                    button.hoverableTile.Highlight = false;
                    button.clickableElement.setOnClick(() => { return true; });
                }
            }
        }

    }
}
