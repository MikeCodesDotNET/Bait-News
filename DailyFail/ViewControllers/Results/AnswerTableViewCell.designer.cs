// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BaitNews
{
    [Register ("AnswerTableViewCell")]
    partial class AnswerTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblHeadline { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblPublisher { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblHeadline != null) {
                lblHeadline.Dispose ();
                lblHeadline = null;
            }

            if (lblNumber != null) {
                lblNumber.Dispose ();
                lblNumber = null;
            }

            if (lblPublisher != null) {
                lblPublisher.Dispose ();
                lblPublisher = null;
            }
        }
    }
}