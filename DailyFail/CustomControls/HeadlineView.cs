﻿using System;
using UIKit;
using CoreGraphics;
using Foundation;
using BaitNews.Models;
using MikeCodesDotNET.iOS;

namespace BaitNews.CustomControls
{
	public class HeadlineView : DraggableView
	{
		public HeadlineView(Headline headline)
		{
            Headline = headline;
			title = headline.Text;
		}

        public HeadlineView()
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
			BackgroundColor = UIColor.Clear;
			//// General Declarations
			var context = UIGraphics.GetCurrentContext();

			//// Color Declarations
			var borderColor = "606060".ToUIColor();
			var textColor = UIColor.White;

			//// Shadow Declarations
			var shadow = new NSShadow();
			shadow.ShadowColor = UIColor.Black.ColorWithAlpha(0.07f);
			shadow.ShadowOffset = new CGSize(0.1f, -0.1f);
			shadow.ShadowBlurRadius = 10.0f;

			//// Rectangle Drawing
			var rectanglePath = UIBezierPath.FromRoundedRect(new CGRect(rect.GetMinX() + 10.0f, rect.GetMinY() + 10.0f, rect.Width - 26.0f, rect.Height - 21.5f), 4.0f);
			context.SaveState();
			context.SetShadow(shadow.ShadowOffset, shadow.ShadowBlurRadius, shadow.ShadowColor.CGColor);
			"272727".ToUIColor().SetFill();
			rectanglePath.Fill();
			context.RestoreState();

			borderColor.SetStroke();
			rectanglePath.LineWidth = 1.0f;
			rectanglePath.Stroke();


			//// Text Drawing
			CGRect textRect = new CGRect(rect.GetMinX() + 28.0f, rect.GetMinY() + 10.0f, rect.Width - 62.0f, rect.Height - 22.0f);
			textColor.SetFill();
			var textStyle = new NSMutableParagraphStyle();
			textStyle.Alignment = UITextAlignment.Center;

			var textFontAttributes = new UIStringAttributes() { Font = UIFont.FromName("AvenirNext-Regular", UIFont.LabelFontSize), ForegroundColor = textColor, ParagraphStyle = textStyle };
			var textTextHeight = new NSString(title).GetBoundingRect(new CGSize(textRect.Width, nfloat.MaxValue), NSStringDrawingOptions.UsesLineFragmentOrigin, textFontAttributes, null).Height;
			context.SaveState();
			context.ClipToRect(textRect);
			new NSString(title).DrawString(new CGRect(textRect.GetMinX(), textRect.GetMinY() + (textRect.Height - textTextHeight) / 2.0f, textRect.Width, textTextHeight), UIFont.FromName("AvenirNext-Regular", UIFont.LabelFontSize), UILineBreakMode.WordWrap, UITextAlignment.Center);
			context.RestoreState();
		}
	}
}

