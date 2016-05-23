using System;
using System.Collections.Generic;

using Foundation;
using CoreGraphics;
using UIKit;

using BaitNews.Models;

namespace DailyFail.CustomControls
{
    public class CardHolderView : UIView
    {
        public CardHolderView(IntPtr handle) : base(handle) { }

        public List<Headline> Headlines = new List<Headline>();
    }
}

