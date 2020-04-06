using CrossPlatform.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UI
{
    class RenderableElement : IRenderable
    {
        private bool isVisible;

        //IRenderable
        public TextureName Texture { get; set; }
        public Rectangle Rect { get; set; }
        public Renderer Renderer { get; set; }
        public Screen Screen { get; set; }

        public RenderableElement(Screen screen, Renderer renderer, Rectangle rect)
        {
            this.Screen = screen;
            this.Renderer = renderer;
            this.Rect = rect;

            this.Texture = TextureName.BasicTile;

            this.Screen.renderableChildren.Add(this);
            isVisible = true;
        }
        public RenderableElement(Screen screen, Renderer renderer, Rectangle rect, TextureName texture) : this(screen, renderer, rect)
        {
            this.Texture = texture;
        }

        public void moveToTopLayer()
        {
            this.Screen.renderableChildren.Remove(this);
            this.Screen.renderableTopLayerChildren.Add(this);

        }

        public void setVisibility(bool visible)
        {
            isVisible = visible;
        }

        public void render()
        {
            //only render if visible
            if (isVisible == true)
            {
                Renderer.render(this.Rect, this.Texture);
            }
        }
        public void destroy()
        {
            Screen.renderableChildren.Remove(this);
        }
    }
}
