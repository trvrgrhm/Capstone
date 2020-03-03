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
        Func<bool> onClickFunction;
        bool hasOnClickFunction;
        Func<bool> onDragFunction;
        bool hasonDragFunction;
        Func<bool> onClickStartFunction;
        bool hasOnClickStartFunction;
        Func<bool> onDragReleaseFunction;
        bool hasOnDragReleaseFunction;
        public Rectangle rect;
        bool clickStarted;
        bool stayedInBounds;
        bool dragging;
        bool clickStartedOutOfBounds;

        public ClickableElement(Screen screen, Rectangle clickableRectangle)
        {
            this.rect = clickableRectangle;
            screen.clickableChildren.Add(this);

            clickStarted = false;
            stayedInBounds = false;
            dragging = false;
            clickStartedOutOfBounds = false;
            hasOnClickFunction = false;
            hasOnClickStartFunction = false;
            hasonDragFunction = false;
            hasOnDragReleaseFunction = false;
        }

        public void setOnClick(Func<bool> function)
        {
            this.onClickFunction = function;

            hasOnClickFunction = true;
        }
        public void setOnDrag(Func<bool> function)
        {
            this.onDragFunction = function;

            hasonDragFunction = true;
        }
        public void setOnDragRelease(Func<bool> function)
        {
            this.onDragReleaseFunction = function;
            hasOnDragReleaseFunction = true;
        }
        public void setOnClickStart(Func<bool> function)
        {
            this.onClickStartFunction = function;

            hasOnClickStartFunction = true;
        }

        public void onClick()
        {
            try { onClickFunction(); }
            catch (Exception e) { Console.WriteLine("error with onClick, " + e.StackTrace); }
            Console.WriteLine("a button was clicked!");
        }
        public void onDrag()
        {
            try {onDragFunction(); }
            catch (Exception e) { Console.WriteLine("error with onDrag, " + e.StackTrace); }
        }
        public void onDragRelease()
        {
            try {onDragReleaseFunction(); }
            catch (Exception e) { Console.WriteLine("error with onDragRelease, " + e.StackTrace); }
        }
        public void onClickStart()
        {
            try { onClickStartFunction(); }
            catch (Exception e) { Console.WriteLine("error with onClickStart, " + e.StackTrace); }
            
        }
        public Boolean isDragging()
        {
            return dragging;
        }

        public void updateClick(Point mousePosition, bool leftClick)
        {
            
            //TODO fix this
            if (rect.Contains(mousePosition))
            {
                if (clickStartedOutOfBounds && !leftClick)
                {
                    clickStartedOutOfBounds = false;
                }
                if (leftClick&&!clickStarted&&!clickStartedOutOfBounds)
                {
                    clickStarted = true;
                    clickStartedOutOfBounds = false;
                    stayedInBounds = true;
                    if(hasOnClickStartFunction)
                    onClickStart(); 
                    //click start
                    //onClickStart
                    Console.WriteLine("click started");
                }
                if (clickStarted && stayedInBounds && !leftClick)
                {
                    //click started and released in bounds
                    if(hasOnClickFunction)
                    onClick();
                    clickStarted = false;
                    clickStartedOutOfBounds = false;
                    Console.WriteLine("onClick");
                }
            }
            else
            {
                stayedInBounds = false;
                
                if (leftClick && !clickStarted)
                {
                    clickStartedOutOfBounds = true;
                }
                if(!leftClick && clickStartedOutOfBounds)
                {
                    clickStartedOutOfBounds = false;
                }
            }
            if (clickStarted && leftClick)
            {
                if(hasonDragFunction)
                onDrag();
                dragging = true;

                Console.WriteLine("Something is being dragged from a button.");
            }
            if (clickStarted && !leftClick)
            {
                clickStarted = false;
                clickStartedOutOfBounds = false;
                if(hasOnDragReleaseFunction)
                onDragRelease();
                Console.WriteLine("A drag has stopped");
                //onDragDrop
                //release click
            }





        }
    }
}
