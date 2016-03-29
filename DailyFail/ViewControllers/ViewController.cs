using System;

using UIKit;

using Softweb.Xamarin.Controls.iOS;
using DailyFail.Shared.ViewModels;
using CoreGraphics;

using MikeCodesDotNET.iOS;
using DailyFail.CustomControls;

namespace DailyFail
{
	public partial class ViewController : UIViewController, ICardViewDataSource
	{
		HeadlineViewModel viewModel;
		CardView HeadLineCardView { get; set; }


		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			viewModel = new  HeadlineViewModel();

			HeadLineCardView = new CardView();
			HeadLineCardView.DidSwipeLeft += OnSwipeLeft;
			HeadLineCardView.DidSwipeRight += OnSwipeRight;

			btnTick.Alpha = 0;
			btnCross.Alpha = 0;

			btnStart.Alpha = 0;
			btnStart.Layer.CornerRadius = btnStart.Frame.Height / 2;
			btnStart.Layer.MasksToBounds = true;
			btnStart.TouchUpInside += delegate
			{
				lblDescription.Alpha = 0;
				btnStart.Alpha = 0;
				StartGame();
			};

			lblDescription.Alpha = 0;
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			lblDescription.FadeIn(0.4, 0.2f);
			btnStart.FadeIn(0.4, 0.6f);
		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			HeadLineCardView.Center = new CGPoint(View.Center.X, View.Center.Y - 30);
			HeadLineCardView.Bounds = new CGRect(0f, 0f, (int)View.Bounds.Width - 40f, (int)View.Bounds.Height - 250f);
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			HeadLineCardView.DataSource = this;
		}

		public void StartGame()
		{
			View.AddSubview(HeadLineCardView);

			btnTick.FadeIn(0.4, 0.2f);
			btnCross.FadeIn(0.4, 0.2f);

		}
		 
		public UIView NextCardForCardView(CardView cardView)
		{	
			//Create a card with a random background color
			var headline = viewModel.NextHeadline();
			if (headline == null)
			{
				HeadLineCardView.RemoveFromSuperview();

				btnTick.Alpha = 0;
				btnCross.Alpha = 0;

				btnStart.FadeIn(0.4, 0.3f);
				lblDescription.FadeIn(0.4, 0.2f);

				return new UIView();
			}

			var card = new HeadlineView(headline.Text)
			{
				Frame = HeadLineCardView.Bounds,
				BackgroundColor = UIColor.Clear
			};

			card.Layer.ShouldRasterize = true;
			return card;
		}

		void OnSwipeLeft(object sender, SwipeEventArgs e)
		{
			btnCross.Pop(0.2, 0, 0.3f);
		}

		void OnSwipeRight(object sender, SwipeEventArgs e)
		{
			btnTick.Pop(0.2, 0, 0.3f);
		}

		partial void BtnTick_TouchUpInside(UIButton sender)
		{
			btnTick.Pop(0.2, 0, 0.3f);
			HeadLineCardView.SwipeTopCardToRight();
		}

		partial void BtnCross_TouchUpInside(UIButton sender)
		{
			btnCross.Pop(0.2, 0, 0.3f);
			HeadLineCardView.SwipeTopCardToLeft();
		}
	}
}

