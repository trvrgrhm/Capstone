using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop
{
    class Renderer
    {
        Dictionary<TextureType, Texture2D> textureMap;
        SpriteBatch spriteBatch;
        ContentManager content;
        List<RenderObject> renderObjects;
        

        public void init(SpriteBatch spriteBatch, ContentManager content) {
            this.spriteBatch = spriteBatch;
            this.content = content;
            textureMap = new Dictionary<TextureType, Texture2D>();
            renderObjects = new List<RenderObject>();
        }
        public void loadContent()
        {
            textureMap.Add(TextureType.Ball, content.Load<Texture2D>("ball"));
            textureMap.Add(TextureType.MainScreenBackground, content.Load<Texture2D>("disgusted miku"));
        }

        public void render(float X, float Y, TextureType texture)
        {
            renderObjects.Add(new RenderObject(X, Y, texture));
        }

        public void draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (RenderObject item in renderObjects)
            {
                spriteBatch.Draw(textureMap[item.texture], new Vector2(item.X, item.Y), Color.White);
            }
            renderObjects.Clear();

            //spriteBatch.Draw(ballTexture, new Vector2(0, 0), Color.White);

            spriteBatch.End();
        }


        private class RenderObject
        {
            public float X { get; set; }
            public float Y { get; set; }
            public TextureType texture { get; set; }

            public RenderObject(float x, float y, TextureType texture)
            {
                X = x;
                Y = y;
                this.texture = texture;
            }
        }

    }
    



    public enum TextureType
    {
        MainScreenBackground,
        Ball
    }
}


