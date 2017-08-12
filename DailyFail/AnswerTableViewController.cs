using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using BaitNews.Models;
using System.Linq;
using MikeCodesDotNET.iOS;
using CoreGraphics;
using SafariServices;

namespace DailyFail
{
    public partial class AnswerTableViewController : UITableViewController
    {
		public AnswerTableViewDataSource DataSource;
        public AnswerTableViewController (IntPtr handle) : base (handle)
        {
			TableView.BackgroundColor = "1C1F27".ToUIColor();
        }

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			TableView.SetNeedsDisplay();
		}

		public List<Answer> Answers = new List<Answer>();

		public void Refresh()
		{
			var ds = new AnswerTableViewDataSource(Answers);
			DataSource = ds;
			TableView.DataSource = DataSource;
			TableView.ReloadData();

			if (TraitCollection.ForceTouchCapability == UIForceTouchCapability.Available)
			{
                RegisterForPreviewingWithDelegate(new PreviewingDelegate(this), View);
				Console.WriteLine("Registered for 3D Touch");
			}
		}

		public void CommitViewController(IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
		{
            ShowViewController(viewControllerToCommit,this);
		}

		public override async void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var safariViewController = new SFSafariViewController(new NSUrl(Answers[indexPath.Row].Headline.Url), true);
			await ParentViewController.PresentViewControllerAsync(safariViewController, true);
		}
	}

	public class AnswerTableViewDataSource : UITableViewDataSource
	{
		static NSString cellIdentifier = new NSString("AnswerCell");
		public List<Answer> Answers;
		public AnswerTableViewDataSource(List<Answer> answers)
		{
			this.Answers = answers;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (AnswerTableViewCell)tableView.DequeueReusableCell(cellIdentifier);

        	if (cell == null)
            	cell = new AnswerTableViewCell(UITableViewCellStyle.Default, cellIdentifier);

			cell.Headlinee = Answers[indexPath.Row].Headline.Text;
			cell.Numberr = (indexPath.Row + 1).ToString();
			cell.Publisher = Answers[indexPath.Row].Headline.Publisher;
			cell.SelectedBackgroundView.BackgroundColor = "222630".ToUIColor();
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
        	return cell;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return Answers.Count();
		}
	}

	public class PreviewingDelegate : UIViewControllerPreviewingDelegate
	{
		public AnswerTableViewController MasterController { get; set; }
		public PreviewingDelegate(AnswerTableViewController masterController)
		{
			MasterController = masterController;
		}

		public PreviewingDelegate(NSObjectFlag t) : base(t)
		{
		}

		public PreviewingDelegate(IntPtr handle) : base(handle)
		{
		}

		/// Present the view controller for the "Pop" action.
		public override void CommitViewController(IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
		{
			// Reuse Peek view controller for details presentation
			MasterController.ShowViewController(viewControllerToCommit, this);
		}

		/// Create a previewing view controller to be shown at "Peek".
		public override UIViewController GetViewControllerForPreview(IUIViewControllerPreviewing previewingContext, CGPoint location)
		{
			Console.WriteLine("GetViewControllerForPreview-Called");

			// Grab the item to preview
			var indexPath = MasterController.TableView.IndexPathForRowAtPoint(location);
			var cell = MasterController.TableView.CellAt(indexPath);
			var item = MasterController.DataSource.Answers[indexPath.Row];

			// Grab a controller and set it to the default sizes

			var safariViewController = new SFSafariViewController(new NSUrl(MasterController.Answers[indexPath.Row].Headline.Url), true);
			safariViewController.PreferredContentSize = new CGSize(0, 0);

			// Set the source rect to the cell frame, so everything else is blurred.
			previewingContext.SourceRect = cell.Frame;
			return safariViewController;
		}
	 }
}