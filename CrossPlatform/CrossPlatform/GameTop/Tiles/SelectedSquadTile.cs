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
        public Squad SelectedSquad { get { return SelectedSquad; } set { selectedSquad = value; populateWithSquad(value); } }
        private Squad selectedSquad;
        RenderableElement Background { get; set; }
        Button LeaderButton { get; set; }
        RenderableElement LeaderPicture { get; set; }
        Button[] UnitButtonPanel { get; set; }
        RenderableElement[] UnitPictures;

        public SelectedSquadTile(Screen screen, Renderer renderer, Rectangle frame)
        {
            Background = new RenderableElement(screen, renderer, frame);

            LeaderButton = new Button(screen, renderer, new Rectangle(frame.X,frame.Y,frame.Width/4,frame.Height));
            UnitButtonPanel = new Button[6];
            int panelButtonWidth = frame.Width / 4;
            int panelButtonHeight = frame.Height / 2;
            for(int i = 0; i < 3; i++)
            {
                int j = 0;
                UnitButtonPanel[i] = new Button(screen, renderer, new Rectangle(j*panelButtonWidth+frame.X+LeaderButton.Rect.Width,i*panelButtonHeight+frame.Y,panelButtonWidth,panelButtonHeight));
                j = 1;
                UnitButtonPanel[i+3] = new Button(screen, renderer, new Rectangle(j * panelButtonWidth + frame.X + LeaderButton.Rect.Width, i * panelButtonHeight + frame.Y, panelButtonWidth, panelButtonHeight));

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
            if(squad.units[0]!= null)
            {
                LeaderPicture.Texture =  (squad.units[0].Picture);
                LeaderPicture.setVisibility(true);
                LeaderButton.hoverableTile.Highlight = true;
            }
            else
            {
                LeaderPicture.setVisibility(false);
                LeaderButton.hoverableTile.Highlight = false;
            }
            for(int i = 0; i < squad.MaxSize-1; i++)
            {
                if (squad.units[i+1] != null)
                {
                    UnitPictures[i].Texture = (squad.units[i + 1].Picture);
                    UnitPictures[i].setVisibility(true);
                    UnitButtonPanel[i].hoverableTile.Highlight = true;
                }
                else
                {

                    UnitPictures[i].setVisibility(false);
                    UnitButtonPanel[i].hoverableTile.Highlight = false;
                }
                //UnitButtonPanel[i-1].clickableElement
            }
        }

    }
}
