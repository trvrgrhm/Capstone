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
        Dictionary<TextureName, Texture2D> textureMap;
        SpriteBatch spriteBatch;
        ContentManager content;
        List<RenderObject> renderObjects;
        

        public void init(SpriteBatch spriteBatch, ContentManager content) {
            this.spriteBatch = spriteBatch;
            this.content = content;
            textureMap = new Dictionary<TextureName, Texture2D>();
            renderObjects = new List<RenderObject>();
        }
        public void loadContent()
        {
            textureMap.Add(TextureName.Ball, content.Load<Texture2D>("ball"));
            textureMap.Add(TextureName.MainScreenBackground, content.Load<Texture2D>("disgusted miku"));
        }

        public void render(float X, float Y, TextureName texture)
        {
            renderObjects.Add(new RenderObject(X, Y, texture));
        }
        public void render(Rectangle rect, TextureName texture)
        {
            renderObjects.Add(new RenderObject(rect,texture));
        }

        public void draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (RenderObject item in renderObjects)
            {
                if (item.containsRectangle)
                {
                    spriteBatch.Draw(textureMap[item.texture], item.rect, Color.White);
                }
                else {
                    spriteBatch.Draw(textureMap[item.texture], new Vector2(item.X, item.Y), Color.White);
                }
            }
            renderObjects.Clear();

            //spriteBatch.Draw(ballTexture, new Vector2(0, 0), Color.White);

            spriteBatch.End();
        }


        private class RenderObject
        {
            public float X { get; set; }
            public float Y { get; set; }
            public TextureName texture { get; set; }
            public Rectangle rect { get; set; }
            public bool containsRectangle { get; set; }

            public RenderObject(float x, float y, TextureName texture)
            {
                X = x;
                Y = y;
                this.texture = texture;
                containsRectangle = false;
            }
            public RenderObject (Rectangle rect, TextureName texture)
            {
                this.rect = rect;
                this.texture = texture;
                containsRectangle = true;
            }
        }

    }
    



    public enum TextureName
    {
        MainScreenBackground,
        Ball
    }
}


