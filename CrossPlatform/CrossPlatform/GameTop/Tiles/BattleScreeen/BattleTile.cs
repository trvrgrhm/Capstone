using CrossPlatform.GameTop.BattleLogic;
using CrossPlatform.GameTop.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Tiles
{
    class BattleTile
    {
        Battle battle;
        List<PuppetBundle> renderables;
        public BattleTile(Screen screen, Renderer renderer, Microsoft.Xna.Framework.Rectangle rect, Battle battle)
        {
            this.battle = battle;
            renderables = new List<PuppetBundle>();
            PuppetBundle temp;
            foreach (BattlePuppet puppet in battle.PlayerPuppets)
            {
                temp = new PuppetBundle(puppet, new RenderableElement(screen, renderer, puppet.ImageBox, puppet.Unit.Picture));
                renderables.Add(temp);
            }
            foreach (BattlePuppet puppet in battle.EnemyPuppets)
            {
                temp = new PuppetBundle(puppet, new RenderableElement(screen, renderer, puppet.ImageBox, puppet.Unit.Picture));
                renderables.Add(temp);
            }
        }

        public void updateRenderables()
        {
            foreach (PuppetBundle renderable in renderables)
            {
                renderable.image.Rect = renderable.puppet.ImageBox;
                if (renderable.puppet.isDead)
                {
                    renderable.image.Texture = TextureName.Ball;
                }
            }
            //remove all items from renderer's renderables
            //update animations
            //add renderables in order from least Y to greatest Y from battleObjects
            renderables = renderables.OrderBy( item => item.puppet.ImageBox.Y).ToList();
            foreach(PuppetBundle renderable in renderables)
            {
                renderable.image.reset();
            }
            
        }
        public void update()
        {
            battle.update();
            updateRenderables();
        }
    }
    class PuppetBundle
    {
        public BattlePuppet puppet;
        public RenderableElement image;
        public PuppetBundle(BattlePuppet puppet, RenderableElement image)
        {
            this.puppet = puppet;
            this.image = image;
        }
    }
}
