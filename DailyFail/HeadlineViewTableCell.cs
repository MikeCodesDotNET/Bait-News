using Foundation;
using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;

namespace DailyFail
{
    public partial class HeadlineViewTableCell : UITableViewCell
    {
		UIView gradientView;
        public HeadlineViewTableCell (IntPtr handle) : base (handle)
        {
        }

		public HeadlineViewTableCell(UITableViewCellStyle style, NSString reuseIdentifier) : base(style, reuseIdentifier)
		{	
		}



		public string Headline
		{
			get
			{
				return lblHeadline.Text;
			}
			set
			{
				lblHeadline.Layer.ShadowOffset = new CGSize(0, 0);
				lblHeadline.Layer.ShadowOpacity = 1;
				lblHeadline.Layer.ShadowRadius = 2;

				lblHeadline.Text = value;
			}
		}

		public UIImageView ImageView
		{
			get
			{
				return imgHeadline;
			}
			set
			{
				imgHeadline = value;
			}
		}

    }
}