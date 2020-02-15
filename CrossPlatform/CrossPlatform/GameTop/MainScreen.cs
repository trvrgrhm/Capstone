using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;
using Microsoft.Xna.Framework;

namespace CrossPlatform.GameTop
{
    class MainScreen : IScreen, IRenderable
    {
        private Renderer renderer;
        private TextureName texture;
        private List<IRenderable> renderableChildren;
        private List<IMovable> moveableChildren;

        //for testing
        private Rectangle ballRect = new Rectangle(0, 0, 50, 100);


        public MainScreen(Renderer renderer)
        {
            this.renderer = renderer;
        }
        public void init()
        {
            //self
            this.texture = TextureName.MainScreenBackground;
            rect = new Rectangle(0, 0, 800, 600);
            //children
            renderableChildren = new List<IRenderable>();
            moveableChildren = new List<IMovable>();


        }

        //call update on self and all children
        public void update()
        {
            foreach(IMovable child in moveableChildren)
            {
                child.move();
            }
            ballRect.X += 1;
            ballRect.Y += 1;

        }

        //IRenderable
        public Rectangle rect {get; set;}

        //call render method of self and all children
        public void render()
        {
            renderer.render(rect, texture);
            foreach(IRenderable child in renderableChildren)
            {
                child.render();
            }
            renderer.render(ballRect , TextureName.Ball);
        }
    }
}
