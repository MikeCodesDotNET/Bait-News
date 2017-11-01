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
	public class SwipeGamePageModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
	
		List<Headline> items = new List<Headline>();
		public List<Headline> ItemsList
		{
			get	{
				return items;
			}
			set	{
				if (items == value)	{
					return;
				}
				items = value;
				OnPropertyChanged();
			}
		}
		
		protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
			
		protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			field = value;
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) {
				handler(this, new PropertyChangedEventArgs(propertyName));
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


            items.Add (new Headline () { Text = "Pizza to go", ImageUrl = "one.jpg", Url = "30 meters away", Source = "Pizza" });
            items.Add (new Headline () { Text = "Dragon & Peacock", ImageUrl = "two.jpg", Url = "800 meters away", Source = "Sweet & Sour"});
            items.Add (new Headline () { Text = "Murrays Food Palace", ImageUrl = "three.jpg", Url = "9 miles away", Source = "Salmon Plate" });
            items.Add (new Headline () { Text = "Food to go", ImageUrl = "four.jpg", Url = "4 miles away", Source = "Salad Wrap" });
            items.Add (new Headline () { Text = "Mexican Joint", ImageUrl = "five.jpg", Url = "2 miles away", Source = "Chilli Bites" });
            items.Add (new Headline () { Text = "Mr Bens", ImageUrl = "six.jpg", Url = "1 mile away", Source = "Beef" });
            items.Add (new Headline () { Text = "Corner Shop", ImageUrl = "seven.jpg", Url = "100 meters away", Source = "Burger & Chips" });
            items.Add (new Headline () { Text = "Sarah's Cafe", ImageUrl = "eight.jpg", Url = "6 miles away", Source = "House Breakfast" });
            items.Add (new Headline () { Text = "Pata Place", ImageUrl = "nine.jpg", Url = "2 miles away", Source = "Chicken Curry" });
            items.Add (new Headline () { Text = "Jerrys", ImageUrl = "ten.jpg", Url = "8 miles away", Source = "Pasta Salad" });
        }
	}
}

