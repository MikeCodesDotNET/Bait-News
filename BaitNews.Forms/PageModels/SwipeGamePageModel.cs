//
//  Copyright (c) 2016 MatchboxMobile
//  Licensed under The MIT License (MIT)
//  http://opensource.org/licenses/MIT
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
//  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
//  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
//  IN THE SOFTWARE.
//
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BaitNews.Forms.Models;

namespace BaitNews.Forms.PageModels
{
	public class SwipeGamePageModel : FreshMvvm.FreshBasePageModel
	{	
        List<Headline> headlines = new List<Headline>();
        public List<Headline> Headlines
		{
			get	{
				return headlines;
			}
			set	{
				if (headlines == value)	{
					return;
				}
				headlines = value;
                RaisePropertyChanged();
			}
		}

		
		public SwipeGamePageModel()
		{
            /*
            var headlineService = new Services.HeadlineService();
            var headliens = headlineService.GetAll().Result;
            foreach(var headline in headliens)
            {
                items.Add(headline);
            }*/


            headlines.Add (new Headline () { Text = "Pizza to go", ImageUrl = "one.jpg", Url = "30 meters away", Source = "Pizza" });
            headlines.Add (new Headline () { Text = "Dragon & Peacock", ImageUrl = "two.jpg", Url = "800 meters away", Source = "Sweet & Sour"});
            headlines.Add (new Headline () { Text = "Murrays Food Palace", ImageUrl = "three.jpg", Url = "9 miles away", Source = "Salmon Plate" });
            headlines.Add (new Headline () { Text = "Food to go", ImageUrl = "four.jpg", Url = "4 miles away", Source = "Salad Wrap" });
            headlines.Add (new Headline () { Text = "Mexican Joint", ImageUrl = "five.jpg", Url = "2 miles away", Source = "Chilli Bites" });
            headlines.Add (new Headline () { Text = "Mr Bens", ImageUrl = "six.jpg", Url = "1 mile away", Source = "Beef" });
            headlines.Add (new Headline () { Text = "Corner Shop", ImageUrl = "seven.jpg", Url = "100 meters away", Source = "Burger & Chips" });
            headlines.Add (new Headline () { Text = "Sarah's Cafe", ImageUrl = "eight.jpg", Url = "6 miles away", Source = "House Breakfast" });
            headlines.Add (new Headline () { Text = "Pata Place", ImageUrl = "nine.jpg", Url = "2 miles away", Source = "Chicken Curry" });
            headlines.Add (new Headline () { Text = "Jerrys", ImageUrl = "ten.jpg", Url = "8 miles away", Source = "Pasta Salad" });
        }
	}
}

