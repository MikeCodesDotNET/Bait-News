using Foundation;
using System;
using UIKit;

using BaitNews.CustomControls;
using System.Collections.Generic;
using MikeCodesDotNET.iOS;

namespace DailyFail
{
    public partial class SubmitMasterViewController : UIViewController
    {
		ScrollingTabView tabView;
		SubmitHeadline headlineView;
		SubmitPrintedNews printedNewsView;

        public SubmitMasterViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			headlineView = Storyboard.InstantiateViewController("SubmitHeadline") as SubmitHeadline;
			headlineView.Title = "Headline";

			printedNewsView = Storyboard.InstantiateViewController("SubmitPrintedNews") as SubmitPrintedNews;
			printedNewsView.Title = "News Around the World ";

			var viewControllers = new List<UIViewController>();
			viewControllers.Add(headlineView);
			viewControllers.Add(printedNewsView);

			tabView = new ScrollingTabView(viewControllers);
			tabView.Font = UIFont.FromName("Avenir-Medium", 14f);
			tabView.Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);
			tabView.TabTextColor = "717276".ToUIColor();
			tabView.SelectedTabTextColor = UIColor.White;
			tabView.BackgroundColor = UIColor.Clear;
			tabView.TabbarBackgroundColor = UIColor.Clear;
			tabView.SelectedTabUnderlineColor = "15A9FE".ToUIColor();
			tabView.SelectionChanged += delegate {};
			tabViewContainer.Add(tabView);
		}

		partial void BtnBack_Activated(UIBarButtonItem sender)
		{
			NavigationController.PopViewController(true);
		}
	}
}