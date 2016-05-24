using System;

//Credit to Jon Davis
namespace BaitNews.CustomControls
{
    public class DraggableEventArgs : EventArgs
    {
        public DraggableDirection Dragged { get; private set; }

        public DraggableEventArgs(DraggableDirection dragged)
        {
            Dragged = dragged;
        }
    }
}

