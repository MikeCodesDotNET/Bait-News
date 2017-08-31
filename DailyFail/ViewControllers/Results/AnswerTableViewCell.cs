using Foundation;
using System;
using UIKit;
using MikeCodesDotNET.iOS;

namespace BaitNews
{
    public partial class AnswerTableViewCell : UITableViewCell
    {
        public AnswerTableViewCell (IntPtr handle) : base (handle)
        {
        }

		public AnswerTableViewCell(UITableViewCellStyle style, NSString reuseIdentifier) : base(style, reuseIdentifier)
		{
		}

		public string Headlinee
		{
			get
			{
				return lblHeadline.Text;
			}
			set
			{
				lblHeadline.Text = value;
			}
		}

		public string Publisher
		{
			get
			{
				return lblPublisher.Text;
			}
			set
			{
				lblPublisher.Text = value;
			}
		}

		public string Numberr
		{
			get
			{
				return lblNumber.Text;
			}
			set
			{
				lblNumber.Text = value;
			}
		}
	}
}