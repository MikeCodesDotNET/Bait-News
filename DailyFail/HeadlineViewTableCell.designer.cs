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
    [Register ("HeadlineViewTableCell")]
    partial class HeadlineViewTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imgHeadline { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblHeadline { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imgHeadline != null) {
                imgHeadline.Dispose ();
                imgHeadline = null;
            }

            if (lblHeadline != null) {
                lblHeadline.Dispose ();
                lblHeadline = null;
            }
        }
    }
}