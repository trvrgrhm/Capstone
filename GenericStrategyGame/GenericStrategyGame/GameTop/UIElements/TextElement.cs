using GenericStrategyGame.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.UI
{
    class TextElement : IRenderable
    {

        public Renderer Renderer { get; set; }
        public Rectangle Rect { get => rect; set { rect = value; Position = new Vector2(value.Location.X + value.Width / 2, value.Location.Y + value.Height / 2); } }
        private Rectangle rect;
        public Screen Screen { get; set; }
        public Vector2 Position { get; set; }
        public string Text { get; set; }
        bool isVisible;

        public TextElement(Screen screen, Renderer renderer, Rectangle rect, string text)
        {
            this.Screen = screen;
            this.Renderer = renderer;
            this.Rect = rect;
            this.Text = text;
            this.Screen.renderableChildren.Add(this);
            isVisible = true;
        }

        public void setText(string text)
        {
            this.Text = text;
        }

        
        public void setVisibility(bool visible)
        {
            isVisible = visible;
        }

        public void render()
        {
            if (isVisible)
            {
                Renderer.render(Position, Text);
            }
        }
        public void reset()
        {
            Screen.renderableChildren.Remove(this);
            Screen.renderableChildren.Add(this);
        }
        public void destroy()
        {
            Screen.renderableChildren.Remove(this);
        }
    }
}
