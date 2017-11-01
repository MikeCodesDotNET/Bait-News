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


            headlines.Add (new Headline() { Text = "Man that dreamed of opening trampoline studio becomes paralyzed after trampoline accident" });
            headlines.Add(new Headline() { Text = "Man sacked for delivering box of own faeces to pharmacy by mistake" });
            headlines.Add(new Headline() { Text = "Spontaneous dancing still illegal in Sweden" });
            headlines.Add(new Headline() { Text = "Gainesville High School gets new sign, asks drivers not to crash into it like the old sign" });
            headlines.Add(new Headline() { Text = "Dog that mauled owner to death had 'probably taken crack cocaine'" });
            headlines.Add(new Headline() { Text = "Trump dedicates golf trophy to hurricane victims" });
            headlines.Add(new Headline() { Text = "Uber’s search for a female CEO has been narrowed down to 3 men" });
            headlines.Add(new Headline() { Text = "British politician wants death penalty for suicide bombers" });
            headlines.Add(new Headline() { Text = "Michigan woman gets life in prison for murder parrot allegedly witnessed" });
            headlines.Add(new Headline() { Text = "This half-naked Ontario man just wants his weed and bong back" });

        }
	}
}

