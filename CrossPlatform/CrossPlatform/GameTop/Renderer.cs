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
        Dictionary<FontName, SpriteFont> fontMap;
        SpriteBatch spriteBatch;
        ContentManager content;
        List<RenderObject> renderObjects;
        

        public void init(SpriteBatch spriteBatch, ContentManager content) {
            this.spriteBatch = spriteBatch;
            this.content = content;
            textureMap = new Dictionary<TextureName, Texture2D>();
            fontMap = new Dictionary<FontName, SpriteFont>();
            renderObjects = new List<RenderObject>();
        }
        public void loadContent()
        {
            //for testing
            textureMap.Add(TextureName.Ball, content.Load<Texture2D>("ball"));


            textureMap.Add(TextureName.BasicButtonBackground, content.Load<Texture2D>("rounded_box_brown"));
            textureMap.Add(TextureName.BasicButtonHover, content.Load<Texture2D>("rounded_box_red_faded"));
            textureMap.Add(TextureName.MainScreenBackground, content.Load<Texture2D>("disgusted miku"));
            textureMap.Add(TextureName.BasicScreenBackground, content.Load<Texture2D>("ds-background"));

            fontMap.Add(FontName.Arial12, content.Load<SpriteFont>("arial_12"));
            fontMap.Add(FontName.Arial16, content.Load<SpriteFont>("arial_16"));
        }

        public void render(float X, float Y, TextureName texture)
        {
            renderObjects.Add(new RenderObject(X, Y, texture));
        }
        public void render(Rectangle rect, TextureName texture)
        {
            renderObjects.Add(new RenderObject(rect, texture));
        }
        public void render(Vector2 position, string text)
        {
            renderObjects.Add(new RenderObject(position, text));
        }
        public void render(FontName font, Vector2 position, string text, Color color)
        {
            renderObjects.Add(new RenderObject(font, position, text, color));
        }

        public void draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (RenderObject item in renderObjects)
            {
                if (item.containsRectangle)
                {
                    spriteBatch.Draw(textureMap[item.texture], item.rect, item.color);
                }
                else if (item.isText)
                {
                    spriteBatch.DrawString(fontMap[item.font], item.text, item.position, item.color);
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

            public Vector2 position { get; set; }
            public bool isText { get; set; }
            public string text { get; set; }
            public FontName font { get; set; }
            public bool containsFont { get; set; }

            public Color color { get; set; }

            public RenderObject(float x, float y, TextureName texture)
            {
                X = x;
                Y = y;
                this.color = Color.White;
                this.texture = texture;
                containsRectangle = false;

                isText = false;
            }
            public RenderObject (Rectangle rect, TextureName texture)
            {
                this.rect = rect;
                this.texture = texture;
                this.color = Color.White;
                containsRectangle = true;

                isText = false;
            }
            public RenderObject(FontName font, Vector2 position, string text, Color color)
            {
                this.position = position;
                this.text = text;
                this.color = color;
                containsFont = true;
                isText = true;
                containsRectangle = false;
            }
            public RenderObject(Vector2 position, string text) 
            {
                this.position = position;
                this.text = text;
                this.color = Color.White;
                font = FontName.Arial16;
                containsFont = false;
                isText = true;
                containsRectangle = false;
            }
        }

    }
    



    public enum TextureName
    {
        //for testing
        Ball,

        BasicScreenBackground,
        MainScreenBackground,
        BasicButtonBackground,
        BasicButtonHover,
    }
    public enum FontName
    {
        Arial12,
        Arial16,
    }
}


