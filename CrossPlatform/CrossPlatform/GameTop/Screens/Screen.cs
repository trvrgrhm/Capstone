using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;
using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CrossPlatform.GameTop
{
    class Screen
    {
        protected ScreenController gameController;
        public List<IRenderable> renderableChildren;
        public List<IRenderable> renderableTopLayerChildren;
        public List<IMovable> moveableChildren;
        public List<IClickable> clickableChildren;
        public List<IHoverable> hoverableChildren;
        public List<IScrollable> scrollableChildren;
        public List<IUpdatable> updatableChildren;

        public PlayerInfo playerInfo { get; set; }

        public RenderableElement background;
        public Rectangle screenSize;

        public Renderer Renderer { get; set; }
        public SoundController soundController { get; set; }
        public Rectangle ScreenSize { get => screenSize; set => screenSize = value; }


        //public Song backgroundMusic;
        public bool playClickSound;

        //mouse info

        public Point mousePosition;
        bool leftClick;
        int scrollValue;
        public bool dragStarted;


        public Screen(ScreenController controller, Renderer renderer, SoundController soundController, PlayerInfo playerInfo)
        {
            this.gameController = controller;
            this.Renderer = renderer;
            this.playerInfo = playerInfo;
            this.soundController = soundController;

            //children
            renderableChildren = new List<IRenderable>();
            renderableTopLayerChildren = new List<IRenderable>();
            moveableChildren = new List<IMovable>();
            clickableChildren = new List<IClickable>();
            hoverableChildren = new List<IHoverable>();
            scrollableChildren = new List<IScrollable>();
            updatableChildren = new List<IUpdatable>();
        }
        virtual public void init(Rectangle screenSize)
        {
            ScreenSize = screenSize;
            //self
            background = new RenderableElement(this, this.Renderer, this.ScreenSize, TextureName.BasicScreenBackground);

            dragStarted = false;
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
            scrollValue = Mouse.GetState().ScrollWheelValue;
            foreach (IClickable child in clickableChildren)
            {
                //update clickable children
                //if (leftClick)
                //{
                    //if (!dragStarted)
                    //{
                    //    dragStarted = true;
                    //}
                //}
                child.updateClick(mousePosition, leftClick, dragStarted);
            }
            if (!leftClick)
            {
                dragStarted = false;
            }
            foreach (IHoverable child in hoverableChildren)
            {
                //update hoverable children
                child.updateHover(mousePosition);
            }
            foreach(IScrollable child in scrollableChildren)
            {
                //update scrollable children
                child.updateScroll(scrollValue);
            }
            foreach(IUpdatable child in updatableChildren)
            {
                child.update();
            }
            if (playClickSound)
            {
                soundController.playSound("clickSound");

                playClickSound = false;
            }

        }

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
            foreach(IRenderable child in renderableTopLayerChildren)
            {
                child.render();
            }
        }
    }
}
