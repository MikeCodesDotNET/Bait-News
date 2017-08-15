using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAnimation;
using Foundation;
using UIKit;

namespace Awesomizer
{
	public static class Extensions
	{
         private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


		/*
		 Loads an image from a URL. If cached, the cached image is returned. Otherwise, a place holder is used until the image from web is returned by the closure.

		 - Parameter url: The image URL.
     	 - Parameter placeholder: The placeholder image.
     	 - Parameter fadeIn: Weather the mage should fade in.
     	 - Parameter closure: Returns the image from the web the first time is fetched.
          - Returns A new image
		*/

		public static UIImageView ImageFromUrl(UIImageView imageView, string url, UIImage placeholder, bool fadeIn = true)
		{
			var image = FromUrl(url);
			if (image == null)
				return null;

			if (fadeIn)
			{
				var crossFade = new CABasicAnimation();
				crossFade.KeyPath = "contents";
				crossFade.Duration = 0.5;
				crossFade.From = imageView.Image.CIImage;
				crossFade.To = NSObject.FromObject(image.CGImage);
				imageView.Layer.AddAnimation(crossFade, "");
			}
			imageView.Image = image;
			return imageView;
		}
   
		public static UIImage FromUrl(string url)
		{
			using (var nsUrl = new NSUrl(url))
			using (var data = NSData.FromUrl(nsUrl ))
				return UIImage.LoadFromData(data);
		}

	}
}

