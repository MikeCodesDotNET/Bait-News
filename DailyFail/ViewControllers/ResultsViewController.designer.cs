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
    [Register ("ResultsViewController")]
    partial class ResultsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnClose { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgCross { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgTick { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCorrect { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMessage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblWrong { get; set; }

        [Action ("BtnClose_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnClose_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnClose != null) {
                btnClose.Dispose ();
                btnClose = null;
            }

            if (imgCross != null) {
                imgCross.Dispose ();
                imgCross = null;
            }

            if (imgTick != null) {
                imgTick.Dispose ();
                imgTick = null;
            }

            if (lblCorrect != null) {
                lblCorrect.Dispose ();
                lblCorrect = null;
            }

            if (lblMessage != null) {
                lblMessage.Dispose ();
                lblMessage = null;
            }

            if (lblWrong != null) {
                lblWrong.Dispose ();
                lblWrong = null;
            }
        }
    }
}