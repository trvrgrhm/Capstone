using CrossPlatform.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UI
{
    class TextElement : IRenderable
    {
        Screen screen;
        Vector2 position;
        string text;
        public TextElement(Screen screen, Renderer renderer, Rectangle rect, string text)
        {
            this.Screen = screen;
            this.Renderer = renderer;
            this.Rect = rect;
            this.Text = text;
            this.Screen.renderableChildren.Add(this);

        }

        public void setText(string text)
        {
            this.Text = text;
        }

        private Renderer renderer;
        private Rectangle rect;
        private TextureName texture;
        public Renderer Renderer { get => renderer; set => renderer = value; }
        public TextureName Texture { get => texture; set => texture = value; }
        public Rectangle Rect { get => rect; set { rect = value;position = new Vector2(value.Location.X + value.Width / 2, value.Location.Y + value.Height / 2); } }
        public Screen Screen { get => screen; set => screen = value; }

        public Vector2 Position { get => position; set => position = value; }
        public string Text { get => text; set => text = value; }

        public void render()
        {
            renderer.render(Position, Text);
        }
    }
}
