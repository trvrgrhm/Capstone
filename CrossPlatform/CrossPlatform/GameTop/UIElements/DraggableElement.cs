using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.UIElements
{
    class DraggableElement
    {
        public Button DragOrigin;
        public RenderableElement DragIcon;
        public bool CursorIcon { get { return cursorIcon; } set { cursorIcon = value;DragIcon.setVisibility(value); } }
        public bool cursorIcon;

        public bool dragging;

        private Func<bool> customDragRelease;

        public DraggableElement(Screen screen, Renderer renderer, Rectangle origin)
        {
            DragOrigin = new Button(screen,renderer,origin);
            DragIcon = new RenderableElement(screen,renderer,origin);
            cursorIcon = true;
            dragging = false;

            DragOrigin.clickableElement.setOnDrag(dragItem);
            DragOrigin.clickableElement.setOnDragRelease(onDragRelease);
        }

        private bool dragItem(Point mousePosition)
        {
            dragging = true;
            if (cursorIcon)
            {
                centerIconOnCursor(mousePosition);
            }
            return true;
        }
        private bool onDragRelease()
        {
            dragging = false; 
            DragIcon.Rect = DragOrigin.Rect;
            customDragRelease?.Invoke();
            return true;
        }
        public void setOnDragRelease(Func<bool> func)
        {
            customDragRelease = func;
        }

        public void setCursorVisibility(bool visible)
        {
            DragIcon.setVisibility(true);
            cursorIcon = visible;
        }
        private void centerIconOnCursor(Point mousePosition)
        {
            DragIcon.Rect = new Rectangle(mousePosition.X-(DragIcon.Rect.Width / 2), mousePosition.Y-(DragIcon.Rect.Height/2), DragIcon.Rect.Width, DragIcon.Rect.Height);
        }
        public void changeLocation(int x,int y)
        {
            DragOrigin.Rect = new Rectangle(x, y, DragOrigin.Rect.Width, DragOrigin.Rect.Height);
            DragIcon.Rect = new Rectangle(x, y, DragIcon.Rect.Width, DragIcon.Rect.Height);
        }



        public void destroy()
        {
            DragOrigin.destroy();
            DragIcon.destroy();
        }
    }
}
