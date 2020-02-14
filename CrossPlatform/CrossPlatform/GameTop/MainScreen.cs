using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;

namespace CrossPlatform.GameTop
{
    class MainScreen : IScreen, IRenderable
    {
        private Renderer renderer;
        private TextureType texture;

        public MainScreen(Renderer renderer)
        {
            this.renderer = renderer;
        }
        public void init ()
        {
            this.X = 0;
            this.Y = 0;
            this.texture = TextureType.MainScreenBackground;
        }

        public void update()
        {
            render();
        }

        //IRenderable
        public float X { get; set; }
        public float Y { get; set; }

        public void render()
        {
            renderer.render(X, Y, texture);
            renderer.render(0, 0, TextureType.Ball);
        }
    }
}
