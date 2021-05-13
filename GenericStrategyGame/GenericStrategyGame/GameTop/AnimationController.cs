using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SpriterDotNet.MonoGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop
{
    class AnimationController
    {
        SpriteBatch spriteBatch;
        ContentManager content;
        Dictionary <AnimName, MonoGameAnimator> animators;


        public void init(SpriteBatch spriteBatch, ContentManager content)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;

            animators = new Dictionary<AnimName, MonoGameAnimator>();

            textureMap = new Dictionary<TextureName, Texture2D>();
            fontMap = new Dictionary<FontName, SpriteFont>();
            renderObjects = new List<RenderObject>();
        }
        public void loadContent()
        {
            foreach (EnumType type in UnitType)
            {

            }
            Enum.


                //for testing
                textureMap.Add(TextureName.Ball, content.Load<Texture2D>("ball"));
                textureMap.Add(TextureName.BasicTile, content.Load<Texture2D>("box_brown"));
                textureMap.Add(TextureName.BasicButtonBackground, content.Load<Texture2D>("rounded_box_brown"));
                textureMap.Add(TextureName.BasicButtonHover, content.Load<Texture2D>("rounded_box_red_faded"));
                textureMap.Add(TextureName.MainScreenBackground, content.Load<Texture2D>("box_tan"));
                textureMap.Add(TextureName.BasicScreenBackground, content.Load<Texture2D>("box_tan"));
                textureMap.Add(TextureName.BackButton, content.Load<Texture2D>("ball"));

                fontMap.Add(FontName.Arial12, content.Load<SpriteFont>("arial_12"));
                fontMap.Add(FontName.Arial16, content.Load<SpriteFont>("arial_16"));

                //units
                textureMap.Add(TextureName.BasicDude, content.Load<Texture2D>("Idle_000"));
                textureMap.Add(TextureName.Miku, content.Load<Texture2D>("miku warrior"));
                textureMap.Add(TextureName.Archer1, content.Load<Texture2D>("Characters/Archer01/Picture"));
                textureMap.Add(TextureName.Archer2, content.Load<Texture2D>("Characters/Archer02/Picture"));
                textureMap.Add(TextureName.Archer3, content.Load<Texture2D>("Characters/Archer03/Picture"));
                textureMap.Add(TextureName.Cyclop1, content.Load<Texture2D>("Characters/Cyclop01/Picture"));
                textureMap.Add(TextureName.Cyclop2, content.Load<Texture2D>("Characters/Cyclop02/Picture"));
                textureMap.Add(TextureName.Cyclop3, content.Load<Texture2D>("Characters/Cyclop03/Picture"));
                textureMap.Add(TextureName.Demon1, content.Load<Texture2D>("Characters/Demon01/Picture"));
                textureMap.Add(TextureName.Demon2, content.Load<Texture2D>("Characters/Demon02/Picture"));
                textureMap.Add(TextureName.Demon3, content.Load<Texture2D>("Characters/Demon03/Picture"));
                textureMap.Add(TextureName.Goblin1, content.Load<Texture2D>("Characters/Goblin01/Picture"));
                textureMap.Add(TextureName.Goblin2, content.Load<Texture2D>("Characters/Goblin02/Picture"));
                textureMap.Add(TextureName.Goblin3, content.Load<Texture2D>("Characters/Goblin03/Picture"));
                textureMap.Add(TextureName.Knight1, content.Load<Texture2D>("Characters/Knight01/Picture"));
                textureMap.Add(TextureName.Knight2, content.Load<Texture2D>("Characters/Knight02/Picture"));
                textureMap.Add(TextureName.Knight3, content.Load<Texture2D>("Characters/Knight03/Picture"));
                textureMap.Add(TextureName.Orc1, content.Load<Texture2D>("Characters/Orc01/Picture"));
                textureMap.Add(TextureName.Orc2, content.Load<Texture2D>("Characters/Orc02/Picture"));
                textureMap.Add(TextureName.Orc3, content.Load<Texture2D>("Characters/Orc03/Picture"));
                textureMap.Add(TextureName.Skull1, content.Load<Texture2D>("Characters/Skull01/Picture"));
                textureMap.Add(TextureName.Skull2, content.Load<Texture2D>("Characters/Skull02/Picture"));
                textureMap.Add(TextureName.Skull3, content.Load<Texture2D>("Characters/Skull03/Picture"));

        }
    }

    public enum AnimName
    {

    }
}
