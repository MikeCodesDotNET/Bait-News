using System;
using UIKit;
using CoreGraphics;
using Foundation;
using BaitNews.Models;
using MikeCodesDotNET.iOS;
using Awesomizer;

namespace BaitNews.CustomControls
{
	public class HeadlineCardView : DraggableView
	{
		public HeadlineCardView(Headline headline)
		{
            Headline = headline;
			title = headline.Text;
		}

        public HeadlineCardView()
        {
        }

		string title;
		public string Title
		{
			get
			{
				return title;
			}
		}

        Headline headline;
        public Headline Headline
        {
            get
            {
                return headline;
            }
            set
            {
                headline = value;
                title = headline.Text;
				SetNeedsDisplay();
            }
        }

		public override void Draw(CGRect rect)
		{
			base.Draw(rect);
			DrawHeadlineCardView(rect, title);
			AddDummyContent(rect);
		}

		void AddDummyContent(CGRect frame)
		{
			var imageView = new UIImageView(UIImage.FromBundle("cardContent1.png"));
			imageView.Frame = new CGRect(frame.GetMinX() + 22.0f, frame.GetMinY() + NMath.Floor((frame.Height - 30.0f) * 0.35813f + 0.5f), frame.Width - 41.0f, frame.Height - 30.0f - NMath.Floor((frame.Height - 30.0f) * 0.35813f + 0.5f));

		}

private void DrawHeadlineCardView(CGRect frame, string title)
{
	//// General Declarations
	var context = UIGraphics.GetCurrentContext();

	//// Color Declarations
	var fillColor3 = UIColor.FromRGBA(0.253f, 0.274f, 0.326f, 1.000f);
	var textForeground2 = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
	var strokeColor3 = UIColor.FromRGBA(0.580f, 0.580f, 0.580f, 0.223f);
	var textForeground3 = UIColor.FromRGBA(0.582f, 0.582f, 0.582f, 0.517f);

            //// Image Declarations
            var image = new UIImage();


	//// Subframes
	var group = new CGRect(frame.GetMinX() + 21.0f, frame.GetMinY() + 26.0f, NMath.Floor((frame.Width - 21.0f) * 0.25663f + 20.63f) - 20.13f, NMath.Floor((frame.Height - 26.0f) * 0.04087f + 0.5f));


	//// Rectangle 12 Drawing
	var rectangle12Path = UIBezierPath.FromRoundedRect(new CGRect(frame.GetMinX() + 12.0f, frame.GetMinY() + 12.98f, frame.Width - 23.0f, frame.Height - 27.75f), 2.0f);
	fillColor3.SetFill();
	rectangle12Path.Fill();


	//// Label 10 Drawing
	var label10Rect = new CGRect(frame.GetMinX() + 22.0f, frame.GetMinY() + 41.0f, frame.Width - 47.0f, frame.Height - 304.0f);
	textForeground2.SetFill();
	var label10Style = new NSMutableParagraphStyle();
	label10Style.Alignment = UITextAlignment.Left;
	var label10FontAttributes = new UIStringAttributes { Font = UIFont.FromName("Avenir-Black", 18.0f), ForegroundColor = textForeground2, ParagraphStyle = label10Style };
	var label10TextHeight = new NSString(title).GetBoundingRect(new CGSize(label10Rect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, label10FontAttributes, null).Height;
	context.SaveState();
	context.ClipToRect(label10Rect);
	new NSString(title).DrawString(new CGRect(label10Rect.GetMinX(), label10Rect.GetMinY() + (label10Rect.Height - label10TextHeight) / 2.0f, label10Rect.Width, label10TextHeight), label10FontAttributes);
	context.RestoreState();


	//// Picture Drawing
	var pictureRect = new CGRect(frame.GetMinX() + 22.0f, frame.GetMinY() + NMath.Floor((frame.Height - 30.0f) * 0.35813f + 0.5f), frame.Width - 41.0f, frame.Height - 30.0f - NMath.Floor((frame.Height - 30.0f) * 0.35813f + 0.5f));
	var picturePath = UIBezierPath.FromRect(pictureRect);
	context.SaveState();
	picturePath.AddClip();
	context.TranslateCTM(NMath.Floor(pictureRect.GetMinX() + 0.5f), NMath.Floor(pictureRect.GetMinY() + 0.5f));
	context.ScaleCTM(1.0f, -1.0f);
	context.TranslateCTM(0.0f, -image.Size.Height);
	context.DrawImage(new CGRect(0.0f, 0.0f, image.Size.Width, image.Size.Height), image.CGImage);
	context.RestoreState();


	//// Group
	{
		//// Bezier Drawing
		var bezierPath = new UIBezierPath();
		bezierPath.MoveTo(new CGPoint(group.GetMinX() + 0.00795f * group.Width, group.GetMinY() + 0.96667f * group.Height));
		bezierPath.AddLineTo(new CGPoint(group.GetMinX() + 0.99405f * group.Width, group.GetMinY() + 0.96667f * group.Height));
		strokeColor3.SetStroke();
		bezierPath.LineWidth = 1.0f;
		bezierPath.LineCapStyle = CGLineCap.Square;
		bezierPath.Stroke();


		//// Label 4 Drawing
		var label4Rect = new CGRect(group.GetMinX() + NMath.Floor(group.Width * 0.00000f + 0.5f), group.GetMinY() + NMath.Floor(group.Height * 0.00000f + 0.5f), NMath.Floor(group.Width * 1.00000f - 0.37f) - NMath.Floor(group.Width * 0.00000f + 0.5f) + 0.87f, NMath.Floor(group.Height * 1.00000f + 0.5f) - NMath.Floor(group.Height * 0.00000f + 0.5f));
		{
			var textContent = "Bait News";
			textForeground3.SetFill();
			var label4Style = new NSMutableParagraphStyle();
			label4Style.Alignment = UITextAlignment.Center;
			var label4FontAttributes = new UIStringAttributes { Font = UIFont.FromName("Marion-Bold", 14.0f), ForegroundColor = textForeground3, ParagraphStyle = label4Style };
			var label4TextHeight = new NSString(textContent).GetBoundingRect(new CGSize(label4Rect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, label4FontAttributes, null).Height;
			context.SaveState();
			context.ClipToRect(label4Rect);
			new NSString(textContent).DrawString(new CGRect(label4Rect.GetMinX(), label4Rect.GetMinY() + (label4Rect.Height - label4TextHeight) / 2.0f, label4Rect.Width, label4TextHeight), label4FontAttributes);
			context.RestoreState();
		}
	}
}

	}
}

