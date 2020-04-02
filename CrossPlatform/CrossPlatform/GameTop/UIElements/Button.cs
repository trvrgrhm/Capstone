using CrossPlatform.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UI
{
    class Button
    {
        Screen screen;
        public HoverableElement hoverableTile;
        TextElement text;
        public ClickableElement clickableElement;

        //mouse info
        

        //text info
        public Vector2 textPosition;

        private Rectangle rect;
        public Rectangle Rect { get => rect; set { hoverableTile.Rect = value; rect = value; text.Rect = value; clickableElement.rect = value; } }


        public Button(Screen screen, Renderer renderer)
        {
            this.screen = screen;
            this.rect = new Rectangle(0, 0, 250, 100);

            this.hoverableTile = new HoverableElement(this.screen, renderer, this.rect);
            this.text = new TextElement(this.screen, renderer, this.rect, "");
            this.clickableElement = new ClickableElement(this.screen, this.rect);

            this.textPosition = rect.Location.ToVector2();
        }
        public Button(Screen screen, Renderer renderer, Rectangle buttonRectangle) : this(screen, renderer)
        {

            this.Rect = buttonRectangle;

        }
        public Button(Screen screen, Renderer renderer, Rectangle buttonRectangle, string text) : this(screen, renderer,buttonRectangle)
        {
            setText(text);
        }

        public void setClick(Func<bool> function)
        {
            this.clickableElement.setOnClick(function);
        }

        public void changeLocation(int x, int y)
        {
            this.Rect = new Rectangle(x, y, Rect.Width, Rect.Height);
        }

        public void setText(string text)
        {
            this.text.setText(text);
        }
        public void changeTexture(TextureName texture)
        {
            hoverableTile.Texture = texture;
        }
        public void changeHoverTexture(TextureName texture)
        {
            hoverableTile.HoverTexture = texture;
        }

    }
}
