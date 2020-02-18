using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrossPlatform.GameTop
{
    class Screen : IRenderable
    {
        protected GameController gameController;
        protected List<IRenderable> renderableChildren;
        protected List<IMovable> moveableChildren;
        protected List<IClickable> clickableChildren;
        protected List<IHoverable> hoverableChildren;

        //mouse info
        
        Point mousePosition;
        bool leftClick;


        public Screen(GameController controller, Renderer renderer)
        {
            this.gameController = controller;
            this.renderer = renderer;
        }
        virtual public void init()
        {
            //self
            this.texture = TextureName.BasicScreenBackground;
            rect = new Rectangle(0, 0, 800, 600);
            //children
            renderableChildren = new List<IRenderable>();
            moveableChildren = new List<IMovable>();
            clickableChildren = new List<IClickable>();
            hoverableChildren = new List<IHoverable>();


        }

        //call update on self and all children
        virtual public void update()
        {
            //update self?

            foreach (IMovable child in moveableChildren)
            {
                //update moveable children
                child.move();
            }
            mousePosition = Mouse.GetState().Position.ToVector2().ToPoint();
            leftClick = Mouse.GetState().LeftButton==ButtonState.Pressed;
            foreach (IClickable child in clickableChildren)
            {
                //update clickable children
                child.updateClick(mousePosition, leftClick);
            }
            foreach (IHoverable child in hoverableChildren)
            {
                child.updateHover(mousePosition);
            }

        }

        //IRenderable

        public Renderer renderer;
        public Renderer Renderer { get; set; }

        public TextureName texture; 
        public TextureName Texture { get; set; }

        public Rectangle rect;
        public Rectangle Rect {get; set;}

        //call render method of self and all children
        public void render()
        {
            //render self
            renderer.render(rect, texture);
            //render children
            foreach(IRenderable child in renderableChildren)
            {
                child.render();
            }
        }
    }
}
