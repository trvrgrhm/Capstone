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
            textureMap.Add(TextureName.BasicDude, content.Load<Texture2D>("Idle_000"));
            textureMap.Add(TextureName.BasicTile,content.Load<Texture2D>("box_brown"));
            textureMap.Add(TextureName.BasicButtonBackground, content.Load<Texture2D>("rounded_box_brown"));
            textureMap.Add(TextureName.BasicButtonHover, content.Load<Texture2D>("rounded_box_red_faded"));
            textureMap.Add(TextureName.MainScreenBackground, content.Load<Texture2D>("disgusted miku"));
            textureMap.Add(TextureName.BasicScreenBackground, content.Load<Texture2D>("box_tan"));
            textureMap.Add(TextureName.BackButton, content.Load<Texture2D>("ball"));

            fontMap.Add(FontName.Arial12, content.Load<SpriteFont>("arial_12"));
            fontMap.Add(FontName.Arial16, content.Load<SpriteFont>("arial_16"));
        }

        public void render(float X, float Y, TextureName texture)
        {
            renderObjects.Add(new RenderObject(X, Y, texture));
            //spriteBatch.Draw(textureMap[texture], new Vector2((int)X, (int)Y), Color.White);
        }
        public void render(Rectangle rect, TextureName texture)
        {
            renderObjects.Add(new RenderObject(rect, texture));
            //spriteBatch.Draw(textureMap[texture], rect, Color.White);
        }
        public void render(Vector2 position, string text)
        {
            renderObjects.Add(new RenderObject(position, text));
            //spriteBatch.DrawString(fontMap[FontName.Arial16], text, position, Color.White);
        }
        public void render(FontName font, Vector2 position, string text, Color color)
        {
            renderObjects.Add(new RenderObject(font, position, text, color));
            //spriteBatch.DrawString(fontMap[font], text, position, color);
        }


        public void draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            foreach (RenderObject item in renderObjects)
            {
                if (item.ContainsRectangle)
                {
                    spriteBatch.Draw(textureMap[item.Texture], item.Rect, item.Color);
                }
                else if (item.IsText)
                {
                    
                    spriteBatch.DrawString(fontMap[item.Font], item.Text, item.Position - new Vector2(fontMap[item.Font].MeasureString(item.Text).X/2, fontMap[item.Font].MeasureString(item.Text).Y/2), item.Color) ;
                }
                else {
                    spriteBatch.Draw(textureMap[item.Texture], new Vector2(item.X, item.Y), Color.White);
                }
            }
            renderObjects.Clear();

            //spriteBatch.Draw(ballTexture, new Vector2(0, 0), Color.White);

            spriteBatch.End();
        }


        private class RenderObject
        {
            private float x;
            private float y;
            private TextureName texture;
            private Rectangle rect;
            private bool containsRectangle;

            private Vector2 position;
            private bool isText;
            private string text;
            private FontName font;
            private bool containsFont;

            public Color Color;
            public float X { get => x; set => x = value; }
            public float Y { get => y; set => y = value; }
            public TextureName Texture { get => texture; set => texture = value; }
            public Rectangle Rect { get => rect; set => rect = value; }
            public bool ContainsRectangle { get => containsRectangle; set => containsRectangle = value; }
            public Vector2 Position { get => position; set => position = value; }
            public bool IsText { get => isText; set => isText = value; }
            public string Text { get => text; set => text = value; }
            public FontName Font { get => font; set => font = value; }
            public bool ContainsFont { get => containsFont; set => containsFont = value; }

            public RenderObject(float x, float y, TextureName texture)
            {
                X = x;
                Y = y;
                this.Color = Color.White;
                this.Texture = texture;
                ContainsRectangle = false;

                IsText = false;
            }
            public RenderObject (Rectangle rect, TextureName texture)
            {
                this.Rect = rect;
                this.Texture = texture;
                this.Color = Color.White;
                ContainsRectangle = true;

                IsText = false;
            }
            public RenderObject(FontName font, Vector2 position, string text, Color color)
            {
                this.Position = position;
                this.Text = text;
                this.Color = color;
                ContainsFont = true;
                IsText = true;
                ContainsRectangle = false;
            }
            public RenderObject(Vector2 position, string text) 
            {
                this.Position = position;
                this.Text = text;
                this.Color = Color.White;
                Font = FontName.Arial16;
                ContainsFont = false;
                IsText = true;
                ContainsRectangle = false;
            }
        }

    }
    



    public enum TextureName
    {
        //for testing
        Ball,
        BasicDude,
        BasicTile,
        BasicBackground,
        BasicScreenBackground,
        MainScreenBackground,
        BasicButtonBackground,
        BasicButtonHover,
        BackButton,
    }
    public enum FontName
    {
        Arial12,
        Arial16,
    }
}


