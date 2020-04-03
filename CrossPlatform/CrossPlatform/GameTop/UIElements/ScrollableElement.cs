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
        Screen Screen { get; set; }
        public HoverableElement ViewFrame { get { return viewFrame; } set { viewFrame = value; TotalFrame.Width = value.Rect.Width; } }
        private HoverableElement viewFrame;
        public RenderableElement ScrollingFrame { get; set; }
        public SliderElement SliderBar { get; set; }
        public Rectangle TotalFrame;
        int previousScrollValue;
        int scrollUnit;
        private bool actuallyScrollable;

        public ScrollableElement(Screen screen, Renderer renderer, Rectangle viewRect)
        {
            this.Screen = screen;
            TotalFrame = viewRect;
            ViewFrame = new HoverableElement(screen, renderer, viewRect);
            ViewFrame.Highlight = false;
            //for testing 
            ScrollingFrame = new RenderableElement(screen, renderer, TotalFrame);

            SliderBar = new SliderElement(screen, renderer, new Rectangle(viewRect.X+viewRect.Width- (int)(viewRect.Width * .1), viewRect.Y, (int)(viewRect.Width * .1), viewRect.Height));
            //for testing (doubles scroll height)
            //changeScrollingHeight(TotalFrame.Height*3);
            ScrollingFrame.Texture = TextureName.MainScreenBackground;

            scrollUnit = (int)((ViewFrame.Rect.Height) * .1);
            Screen.scrollableChildren.Add(this);
        }

        public void onScrollDown()
        {
            SliderBar.moveSliderButton(SliderBar.SliderButton.Rect.Y-scrollUnit);
            //moveScrollingFrame(SliderBar.SliderValue);
        }
        public void onScrollUp()
        {
            SliderBar.moveSliderButton(SliderBar.SliderButton.Rect.Y + scrollUnit);
            //moveScrollingFrame(SliderBar.SliderValue);
        }
        public void moveScrollingFrame(double value)
        {
            //project placement of scrolling frame
            int max = ViewFrame.Rect.Y;
            int min = max - ScrollingFrame.Rect.Height + ViewFrame.Rect.Height;
            //range = max - min
            int range = max - min;
            //movement = value* range
            int movement = (int)(range*value);
            //new value = min + movement
            ScrollingFrame.Rect = new Rectangle(ViewFrame.Rect.X,ViewFrame.Rect.Y - movement,ScrollingFrame.Rect.Width,ScrollingFrame.Rect.Height);
        }
        //amount can be positive or negative
        public void changeScrollingHeight(int newHeight)
        {
            //adjusts height instead of resetting it...
            //if (TotalFrame.Height + amount >= ViewFrame.Rect.Height)
            //{
            //    TotalFrame = new Rectangle(TotalFrame.X, TotalFrame.Y, TotalFrame.Width, TotalFrame.Height + amount);
            //    ScrollingFrame.Rect = TotalFrame;
            //    actuallyScrollable = true;
            //}
            if(newHeight >= ViewFrame.Rect.Height)
            {
                TotalFrame = new Rectangle(TotalFrame.X, TotalFrame.Y, TotalFrame.Width, newHeight);
                ScrollingFrame.Rect = TotalFrame;
                actuallyScrollable = true;
            }
            if(TotalFrame.Height == ViewFrame.Rect.Height)
            {
                actuallyScrollable = false;
            }
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
            SliderBar.setVisibility(ViewFrame.isHovering() && (actuallyScrollable)); ;
            if (SliderBar.sliderMoving)
            {
                moveScrollingFrame(SliderBar.SliderValue);
            }
        }

        public void destroy()
        {
            Screen.scrollableChildren.Remove(this);
            ViewFrame.destroy();
            ScrollingFrame.destroy();
            SliderBar.destroy();
        }
    }
}
