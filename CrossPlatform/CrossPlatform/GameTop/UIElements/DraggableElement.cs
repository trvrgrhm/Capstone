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
        public RenderableElement OriginIcon;
        public bool CursorIcon { get { return cursorIcon; } set { cursorIcon = value;if(value)DragIcon.setVisibility(true); } }
        public bool cursorIcon;

        public bool dragging;
        bool hasCustomDragRelease;

        private Func<bool> customDragRelease;

        public DraggableElement(Screen screen, Renderer renderer, Rectangle origin)
        {
            DragOrigin = new Button(screen, renderer, origin);
            OriginIcon = new RenderableElement(screen, renderer, origin);
            DragIcon = new RenderableElement(screen, renderer, origin);
            DragIcon.moveToTopLayer();
            cursorIcon = true;
            dragging = false;
            DragIcon.setVisibility(false);
            hasCustomDragRelease = false;

            DragOrigin.clickableElement.setOnDrag(dragItem);
            DragOrigin.clickableElement.setOnDragRelease(onDragRelease);
        }

        private bool dragItem(Point mousePosition)
        {
            dragging = true;
            if (cursorIcon)
            {
                DragIcon.setVisibility(true);
                centerIconOnCursor(mousePosition);
            }
            return true;
        }
        private void onDragRelease()
        {
            dragging = false;
            //DragIcon.Rect = DragOrigin.Rect;
            DragIcon.setVisibility(false);
            if(hasCustomDragRelease)
            customDragRelease();
            //return true;
        }
        public void setOnDragRelease(Func<bool> func)
        {
            customDragRelease = func;
            hasCustomDragRelease = true;
        }

        public void setCursorVisibility(bool visible)
        {
            //DragIcon.setVisibility(true);
            cursorIcon = visible;
        }
        private void centerIconOnCursor(Point mousePosition)
        {
            DragIcon.Rect = new Rectangle(mousePosition.X-(DragIcon.Rect.Width / 2), mousePosition.Y-(DragIcon.Rect.Height/2), DragIcon.Rect.Width, DragIcon.Rect.Height);
        }
        public void changeLocation(int x,int y)
        {
            DragOrigin.Rect = new Rectangle(x, y, DragOrigin.Rect.Width, DragOrigin.Rect.Height);
            OriginIcon.Rect = new Rectangle(x, y, OriginIcon.Rect.Width, OriginIcon.Rect.Height);
        }



        public void destroy()
        {
            DragOrigin.destroy();
            OriginIcon.destroy();
            DragIcon.destroy();
        }
    }
}
