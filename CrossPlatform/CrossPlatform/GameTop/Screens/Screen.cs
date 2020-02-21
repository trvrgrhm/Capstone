using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;
using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CrossPlatform.GameTop
{
    class Screen
    {
        protected ScreenController gameController;
        public List<IRenderable> renderableChildren;
        public List<IMovable> moveableChildren;
        public List<IClickable> clickableChildren;
        public List<IHoverable> hoverableChildren;

        public RenderableTile renderableTile;
        public Rectangle screenSize;

        //mouse info
        
        Point mousePosition;
        bool leftClick;


        public Screen(ScreenController controller, Renderer renderer)
        {
            this.gameController = controller;
            this.Renderer = renderer;

            //children
            renderableChildren = new List<IRenderable>();
            moveableChildren = new List<IMovable>();
            clickableChildren = new List<IClickable>();
            hoverableChildren = new List<IHoverable>();
        }
        virtual public void init(Rectangle screenSize)
        {
            ScreenSize = screenSize;
            //self
            renderableTile = new RenderableTile(this, this.Renderer, this.ScreenSize, TextureName.BasicScreenBackground);
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
                //update hoverable children
                child.updateHover(mousePosition);
            }

        }

        //IRenderable
        protected Renderer renderer;
        public Renderer Renderer { get => renderer; set => renderer = value; }
        public Rectangle ScreenSize { get => screenSize; set => screenSize = value; }


        //call render method of self and all children
        public void render()
        {
            //render self
            //renderer.render(Rect, Texture);
            //render children
            foreach(IRenderable child in renderableChildren)
            {
                child.render();
            }
        }
    }
}
