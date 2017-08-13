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

namespace BaitNews
{
    [Register ("ResultsViewController")]
    partial class ResultsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnOk { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView contentView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblcount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblScore { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbltotalCount { get; set; }

        [Action ("BtnOk_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnOk_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnOk != null) {
                btnOk.Dispose ();
                btnOk = null;
            }

            if (contentView != null) {
                contentView.Dispose ();
                contentView = null;
            }

            if (lblcount != null) {
                lblcount.Dispose ();
                lblcount = null;
            }

            if (lblScore != null) {
                lblScore.Dispose ();
                lblScore = null;
            }

            if (lbltotalCount != null) {
                lbltotalCount.Dispose ();
                lbltotalCount = null;
            }
        }
    }
}