using Foundation;
using System;
using UIKit;

using System.Collections.Generic;

using Google.Apis;
using MikeCodesDotNET.iOS;
using BaitNews.Models;
using SDWebImage;
using System.Linq;
using AppServiceHelpers;
using DailyFail;
using CoreAnimation;
using CoreGraphics;

namespace DailyFail
{
	public partial class HomeTableViewController : UITableViewController
	{
		public HomeTableViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			Refresh();
		}

		public async void Refresh()
		{
			var table = EasyMobileServiceClient.Current.Table<Headline>();
			var headlines = await table.GetItemsAsync();
			var datasource = new HomeTableViewDataSource(headlines.ToList());
			TableView.DataSource = datasource;
			TableView.ReloadData();
		}
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

			cell.ImageView.SetImage(
					url: new NSUrl(Headline[indexPath.Row].ImageUrl),
					placeholder: UIImage.FromBundle("logo.png")
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

}



