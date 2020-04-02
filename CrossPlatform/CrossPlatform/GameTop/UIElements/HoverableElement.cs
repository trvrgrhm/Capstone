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
        

        //hover info
        bool hovering;
        public TextureName HoverTexture { get; set; }

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

            this.Screen.renderableChildren.Add(this);
            this.Screen.hoverableChildren.Add(this);

        }
        

        public void onHover()
        {
            hovering = true;
        }

        //IRenderable
        public Renderer Renderer { get; set; }
        public TextureName Texture { get; set; }
        public Rectangle Rect { get; set; }
        public Screen Screen { get; set; }

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
            //render self
            Renderer.render(Rect, Texture);
            if (hovering)
            {
                Renderer.render(Rect, HoverTexture);
            }
            //renderer.render(rect, texture);
        }

    }
}

