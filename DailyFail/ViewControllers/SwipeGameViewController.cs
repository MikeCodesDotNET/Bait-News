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
            EasyMobileServiceClient.Current.Initialize(Helpers.Keys.AzureServiceUrl);
            EasyMobileServiceClient.Current.RegisterTable<Headline>();
			EasyMobileServiceClient.Current.FinalizeSchema();

            headlines = new ConnectedObservableCollection<Headline>(EasyMobileServiceClient.Current.Table<Headline>());

            answers = new List<Answer>();
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
            if (segue.Identifier == segueIdentifier)
            {
                var vc = (ResultsViewController)segue.DestinationViewController;
                if (vc == null)
                    return;

                vc.Answers = answers;
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

            var answer = new Answer() { Headline = headline };

            //User believes headline to be false
            if (headline.IsTrue)
            {
                if (btnIncorrect.Alpha == 0)
                    btnIncorrect.FadeIn(0.6, 0.2f);
                
                incorrectHub.Increment(1, NotificationAnimationType.Pop);
                answer.CorrectAnswer = false;
            }
            else
            {
                if (btnCorrect.Alpha == 0)
                    btnCorrect.FadeIn(0.6, 0.2f);
                
                correctHub.Increment(1, NotificationAnimationType.Pop);
                answer.CorrectAnswer = true;
            }
            answers.Add(answer);
        }

        void OnSwipeRight(HeadlineView sender)
        {
            var card = sender;
            var headline = card.Headline;

            if (lblHelper.Alpha != 0)
                lblHelper.Alpha = 0;
            
            var answer = new Answer() { Headline = headline };

            //User believes headline to be true
            if (headline.IsTrue)
            {
                if (btnCorrect.Alpha == 0)
                    btnCorrect.FadeIn(0.6, 0.2f);
                
                correctHub.Increment(1, NotificationAnimationType.Pop);
                answer.CorrectAnswer = true;
            }
            else
            {
                if (btnIncorrect.Alpha == 0)
                    btnIncorrect.FadeIn(0.6, 0.2f);
                
                incorrectHub.Increment(1, NotificationAnimationType.Pop);
                answer.CorrectAnswer = false;
            }
            answers.Add(answer);

        }

        void FinishGame()
        {
            DismissViewController(true, null);
        }
 }
}