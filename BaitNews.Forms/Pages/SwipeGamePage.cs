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
using System;
using BaitNews.Forms.Controls;
using BaitNews.Forms.PageModels;
using Xamarin.Forms;

namespace BaitNews.Forms.Pages
{
	public class SwipeGamePage : ContentPage
	{				
		CardStackView cardStack;
        SwipeGamePageModel viewModel = new SwipeGamePageModel();
	
		public SwipeGamePage ()
		{
            Title = "Game Demo";

			this.BindingContext = viewModel;	
            this.BackgroundColor = Color.FromHex("#1C1F27");

			RelativeLayout view = new RelativeLayout ();

			cardStack = new CardStackView ();
            cardStack.SetBinding(CardStackView.ItemsSourceProperty, "Headlines");
			cardStack.SwipedLeft += SwipedLeft;
			cardStack.SwipedRight += SwipedRight;

			view.Children.Add (cardStack,
				Constraint.Constant (30), 
				Constraint.Constant (60),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width-60;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height-140;
				})
			);	

			this.LayoutChanged += (object sender, EventArgs e) => 
			{
				cardStack.CardMoveDistance = (int)(this.Width * 0.60f);
			};

			this.Content = view;
		}

		void SwipedLeft(int index)
		{
			// card swiped to the left
		}	
		
		void SwipedRight(int index)
		{
			// card swiped to the right
		}	
	}
}


