using Foundation;
using System;
using UIKit;

namespace BaitNews
{
    public partial class SettingsViewController : UITableViewController
    {
        public SettingsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			Title = "Settings";

           // var versionNumber = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
           // var buildNumber = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();

           // lblBuildVersion.Text = $"Version {versionNumber} build {buildNumber}";

        }
    }


}