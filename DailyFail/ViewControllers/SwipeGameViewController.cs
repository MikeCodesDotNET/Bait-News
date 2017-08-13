using System;
using System.Collections.Generic;
using System.Linq;

using BaitNews.Models;
using BaitNews.CustomControls;

using Foundation;
using SafariServices;
using UIKit;

using MikeCodesDotNET.iOS;
using NotificationHub;
using Awesomizer;
using AppServiceHelpers;
using AppServiceHelpers.Helpers;

using System.Collections.ObjectModel;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;

namespace BaitNews
{
    public partial class SwipeGameViewController : UIViewController
    {
        Notifier incorrectHub;
        Notifier correctHub;
        List<Answer> answers;
        CardHolderView cardHolder;

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

            incorrectHub = new Notifier(btnIncorrect);
            incorrectHub.MoveCircle(-48, -18);
            incorrectHub.SetCircleColor(btnIncorrect.TitleColor(UIControlState.Normal), UIColor.White);
            incorrectHub.ShowCount();

            correctHub = new Notifier(btnCorrect);
            correctHub.MoveCircle(-48, -18);
            correctHub.SetCircleColor(btnCorrect.TitleColor(UIControlState.Normal), UIColor.White);
            correctHub.ShowCount();

            btnCorrect.Alpha = 0;
            btnIncorrect.Alpha = 0;

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

        void OnSwipeLeft(HeadlineView sender)
        {
            var card = sender;
            var headline = card.Headline;

            if (lblHelper.Alpha != 0)
                lblHelper.Alpha = 0;

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

        void OnSwipeRight(HeadlineView sender)
        {
            var card = sender;
            var headline = card.Headline;

            if (lblHelper.Alpha != 0)
                lblHelper.Alpha = 0;
            
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
	        if (btnCorrect.Alpha == 0)
                btnCorrect.FadeIn(0.6, 0.2f);
                
            correctHub.Increment(1, NotificationAnimationType.Pop);
				
			var impact = new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Light);
			impact.Prepare ();
			impact.ImpactOccurred ();
			Analytics.TrackEvent("Answered Correctly");
		}

		void IncorrectAnswer()
		{
			 if (btnIncorrect.Alpha == 0)
                    btnIncorrect.FadeIn(0.6, 0.2f);
			
            incorrectHub.Increment(1, NotificationAnimationType.Pop);

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