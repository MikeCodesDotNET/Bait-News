using System.Collections.Generic;

using CoreGraphics;
using UIKit;

using BaitNews.Models;

namespace DailyFail.CustomControls
{
    public class CardHolderView : UIView
    {
        public CardHolderView(CGRect rect, List<Headline> headlines)
        {
            Frame = rect;
            Headlines = headlines;

            BottomCard = new HeadlineView();
            MiddleCard = new HeadlineView();
            TopCard = new HeadlineView();

            UpdateCards();
        }

        public List<Headline> Headlines { get; private set;}

        public Headline CurrentHeadline
        {
            get
            {
                return Headlines[0] != null ? Headlines[0] : null;
            }
        }

        //We keep 3 cards in memory and reuse them. 
        HeadlineView TopCard;
        HeadlineView MiddleCard;
        HeadlineView BottomCard;

        public void UpdateCards()
        {
            if (Headlines.Count > 2)
            {
                BottomCard.Headline = Headlines[2];
                BottomCard.Center = new CGPoint(Center.X, Center.Y - 100);
                BottomCard.Bounds = new CGRect(0f, 0f, (int)Bounds.Width - 40f, (int)Bounds.Height - 20f);
                BottomCard.Transform = CGAffineTransform.MakeRotation(0.02f);
                BottomCard.OnSwipe += HandleOnSwipe;

                MiddleCard.Headline = Headlines[1];
                MiddleCard.Center = new CGPoint(Center.X, Center.Y - 100);
                MiddleCard.Bounds = new CGRect(0f, 0f, (int)Bounds.Width - 40f, (int)Bounds.Height - 20f);
                MiddleCard.Transform = CGAffineTransform.MakeRotation(-0.04f);
                MiddleCard.OnSwipe += HandleOnSwipe;

 
                TopCard.Headline = Headlines[0];
                TopCard.Center = new CGPoint(Center.X, Center.Y - 100);
                TopCard.Bounds = new CGRect(0f, 0f, (int)Bounds.Width - 40f, (int)Bounds.Height - 20f);
                TopCard.OnSwipe += HandleOnSwipe;

                AddSubview(BottomCard);
                AddSubview(MiddleCard);
                AddSubview(TopCard);
            }

        }

        void HandleOnSwipe(object sender, DraggableEventArgs args)
        {
            var headlineView = sender as HeadlineView;
            Headlines.Remove(headlineView.Headline);

            if (args.Dragged.Equals(DraggableDirection.Left) && DidSwipeLeft != null)
            {
                DidSwipeLeft(headlineView);
            }
            else if (args.Dragged.Equals(DraggableDirection.Right) && DidSwipeRight != null)
            {
                DidSwipeRight(headlineView);
            }
            headlineView.RemoveFromSuperview();

            UpdateCards();
        }

        public delegate void OnSwipeLeftHandle(HeadlineView sender);
        public event OnSwipeLeftHandle DidSwipeLeft;

        public delegate void OnSwipeRightHandle(HeadlineView sender);
        public event OnSwipeRightHandle DidSwipeRight;
    }
}

