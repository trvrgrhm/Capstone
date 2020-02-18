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
    class Button : IRenderable, IClickable, IHoverable
    {
        //mouse info
        Func<bool> clickFunction;
        bool previousLeftClick;

        //hover info
        bool hovering;
        TextureName hoverTexture;

        //text info
        bool hasText;
        string buttonText;
        public Vector2 textPosition;



        public Button(Renderer renderer, Rectangle buttonRectangle)
        {
            this.renderer = renderer;
            this.rect = buttonRectangle;

            this.texture = TextureName.BasicButtonBackground;
            this.hoverTexture = TextureName.BasicButtonHover;
            this.textPosition = rect.Location.ToVector2();
            previousLeftClick = false;
            hovering = false;
            hasText = false;
        }
        public Button(Renderer renderer, Rectangle buttonRectangle, string text) : this(renderer,buttonRectangle)
        {
            setText(text);
            hasText = true;
        }

        public void onHover()
        {
            hovering = true;
        }

        public void setClick(Func<bool> function)
        {
            this.clickFunction = function;
        }

        public void onClick()
        {
            clickFunction();
            Console.WriteLine("a button was clicked!");
        }

        public void setText(string text)
        {
            buttonText = text;
            hasText = true;
        }


        //IRenderable
        public Renderer renderer;
        public Renderer Renderer { get; set; }
        private TextureName texture;
        public TextureName Texture { get; set; } //{ get { return texture; } set { texture = value; }}
        public Rectangle rect;
        public Rectangle Rect { get; set; }

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
        }
        public void updateHover(Point mousePosition)
        {
            if (rect.Contains(mousePosition))
            {
                onHover();
            }
            else
            {
                hovering = false;
            }
        }

        public void render()
        {
            //render self
            renderer.render(rect, texture);
            if (hovering)
            {
                renderer.render(rect, hoverTexture);
            }
            if (hasText)
            {
                renderer.render(textPosition, buttonText);
            }
            //renderer.render(rect, texture);
        }

    }
}
