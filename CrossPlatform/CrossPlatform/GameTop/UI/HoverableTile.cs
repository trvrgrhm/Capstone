﻿using CrossPlatform.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UI
{
    class HoverableTile : IRenderable, IHoverable
    {
        

        //hover info
        bool hovering;
        TextureName hoverTexture;

        public HoverableTile(Screen screen, Renderer renderer, Rectangle buttonRectangle)
        {
            this.Renderer = renderer;
            this.Screen = screen;
            this.Rect = buttonRectangle;

            this.Texture = TextureName.BasicButtonBackground;
            this.hoverTexture = TextureName.BasicButtonHover;
            hovering = false;

            this.Screen.renderableChildren.Add(this);
            this.Screen.hoverableChildren.Add(this);
        }
        

        public void onHover()
        {
            hovering = true;
        }

        //IRenderable
        Screen screen;
        public Rectangle rect;
        public Renderer renderer;

        private TextureName texture;

        public Renderer Renderer { get => renderer; set => renderer = value; }
        public TextureName Texture { get => texture; set => texture = value; } //{ get { return texture; } set { texture = value; }}
        
        public Rectangle Rect { get => rect; set => rect = value; }
        public Screen Screen { get => screen; set => screen = value; }

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
            //renderer.render(rect, texture);
        }

    }
}

