using System;
using UIKit;
using CoreGraphics;
using Foundation;

//Credit to Jon Davis
namespace BaitNews.CustomControls
{
    [Register("DraggableView")]
    public class DraggableView : UIView
    {
        CGPoint startingPoint;
        UIPanGestureRecognizer panGestureRecognizer;

        public DraggableDirection Dragged { get; private set; }
        public nfloat SwipeThreshold { get; set; }
        public nfloat RotationAnimationDuration { get; set; }
        public nfloat ScaleStrength { get; set; }
        public nfloat RotationStrength { get; set; }

        public event EventHandler<DraggableEventArgs> OnSwipe;

        public DraggableView(IntPtr handle) : base(handle) { }

        public DraggableView()
        {
            panGestureRecognizer = new UIPanGestureRecognizer(HandleOnGestureRecognizer);

            RotationStrength = 300;
            RotationAnimationDuration = 0.85f;
            ScaleStrength = 0.85f;
            SwipeThreshold = 140;

            BackgroundColor = UIColor.Clear;
        }

        void HandleOnGestureRecognizer(UIPanGestureRecognizer gestureRecognizer)
        {
            // The translation of the pan gesture in the coordinate system of the specified view.
            var xTranslation = gestureRecognizer.TranslationInView(this).X;
            var yTranslation = gestureRecognizer.TranslationInView(this).Y;

            if (gestureRecognizer.State.Equals(UIGestureRecognizerState.Began))
            {
                startingPoint = Center;
            }
            else if (gestureRecognizer.State.Equals(UIGestureRecognizerState.Changed))
            {
                var rotationStrength = Math.Min(xTranslation / RotationStrength, 1);
                var rotationAngle = (nfloat)(2 * Math.PI * rotationStrength / 17);
                var scaleStrength = 1 - Math.Abs(rotationStrength) / 4;
                var scale = (nfloat)Math.Max(scaleStrength, ScaleStrength);
                var transform = CGAffineTransform.MakeRotation(rotationAngle);

                Center = new CGPoint(startingPoint.X + xTranslation, startingPoint.Y + yTranslation);
                Transform = CGAffineTransform.Scale(transform, scale, scale);
            }
            else if (gestureRecognizer.State.Equals(UIGestureRecognizerState.Ended))
            {
                DetermineSwipeAction(xTranslation);
            }
        }

        void DetermineSwipeAction(nfloat xTranslation)
        {
            if (xTranslation <= -SwipeThreshold)
            {
                if(xTranslation < -220)
                {
                    Dragged = DraggableDirection.Left;
                    UIView.Animate(RotationAnimationDuration, () =>
                    {
                        Center = new CGPoint(Frame.Width -700, startingPoint.Y);
                        // The translation of the pan gesture in the coordinate system of the specified UIView.
                        Transform = CGAffineTransform.MakeRotation(0);
                    });
                }
                else
                {
                    ResetView();
                }
            }
            else if (xTranslation >= SwipeThreshold)
            {
                if (xTranslation > 220)
                {
                    Dragged = DraggableDirection.Right;
                    UIView.Animate(RotationAnimationDuration, () =>
                    {
                        Center = new CGPoint(Frame.Width + 700, startingPoint.Y);
                        // The translation of the pan gesture in the coordinate system of the specified UIView.
                        Transform = CGAffineTransform.MakeRotation(0);
                    });
                }
                else
                {
                    ResetView();
                }
            }
            else
            {
                Dragged = DraggableDirection.None;
                ResetView();
            }

            var evt = OnSwipe;

            if (evt != null)
                OnSwipe(this, new DraggableEventArgs(Dragged));
        }

        void ResetView()
        {
            UIView.Animate(RotationAnimationDuration, () =>
            {
                Center = startingPoint;
                // The translation of the pan gesture in the coordinate system of the specified UIView.
                Transform = CGAffineTransform.MakeRotation(0);
            });
        }

        public override void WillMoveToSuperview(UIView newsuper)
        {
            AddGestureRecognizer(panGestureRecognizer);
        }

        public override void WillRemoveSubview(UIView uiview)
        {
            RemoveGestureRecognizer(panGestureRecognizer);
        }
    }
}

