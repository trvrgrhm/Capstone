using CrossPlatform.GameTop;
using CrossPlatform.GameTop.BattleLogic;
using CrossPlatform.GameTop.Tiles;
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
        public Battle battle;
        List<PuppetBundle> renderables;
        //List<BattlePuppetSquad> playerSquads;
        List<CaptainBundle> captains;

        public BattleTile(Screen screen, Renderer renderer, Microsoft.Xna.Framework.Rectangle rect, Battle battle)
        {
            this.battle = battle;
            renderables = new List<PuppetBundle>();
            captains = new List<CaptainBundle>();
            //playerSquads = new List<BattlePuppetSquad>();
            PuppetBundle temp;
            //playerSquads = battle.PlayerSquads;

            foreach (BattlePuppetSquad squad in battle.PlayerSquads)
            {
                foreach (BattlePuppet puppet in squad.puppets)
                {
                    temp = new PuppetBundle(puppet, new RenderableElement(screen, renderer, puppet.ImageBox, puppet.Unit.Picture));
                    renderables.Add(temp);
                    if (puppet.Unit.SquadPosition == 0)
                    {
                        CaptainBundle captainBundle = new CaptainBundle(screen, renderer, temp,squad);
                        //captain
                        captains.Add(captainBundle);
                    }
                }

            }

            
            foreach (BattlePuppet puppet in battle.EnemyPuppets)
            {
                temp = new PuppetBundle(puppet, new RenderableElement(screen, renderer, puppet.ImageBox, puppet.Unit.Picture));
                renderables.Add(temp);
            }
            //assign clickableElements to captains

        }

        private void updateRenderables()
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
            updateCaptainButtons();
            
        }
        private void updateCaptainButtons()
        {
            foreach(CaptainBundle captainBundle in captains)
            {
                captainBundle.captainButton.DragOrigin.changeLocation(captainBundle.puppetBundle.puppet.ImageBox.X, captainBundle.puppetBundle.puppet.ImageBox.Y);
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
        public PuppetBundle( BattlePuppet puppet, RenderableElement image)
        {
            this.puppet = puppet;
            this.image = image;
        }
    }
    class CaptainBundle
    {
        public PuppetBundle puppetBundle;
        public DraggableElement captainButton;

        public CaptainBundle(Screen screen, Renderer renderer, PuppetBundle bundle, BattlePuppetSquad squad)
        {
            puppetBundle = bundle;
            captainButton = new DraggableElement(screen, renderer, bundle.puppet.ImageBox);
            captainButton.DragOrigin.setVisibility(false);
            captainButton.DragIcon.Texture = TextureName.BasicButtonHover;
            captainButton.OriginIcon.setVisibility(false);
            captainButton.setOnDragRelease(() => {
                foreach (BattlePuppet puppet in squad.puppets)
                {
                    puppet.overrideTarget(screen.mousePosition);
                }
                return true; 
            });
        }

    }

}
