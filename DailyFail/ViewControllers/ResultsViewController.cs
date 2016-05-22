using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using DailyFail.Models;
using System.Linq;
using MikeCodesDotNET.iOS;

namespace DailyFail
{
    public partial class ResultsViewController : UIViewController
    {
        public List<Answer> Answers;

        public ResultsViewController (IntPtr handle) : base (handle)
        {
            Answers = new List<Answer>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            lblWrong.Alpha = 0;
            lblCorrect.Alpha = 0;
            imgTick.Alpha = 0;
            imgCross.Alpha = 0;
            lblMessage.Alpha = 0;

            var wrongCount = Answers.Where(x => x.CorrectAnswer == false).Count();
            var correctCount = Answers.Where(x => x.CorrectAnswer).Count();

            lblWrong.Text = $"{wrongCount} Wrong";
            lblCorrect.Text = $"{correctCount} Correct";
        }

        public override void ViewDidAppear(bool animated)
        {
            lblCorrect.FadeIn(0.2, 0);
            imgTick.FadeIn(0.2, 0);

            lblWrong.FadeIn(0.2, 0.3f);
            imgCross.FadeIn(0.2, 0.3f);

            lblMessage.FadeIn(0.2, 0.6f);

        }

        partial void BtnClose_TouchUpInside(UIButton sender)
        {
            var navigationController = UIApplication.SharedApplication.KeyWindow.RootViewController as UINavigationController;
            navigationController.DismissModalViewController(true);
        }
    }
}