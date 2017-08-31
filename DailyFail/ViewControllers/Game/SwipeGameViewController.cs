using System;
using System.Collections.Generic;
using System.Linq;

using BaitNews.Models;
using BaitNews.CustomControls;
using BaitNews.Services.Headlines;

using Foundation;
using UIKit;

using MikeCodesDotNET.iOS;
using Awesomizer;

using Microsoft.Azure.Mobile.Analytics;
using SafariServices;
using CoreGraphics;

namespace BaitNews
{
    public partial class SwipeGameViewController : UIViewController
	{
		HeadlineService headlineService = new HeadlineService(new HeadlineApiService());
		List<Answer> answers;
        List<Headline> headlines; 
		public CardHolderView cardHolderView;
		int correctAnswersCount = 0;


        const string segueIdentifier = "RESULTS_SEGUE_IDENTIFIER";

        public SwipeGameViewController(IntPtr handle) : base(handle)
        {
			answers = new List<Answer>(); 
			Analytics.TrackEvent("Games Started");
        }


		public Headline CurrentHeadline
		{
			get
			{
				return cardHolderView.VisibleHeadline;
			}
		}

        async public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);

            headlines = await headlineService.GetHeadlines(Fusillade.Priority.UserInitiated);

            headlines.Shuffle();

            cardHolderView = new CardHolderView(cardPlaceholder.Frame, headlines);
            cardHolderView.DidSwipeLeft += OnSwipeLeft;
            cardHolderView.DidSwipeRight += OnSwipeRight;
            cardHolderView.NoMoreCards += FinishGame;

			View.AddSubview(cardHolderView);

			if (TraitCollection.ForceTouchCapability == UIForceTouchCapability.Available)
			{
                RegisterForPreviewingWithDelegate(new HeadlineCardPreviewingDelegate(this), cardHolderView);
			}
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
			base.PrepareForSegue(segue, sender);

			var type = segue.DestinationViewController.GetType();
			if(type == typeof(UINavigationController))
			 {
				var nc = segue.DestinationViewController;
                if (nc == null)
                    return;

				if (nc.ChildViewControllers.FirstOrDefault().GetType() == typeof(ResultsViewController))
				{
					var vc = nc.ChildViewControllers.FirstOrDefault() as ResultsViewController;
					vc.Answers = answers;
				}
			}
        }

        void OnSwipeLeft(HeadlineCardView sender)
        {
            var card = sender;
            var headline = card.Headline;

            var answer = new Answer() { Headline = headline, HeadlineId = headline.Id};

            //User believes headline to be false
            if (headline.IsTrue)
            {
                answer.CorrectAnswer = false;
				IncorrectAnswer();
            }
            else
            {
                answer.CorrectAnswer = true;
				CorrectAnswer();
            }
            answers.Add(answer);
        }

        void OnSwipeRight(HeadlineCardView sender)
        {
            var card = sender;
            var headline = card.Headline;

			var answer = new Answer() { Headline = headline, HeadlineId = headline.Id };

            //User believes headline to be true
            if (headline.IsTrue)
            {
                answer.CorrectAnswer = true;
                CorrectAnswer();
			}
            else
            {
              	answer.CorrectAnswer = false;
				IncorrectAnswer();

            }
            answers.Add(answer);
        }

		void CorrectAnswer()
		{
			correctAnswersCount++;
			lblcorrectCount.Text = correctAnswersCount.ToString();
			lblWrongCount.Text = (answers.Count() + 1).ToString();
			lblcorrectCount.Pop(0.2, 0, 1);

			var impact = new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Light);
			impact.Prepare ();
			impact.ImpactOccurred ();
			Analytics.TrackEvent("Answered Correctly");
		}

		void IncorrectAnswer()
		{
			lblWrongCount.Text = (answers.Count() + 1).ToString();

			var impact = new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Heavy);
			impact.Prepare ();
			impact.ImpactOccurred ();
			Analytics.TrackEvent("Answered Incorrectly");
		}

		partial void BtnFinish_TouchUpInside(UIButton sender)
		{
		}

        void FinishGame()
        {
            DismissViewController(true, null);
        }

		public void CommitViewController(IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
		{
			ShowViewController(viewControllerToCommit, this);
		}

	}

	public class HeadlineCardPreviewingDelegate : UIViewControllerPreviewingDelegate
	{
		SwipeGameViewController gameController;
		public HeadlineCardPreviewingDelegate(SwipeGameViewController gameController)
		{
            this.gameController = gameController;
		}

		public HeadlineCardPreviewingDelegate(NSObjectFlag t) : base(t)
		{
		}

		public HeadlineCardPreviewingDelegate(IntPtr handle) : base(handle)
		{
		}

		/// Present the view controller for the "Pop" action.
		public override void CommitViewController(IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
		{
			// Reuse Peek view controller for details presentation
			gameController.ShowViewController(viewControllerToCommit, this);
		}

		/// Create a previewing view controller to be shown at "Peek".
		public override UIViewController GetViewControllerForPreview(IUIViewControllerPreviewing previewingContext, CGPoint location)
		{
			Analytics.TrackEvent("User used 3D Touch");


			// Grab a controller and set it to the default sizes
			var safariViewController = new SFSafariViewController(new NSUrl(gameController.CurrentHeadline.Url), true);
			safariViewController.PreferredContentSize = new CGSize(0, 0);

			// Set the source rect to the cell frame, so everything else is blurred.
			previewingContext.SourceRect = gameController.cardHolderView.Frame;
			return safariViewController;
		} 
	}
}