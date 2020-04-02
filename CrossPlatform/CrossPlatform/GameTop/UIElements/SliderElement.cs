using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UIElements
{
    class SliderElement
    {
        //from 0 to 1
        public double SliderValue { get; set; }

        public Button SliderButton { get; set; }
        public RenderableElement SliderBar { get; set; }

        public bool sliderMoving;

        public SliderElement(Screen screen, Renderer renderer, Rectangle sliderBar)
        {
            SliderBar = new RenderableElement(screen, renderer, sliderBar, TextureName.BasicButtonHover);
            SliderButton = new Button(screen, renderer, new Rectangle(sliderBar.X, sliderBar.Y, sliderBar.Width, sliderBar.Width));
            SliderButton.changeTexture(TextureName.Ball);
            SliderButton.hoverableTile.Highlight = false;

            SliderButton.clickableElement.setOnDrag(dragSlider);
            SliderButton.clickableElement.setOnDragRelease(sliderStopped);
        }
        private bool dragSlider(Point mousePosition) {
            moveSliderButton(mousePosition.Y);
            return true;
        }

        public void moveSliderButton(int yPosition)
        {
            if (yPosition >= SliderBar.Rect.Y && yPosition <= (SliderBar.Rect.Y + SliderBar.Rect.Height - SliderButton.Rect.Height))
            {
                SliderButton.changeLocation(SliderButton.Rect.X, yPosition);
                SliderValue = (SliderButton.Rect.Y - SliderBar.Rect.Y) / (1.0 * SliderBar.Rect.Height);
                Console.WriteLine("slider value is " + SliderValue);
                sliderMoving = true;
            }
        }
        private bool sliderStopped()
        {
            sliderMoving = false;
            return true;
        }



    }
}
