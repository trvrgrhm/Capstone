using CrossPlatform.GameTop.ArmyInfo;
using CrossPlatform.GameTop.Interfaces;
using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UIElements
{
    class ScrollableElement : IScrollable
    {
        public HoverableElement ViewFrame { get { return viewFrame; } set { viewFrame = value; TotalFrame.Width = value.Rect.Width; } }
        private HoverableElement viewFrame;
        public RenderableElement Background { get; set; }
        public SliderElement SliderBar { get; set; }
        public Rectangle TotalFrame;
        int previousScrollValue;

        public ScrollableElement(Screen screen, Renderer renderer, Rectangle viewRect)
        {
            TotalFrame = viewRect;
            ViewFrame = new HoverableElement(screen, renderer, viewRect);
            ViewFrame.Highlight = false;
            Background = new RenderableElement(screen, renderer, TotalFrame);
            SliderBar = new SliderElement(screen, renderer, new Rectangle(viewRect.X+viewRect.Width- (int)(viewRect.Width * .1), viewRect.Y, (int)(viewRect.Width * .1), viewRect.Height));

            screen.scrollableChildren.Add(this);
            //slider

        }

        public void onScrollDown()
        {
            SliderBar.moveSliderButton(SliderBar.SliderButton.Rect.Y-10);
        }
        public void onScrollUp()
        {
            SliderBar.moveSliderButton(SliderBar.SliderButton.Rect.Y + 10);
        }

        public void updateScroll(int scrollValue)
        {
            if (ViewFrame.isHovering())
            {
                if (scrollValue > previousScrollValue)
                {
                    onScrollDown();
                }
                else if (scrollValue < previousScrollValue)
                {
                    onScrollUp();
                }
                //Console.WriteLine("Scroll value: " + scrollValue);
            }
            previousScrollValue = scrollValue;
        }
    }
}
