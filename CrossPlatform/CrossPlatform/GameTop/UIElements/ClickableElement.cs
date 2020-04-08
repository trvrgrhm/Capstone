using CrossPlatform.GameTop.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UI
{
    class ClickableElement: IClickable
    {
        Screen Screen { get; set; }
        Func<bool> onClickFunction;
        bool hasOnClickFunction;
        Func<Point,bool> onDragFunction;
        bool hasonDragFromHereFunction;
        Func<bool> onClickStartHereFunction;
        bool hasOnClickStartHereFunction;
        Action onDragEndHereFunction;
        bool hasOnDragEndHereFunction;
        Action onDragReleaseFunction;
        bool hasOnDragReleaseFunction;
        public Rectangle rect;
        bool clickStartedHere;
        //bool stayedInBounds;
        //bool dragging;
        //bool clickStartedOutOfBounds;

        //static stuff
        //public static bool dragStartedOverall = false;

        public ClickableElement(Screen screen, Rectangle clickableRectangle)
        {
            this.rect = clickableRectangle;
            this.Screen = screen;
            this.Screen.clickableChildren.Insert(0,this);

            clickStartedHere = false;
            //stayedInBounds = false;
            //dragging = false;
            //clickStartedOutOfBounds = false;
            hasOnClickFunction = false;
            hasOnClickStartHereFunction = false;
            hasOnDragEndHereFunction = false;
            hasonDragFromHereFunction = false;
            hasOnDragReleaseFunction = false;
        }

        public void setOnClick(Func<bool> function)
        {
            this.onClickFunction = function;

            hasOnClickFunction = true;
        }
        public void setOnDrag(Func<Point,bool> function)
        {
            this.onDragFunction = function;

            hasonDragFromHereFunction = true;
        }
        public void setOnDragRelease(Action function)
        {
            this.onDragReleaseFunction = function;
            hasOnDragReleaseFunction = true;
        }
        public void setOnClickStartHere(Func<bool> function)
        {
            this.onClickStartHereFunction = function;
            if (function != null)
            {
                hasOnClickStartHereFunction = true;
            }
            else
            {
                hasOnClickStartHereFunction = false;
            }
        }
        public void setOnClickEndHere(Action function)
        {
            this.onDragEndHereFunction = function;

            hasOnDragEndHereFunction = true;
        }

        public void onClick()
        {
            try { onClickFunction(); }
            catch (Exception e) { Console.WriteLine("error with onClick, " + e.StackTrace); }
            //Console.WriteLine("a button was clicked!");
        }
        private void onDragFromHere(Point mousePosition)
        {
            try {onDragFunction(mousePosition); }
            catch (Exception e) { Console.WriteLine("error with onDrag, " + e.StackTrace); }
        }
        private void onDragRelease()
        {
            try { onDragReleaseFunction(); }
            catch (Exception e) { Console.WriteLine("error with onDragRelease, " + e.StackTrace); }
        }
        private void onClickStartHere()
        {
            try { onClickStartHereFunction(); }
            catch (Exception e) { Console.WriteLine("error with onClickStart, " + e.StackTrace); }
            
        }
        private void onDragEndHere()
        {
            try { onDragEndHereFunction(); }
            catch (Exception e) { Console.WriteLine("error with onClickStart, " + e.StackTrace); }

        }
        //public Boolean isDragging()
        //{
        //    return dragging;
        //}

        public void updateClick(Point mousePosition, bool leftClick, bool dragStarted)
        {
            if (rect.Contains(mousePosition))
            {
                if (dragStarted)
                {
                    if (!leftClick)
                    {
                        if (clickStartedHere)
                        {
                            if(hasOnClickFunction)
                            onClick();
                            Console.WriteLine("full click");
                        }
                        else
                        {
                            if(hasOnDragEndHereFunction)
                            onDragEndHere();
                            Console.WriteLine("drag ended here");
                        }
                        Screen.dragStarted = false;


                    }
                }
                else
                {
                    if (leftClick)
                    {
                        clickStartedHere = true;
                        if(hasOnClickStartHereFunction)
                        onClickStartHere();
                        Screen.dragStarted = true;
                        Console.WriteLine("click started here");
                    }
                }
            }
            //if (!leftClick)
            //{
            //    clickStartedHere = false;
            //    Console.WriteLine("drag released");
            //    if (hasOnDragReleaseFunction)
            //        onDragRelease();
            //}
            if (dragStarted&& clickStartedHere)
            {
                if(hasonDragFromHereFunction)
                onDragFromHere(mousePosition);
                Console.WriteLine("drag continued here");
                if (!leftClick)
                {
                    
                }

            }
            if (!leftClick&& clickStartedHere)
            {
                Console.WriteLine("drag released");
                if (hasOnDragReleaseFunction)
                    onDragRelease();
                clickStartedHere = false;
            }
        }
        public void reset()
        {
            Screen.clickableChildren.Remove(this);
            Screen.clickableChildren.Insert(0,this);
        }
        public void destroy()
        {
            Screen.clickableChildren.Remove(this);
        }
    }
}
