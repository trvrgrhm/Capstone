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
        
        public RenderableElement(Screen screen, Renderer renderer, Rectangle rect)
        {
            this.Screen = screen;
            this.Renderer = renderer;
            this.Rect = rect;

            this.Texture = TextureName.BasicTile;

            this.screen.renderableChildren.Add(this);
        }
        public RenderableElement(Screen screen, Renderer renderer, Rectangle rect, TextureName texture) : this (screen, renderer, rect)
        {
            this.Texture = texture;
        }

        //IRenderable
        private Renderer renderer;
        private TextureName texture;
        private Rectangle rect;
        private Screen screen;
        public TextureName Texture { get => texture; set => texture = value; }
        public Rectangle Rect { get => rect; set => rect = value; }
        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Screen Screen { get => screen; set => screen = value; }

        public void render()
        {
            Renderer.render(this.Rect, this.Texture);
        }
    }
}
