using System;

//Credit to Jon Davis
namespace DailyFail.CustomControls
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

