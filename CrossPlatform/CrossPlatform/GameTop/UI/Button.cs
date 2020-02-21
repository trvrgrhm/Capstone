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
    class Button : IClickable
    {
        Screen screen;
        HoverableTile hoverableTile;
        UIText text;

        //mouse info
        Func<bool> clickFunction;
        bool previousLeftClick;

        //text info
        public Vector2 textPosition;

        public Rectangle rect;
        public Rectangle Rect { get => rect; set { hoverableTile.Rect = value; rect = value; text.Rect = value; } }


        public Button(Screen screen, Renderer renderer)
        {
            this.screen = screen;
            this.rect = new Rectangle(0, 0, 250, 100);
            this.hoverableTile = new HoverableTile(this.screen, renderer, this.rect);
            this.text = new UIText(this.screen, renderer, this.rect, "");

            this.screen.clickableChildren.Add(this);

            this.textPosition = rect.Location.ToVector2();
            previousLeftClick = false;
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
            this.clickFunction = function;
        }

        public void changeLocation(int x, int y)
        {
            this.Rect = new Rectangle(x, y, Rect.Width, Rect.Height);
        }

        public void onClick()
        {
            clickFunction();
            Console.WriteLine("a button was clicked!");
        }

        public void setText(string text)
        {
            this.text.setText(text);
        }

        public void updateClick(Point mousePosition, bool leftClick)
        {
            if (rect.Contains(mousePosition))
            {
                if (previousLeftClick && !leftClick)
                {
                    onClick();
                }

                previousLeftClick = leftClick;
            }
            else
            {
                previousLeftClick = false;
            }

        }

    }
}
