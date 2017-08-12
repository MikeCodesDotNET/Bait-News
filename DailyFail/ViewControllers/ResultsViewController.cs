using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BaitNews.Models;
using System.Linq;
using MikeCodesDotNET.iOS;
using BaitNews.CustomControls;
using DailyFail;
using AppServiceHelpers;
using CoreGraphics;

namespace BaitNews
{
    public partial class ResultsViewController : UIViewController, IUIViewControllerPreviewingDelegate
    {
        public List<Answer> Answers = new List<Answer>();
		ScrollingTabView tabView;
		public AnswerTableViewController VcCorrect;
		public AnswerTableViewController VcWrong;

        public ResultsViewController (IntPtr handle) : base (handle)
        {

			VcCorrect = Storyboard.InstantiateViewController("AnswerTableViewController") as AnswerTableViewController;
			VcCorrect.Title = "Correct";

			VcWrong = Storyboard.InstantiateViewController("AnswerTableViewController") as AnswerTableViewController;
			VcWrong.Title = "Wrong";

			var viewControllers = new List<UIViewController>();
			viewControllers.Add(VcCorrect);
			viewControllers.Add(VcWrong);

			tabView = new CustomControls.ScrollingTabView(viewControllers);
			tabView.Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
			tabView.TabTextColor = "717276".ToUIColor();
			tabView.SelectedTabTextColor = UIColor.White;
			tabView.BackgroundColor = UIColor.Clear;
			tabView.TabbarBackgroundColor = UIColor.Clear;


			contentView.Add(tabView);

        }

		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.BlackTranslucent;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            NavigationController.NavigationBar.BarStyle = UIBarStyle.BlackTranslucent;
			contentView.Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			View.BackgroundColor = "717276".ToUIColor();
			var correctCount = Answers.Where(x => x.CorrectAnswer).Count();
			lblScore.Text = ($"{correctCount} - {Answers.Count()}");

			var correctAnswers = Answers.Where(x => x.CorrectAnswer == true).ToList();
			VcCorrect.Answers = correctAnswers;
			VcCorrect.Refresh();

			var wrongAnswers = Answers.Where(x => x.CorrectAnswer == false).ToList();
			VcWrong.Answers = wrongAnswers;
			VcWrong.Refresh();

			if (correctAnswers.Count() == 0 && wrongAnswers.Count() > 0)
			{
				var vc = Storyboard.InstantiateViewController("SadPandaViewController");
				ShowViewController(vc, this);
			}

			tabView.SelectionChanged += (index, title) =>
            {
				if (index == 0)
				{
					lblScore.Text = ($"{correctCount} - {Answers.Count()}");
					lblScore.Pop(0.2, 1, 1f);
				}
				else
				{
					lblScore.Text = ($"{wrongAnswers.Count()} - {Answers.Count()}");
					lblScore.Pop(0.2, 1, 1f);
				}
            };

			btnOk.Layer.CornerRadius = 4;
			lblScore.Pop(0.1, 1, 0.2f);
			contentView.BackgroundColor = "1C1F27".ToUIColor();
		}

      
        partial void BtnOk_TouchUpInside(UIButton sender)
        {
			var answers = EasyMobileServiceClient.Current.Table<Answer>();
			foreach (var answer in Answers)
			{
				answers.AddAsync(answer);
			}
			answers.Sync();

			var navigationController = UIApplication.SharedApplication.KeyWindow.RootViewController as UINavigationController;
			navigationController.DismissModalViewController(true);        
        }

		public UIViewController GetViewControllerForPreview(IUIViewControllerPreviewing previewingContext, CGPoint location)
		{
			throw new NotImplementedException();
		}

		public void CommitViewController(IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
		{
			throw new NotImplementedException();
		}
	}


}