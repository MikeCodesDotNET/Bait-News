using Foundation;
using System;
using UIKit;

namespace DailyFail
{
    public partial class SadPandaViewController : UIViewController
    {
        public SadPandaViewController (IntPtr handle) : base (handle)
        {
        }



		partial void BtnAlright_TouchUpInside(UIButton sender)
		{
			DismissViewController(true, null);
		}
	}
}