using Foundation;
using System;
using UIKit;

using System.Collections.Generic;

using MikeCodesDotNET.iOS;
using BaitNews.Models;
using SDWebImage;
using System.Linq;
using BaitNews;
using CoreAnimation;
using CoreGraphics;
using Microsoft.Azure.Mobile.Analytics;
using SafariServices;

namespace BaitNews
{
	public partial class HomeTableViewController : UITableViewController
	{
		public HomeTableViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			Refresh();

			if (TraitCollection.ForceTouchCapability == UIForceTouchCapability.Available)
			{
                RegisterForPreviewingWithDelegate(new HomePreviewingDelegate(this), View);
			}
		}

		public async void Refresh()
		{
            var headlineService = new Services.Headlines.HeadlineService(new Services.Headlines.HeadlineApiService());
            var headlines = await headlineService.GetHeadlines(Fusillade.Priority.UserInitiated);

            DataSource = new HomeTableViewDataSource(headlines.ToList());
			TableView.DataSource = DataSource;
			TableView.ReloadData();
		}

		public HomeTableViewDataSource DataSource { get; set; }
	}

	public class HomeTableViewDataSource : UITableViewDataSource
	{
		static NSString cellIdentifier = new NSString("HeadlineViewTableCell");
		public List<Headline> Headline;
		public HomeTableViewDataSource(List<Headline> headlines)
		{
			Headline = headlines.Where(x => x.ImageUrl != null).ToList();
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (HeadlineViewTableCell)tableView.DequeueReusableCell(cellIdentifier);

			if (cell == null)
				cell = new HeadlineViewTableCell(UITableViewCellStyle.Default, cellIdentifier);

            cell.ImageView.SetImage(new NSUrl(Headline[indexPath.Row].ImageUrl),
                                    UIImage.FromBundle("logo.png"), 
                                    SDWebImageOptions.ProgressiveDownload
			);
            
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.Headline = Headline[indexPath.Row].Text;

			return cell;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return Headline.Count();
		}	
	}

	public class HomePreviewingDelegate : UIViewControllerPreviewingDelegate
	{
		public HomeTableViewController TableController { get; set; }
		public HomePreviewingDelegate(HomeTableViewController controller)
		{
			TableController = controller;
		}

		public HomePreviewingDelegate(NSObjectFlag t) : base(t)
		{
		}

		public HomePreviewingDelegate(IntPtr handle) : base(handle)
		{
		}

		/// Present the view controller for the "Pop" action.
		public override void CommitViewController(IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
		{
			// Reuse Peek view controller for details presentation
			TableController.ShowViewController(viewControllerToCommit, this);
		}

		/// Create a previewing view controller to be shown at "Peek".
		public override UIViewController GetViewControllerForPreview(IUIViewControllerPreviewing previewingContext, CGPoint location)
		{
			Analytics.TrackEvent("User used 3D Touch");

			// Grab the item to preview
			var indexPath = TableController.TableView.IndexPathForRowAtPoint(location);
			var cell = TableController.TableView.CellAt(indexPath);
			var item = TableController.DataSource.Headline[indexPath.Row];

			var safariViewController = new SFSafariViewController(new NSUrl(item.Url), true);
			safariViewController.PreferredContentSize = new CGSize(0, 0);

			// Set the source rect to the cell frame, so everything else is blurred.
			previewingContext.SourceRect = cell.Frame;
			return safariViewController;
		} 
	
	}

}



