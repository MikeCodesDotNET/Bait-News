using System;
using System.Collections.Generic;
using System.Linq;

using BaitNews.Models;
using BaitNews.CustomControls;

using Foundation;
using UIKit;

using MikeCodesDotNET.iOS;
using NotificationHub;
using Awesomizer;
using AppServiceHelpers;
using AppServiceHelpers.Helpers;

using Microsoft.Azure.Mobile.Analytics;

namespace BaitNews
{
    public partial class SwipeGameViewController : UIViewController
	{
        List<Answer> answers;
        CardHolderView cardHolder;
		int correctAnswersCount = 0;

        ConnectedObservableCollection<Headline> headlines; 

        const string segueIdentifier = "RESULTS_SEGUE_IDENTIFIER";

        public SwipeGameViewController(IntPtr handle) : base(handle)
        {
            headlines = new ConnectedObservableCollection<Headline>(EasyMobileServiceClient.Current.Table<Headline>());
            answers = new List<Answer>();

			Analytics.TrackEvent("Games Started");
        }


        async public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);
            await headlines.Refresh();
            headlines.Shuffle();

            cardHolder = new CardHolderView(cardPlaceholder.Frame, headlines.ToList());
            cardHolder.DidSwipeLeft += OnSwipeLeft;
            cardHolder.DidSwipeRight += OnSwipeRight;
            cardHolder.NoMoreCards += FinishGame;

			View.AddSubview(cardHolder);
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
 }
}