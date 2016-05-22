// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DailyFail
{
    [Register ("SwipeGameViewController")]
    partial class SwipeGameViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnCorrect { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnFinish { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnIncorrect { get; set; }

        [Action ("BtnFinish_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnFinish_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnCorrect != null) {
                btnCorrect.Dispose ();
                btnCorrect = null;
            }

            if (btnFinish != null) {
                btnFinish.Dispose ();
                btnFinish = null;
            }

            if (btnIncorrect != null) {
                btnIncorrect.Dispose ();
                btnIncorrect = null;
            }
        }
    }
}