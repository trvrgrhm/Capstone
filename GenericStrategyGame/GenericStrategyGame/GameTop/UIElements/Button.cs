using GenericStrategyGame.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.UI
{
    class Button
    {
        Screen screen;
        Renderer renderer { get; set; }
        public HoverableElement hoverableTile;
        TextElement text;
        public ClickableElement clickableElement;
        RenderableElement icon;
        bool iconVisible;

        bool clickSoundActive = true;
                

        //text info
        public Vector2 textPosition;

        private Rectangle rect;
        public Rectangle Rect { get => rect; set { hoverableTile.Rect = value; rect = value; text.Rect = value; clickableElement.rect = value; icon.Rect = value; } }
        private bool isVisible;


        public Button(Screen screen, Renderer renderer)
        {
            this.screen = screen;
            this.rect = new Rectangle(0, 0, screen.ScreenSize.Width/20, screen.ScreenSize.Height/20);
            this.renderer = renderer;

            this.hoverableTile = new HoverableElement(this.screen, renderer, Rect);
            this.text = new TextElement(this.screen, renderer, Rect, "");
            this.clickableElement = new ClickableElement(this.screen, Rect);
            icon = new RenderableElement(this.screen, renderer, Rect);
            icon.setVisibility(false);

            this.textPosition = rect.Location.ToVector2();
        }
        public Button(Screen screen, Renderer renderer, Rectangle buttonRectangle) : this(screen, renderer)
        {

            Rect = buttonRectangle;

        }
        public Button(Screen screen, Renderer renderer, Rectangle buttonRectangle, string text) : this(screen, renderer,buttonRectangle)
        {
            setText(text);
        }

        public void setClick(Func<bool> function)
        {
            this.clickableElement.setOnClick(() => { if (clickSoundActive) { screen.playClickSound = true; } return function(); }) ;
        }

        public void changeLocation(int x, int y)
        {
            this.Rect = new Rectangle(x, y, Rect.Width, Rect.Height);
        }

        public void setText(string text)
        {
            this.text.setText(text);
        }
        public void setTexture(TextureName texture)
        {
            hoverableTile.Texture = texture;
        }
        public void setHoverTexture(TextureName texture)
        {
            hoverableTile.HoverTexture = texture;
        }
        public void setIconTexture(TextureName texture)
        {
            icon.Texture = texture;
        }
        public void setIconVisibility(bool visible)
        {
            iconVisible = visible;
            icon.setVisibility(visible);
        }
        public void setVisibility(bool visible)
        {
            hoverableTile.setVisibility(visible);
            text.setVisibility(visible);
            if(iconVisible)
            icon.setVisibility(visible);
            isVisible = visible;
        }
        public bool getVisibility()
        {
            return isVisible;
        }
        public void reset()
        {
            hoverableTile.reset();
            clickableElement.reset();
            icon.reset();
            text.reset();
        }
        public void destroy()
        {
            hoverableTile.destroy();
            clickableElement.destroy();
            icon.destroy();
            text.destroy();
        }

    }
}
