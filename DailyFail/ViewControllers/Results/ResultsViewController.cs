using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BaitNews.Models;
using System.Linq;
using MikeCodesDotNET.iOS;
using BaitNews.CustomControls;
using BaitNews;
using CoreGraphics;

namespace BaitNews
{
    public partial class ResultsViewController : UIViewController
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
			contentView.Frame = new CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			View.BackgroundColor = "717276".ToUIColor();
			var correctCount = Answers.Where(x => x.CorrectAnswer).Count();

			lblcount.Text = correctCount.ToString();
			lbltotalCount.Text = Answers.Count().ToString();

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
					lblcount.Text = correctCount.ToString();
					lbltotalCount.Text = Answers.Count().ToString();
				}
				else
				{
					lblcount.Text = wrongAnswers.Count.ToString();
					lbltotalCount.Text = Answers.Count().ToString();
				}
            };

			btnOk.Layer.CornerRadius = 4;
			contentView.BackgroundColor = "1C1F27".ToUIColor();
		}

      
        partial void BtnOk_TouchUpInside(UIButton sender)
        {
			//TODO Save answers to backend.

			var navigationController = UIApplication.SharedApplication.KeyWindow.RootViewController.ChildViewControllers.First() as UINavigationController;
			navigationController.DismissModalViewController(true);        
        }

	}


}