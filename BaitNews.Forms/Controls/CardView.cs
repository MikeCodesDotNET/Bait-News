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
using Xamarin.Forms;

namespace BaitNews.Forms.Controls
{
	public class CardView : ContentView
	{
		public Label Headline { get; set;}

		public CardView ()
		{
            BackgroundColor = Color.FromHex("#1C1F27");
            var relativeLayout = new RelativeLayout ();

            // box view as the background
            BoxView boxView1 = new BoxView
            {
                Color = Color.FromHex("#414653"),
				InputTransparent=true
			};

			relativeLayout.Children.Add (boxView1,
				Constraint.Constant (0), Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				})
			);


            // items label
            Headline = new Label()
            {
                TextColor = Color.White,
                FontFamily = "Avenir",
                LineBreakMode = LineBreakMode.WordWrap,
                FontSize = 18,
                InputTransparent = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center,
            };


            //This is some Horrible code
			relativeLayout.Children.Add (Headline,
                Constraint.Constant (10), Constraint.RelativeToParent((parent) => {
                    return parent.Height / 2 - 40;
                }),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width - 20;
				}),
				Constraint.Constant (120)
			);
            
			StackLayout stack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,

				Spacing = 2
			};
			
			relativeLayout.Children.Add (stack,
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width - 90;
				}), 
                 Constraint.RelativeToParent((parent) => {
                    return parent.Height - 200;
                }));


			Content = relativeLayout;
		}
	}
}

