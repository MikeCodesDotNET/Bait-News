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
    [Register ("ResultsTableViewController")]
    partial class ResultsTableViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem btnFinish { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView correctView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView incorrectView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblCorrect { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblWrong { get; set; }

        [Action ("BtnFinish_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnFinish_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnFinish != null) {
                btnFinish.Dispose ();
                btnFinish = null;
            }

            if (correctView != null) {
                correctView.Dispose ();
                correctView = null;
            }

            if (incorrectView != null) {
                incorrectView.Dispose ();
                incorrectView = null;
            }

            if (lblCorrect != null) {
                lblCorrect.Dispose ();
                lblCorrect = null;
            }

            if (lblWrong != null) {
                lblWrong.Dispose ();
                lblWrong = null;
            }
        }
    }
}