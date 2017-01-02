using Foundation;
using System;
using UIKit;

namespace DailyFail
{
    public partial class ResultsTableViewController : UITableViewController
    {
        public ResultsTableViewController (IntPtr handle) : base (handle)
        {
        }

		partial void BtnFinish_Activated(UIBarButtonItem sender)
		{
			var navigationController = UIApplication.SharedApplication.KeyWindow.RootViewController as UINavigationController;
			navigationController.DismissModalViewController(true);
		}
	}
}