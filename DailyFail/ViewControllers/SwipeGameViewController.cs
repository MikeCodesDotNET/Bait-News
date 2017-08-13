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

			UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, true);
            btnRead.Alpha = 0;

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

            if (await Plugin.Connectivity.CrossConnectivity.Current.IsReachable("google.com"))
                btnRead.Alpha = 1.0f;

            cardHolder = new CardHolderView(cardPlaceholder.Frame, headlines.ToList());
            cardHolder.DidSwipeLeft += OnSwipeLeft;
            cardHolder.DidSwipeRight += OnSwipeRight;
            cardHolder.NoMoreCards += FinishGame;

			View.AddSubview(cardHolder);
        }

        async public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var connected = await Plugin.Connectivity.CrossConnectivity.Current.IsReachable("google.com");
            if (connected)
                btnRead.FadeIn(1, 0);

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

        async partial void BtnRead_TouchUpInside(UIButton sender)
        {
            var headline = cardHolder.VisibleHeadline;
            if (headline != null)
            {
                var safari = new SFSafariViewController(new NSUrl(headline.Url), true);
                safari.View.TintColor = btnFinish.BackgroundColor;
                await PresentViewControllerAsync(safari, true);
            }
        }

        partial void BtnFinish_TouchUpInside(UIButton sender)
        {
            //Could do something here..
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
                if (btnIncorrect.Alpha == 0)
                    btnIncorrect.FadeIn(0.6, 0.2f);
                
                incorrectHub.Increment(1, NotificationAnimationType.Pop);
                answer.CorrectAnswer = false;

				var impact = new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Heavy);
				impact.Prepare ();
				impact.ImpactOccurred ();
				Analytics.TrackEvent("Answered Incorrectly");
            }
            else
            {
                if (btnCorrect.Alpha == 0)
                    btnCorrect.FadeIn(0.6, 0.2f);
                
                correctHub.Increment(1, NotificationAnimationType.Pop);
                answer.CorrectAnswer = true;
				Analytics.TrackEvent("Answered Correctly");

				var impact = new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Light);
				impact.Prepare ();
				impact.ImpactOccurred ();
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
                if (btnCorrect.Alpha == 0)
                    btnCorrect.FadeIn(0.6, 0.2f);
                
                correctHub.Increment(1, NotificationAnimationType.Pop);
                answer.CorrectAnswer = true;
				var impact = new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Light);
				impact.Prepare ();
				impact.ImpactOccurred ();
				Analytics.TrackEvent("Answered Correctly");
            }
            else
            {
                if (btnIncorrect.Alpha == 0)
                    btnIncorrect.FadeIn(0.6, 0.2f);
                
                incorrectHub.Increment(1, NotificationAnimationType.Pop);
                answer.CorrectAnswer = false;
				var impact = new UIImpactFeedbackGenerator(UIImpactFeedbackStyle.Heavy);
				impact.Prepare ();
				impact.ImpactOccurred ();
				Analytics.TrackEvent("Answered Incorrectly");

            }
            answers.Add(answer);

        }

        void FinishGame()
        {
            DismissViewController(true, null);
        }
 }
}