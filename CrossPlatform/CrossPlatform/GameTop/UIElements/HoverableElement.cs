using CrossPlatform.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UI
{
    class HoverableElement : IRenderable, IHoverable
    {

        private bool isVisible;
        //hover info
        bool hovering;
        public bool Highlight { get; set; }
        public TextureName HoverTexture { get; set; }
        //IRenderable
        public Renderer Renderer { get; set; }
        public TextureName Texture { get; set; }
        public Rectangle Rect { get; set; }
        public Screen Screen { get; set; }


        public HoverableElement(Screen screen, Renderer renderer, Rectangle rect): this(screen, renderer, rect, TextureName.BasicButtonBackground)
        {

        }
        public HoverableElement(Screen screen, Renderer renderer, Rectangle rect, TextureName background)
        {
            this.Renderer = renderer;
            this.Screen = screen;
            this.Rect = rect;

            this.Texture = background;
            this.HoverTexture = TextureName.BasicButtonHover;
            hovering = false;
            Highlight = true;

            this.Screen.renderableChildren.Add(this);
            this.Screen.hoverableChildren.Add(this);
            isVisible = true;

        }
        

        public void onHover()
        {
            hovering = true;
        }
        public bool isHovering()
        {
            return hovering;
        }
        public void setVisibility(bool visible)
        {
            isVisible = visible;
        }
        public bool getVisibility()
        {
            return isVisible;
        }

        
        public void updateHover(Point mousePosition)
        {
            if (Rect.Contains(mousePosition))
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
            //only render if visible
            if (isVisible)
            {
                //render self
                Renderer.render(Rect, Texture);
                if (hovering && Highlight)
                {
                    Renderer.render(Rect, HoverTexture);
                }
            }
        }
        public void destroy()
        {
            Screen.renderableChildren.Remove(this);
            Screen.hoverableChildren.Remove(this);
        }

    }
}

