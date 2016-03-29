using System;
using System.Collections.Generic;
using MvvmHelpers;

namespace DailyFail.Shared.Helpers
{
	public class HeadlineBuilder
	{
		public HeadlineBuilder()
		{
		}

		static public IEnumerable<Models.Headline> Build()
		{
			ObservableRangeCollection<Models.Headline> headlines = new ObservableRangeCollection<Models.Headline>();

			var headline1 = new Models.Headline();
			headline1.Text = "The itchy true about Tinder: 750,000 people on the dating app are infested with pubic lice";
			headline1.Source = "Daily Mail";
			headline1.Url = "http://www.dailymail.co.uk/health/article-3442416/The-itchy-truth-Tinder-750-000-people-dating-app-infested-pubic-lice-scientist-warns.html";
			headline1.IsTrue = true;
			headlines.Add(headline1);

			var headline2 = new Models.Headline();
			headline2.Text = "Just like that. Tommy Cooper's likeness lives on - on the bottom of a meat pie";
			headline2.Source = "Daily Mail";
			headline2.Url = "http://www.dailymail.co.uk/news/article-1220691/Just-like---Tommy-Coopers-likeness-lives-on.html";
			headline2.IsTrue = true;
			headlines.Add(headline2);

			var headline3 = new Models.Headline();
			headline3.Text = "We know UFOs do exist - we've seen them!";
			headline3.Source = "Daily Mail";
			headline3.Url = "http://www.dailymail.co.uk/sciencetech/article-1020324/We-know-UFOs-exist--weve-seen-them.html";
			headline3.IsTrue = true;
			headlines.Add(headline3);

			var headline4 = new Models.Headline();
			headline4.Text = "Since when did women's lib mean dressing like a porn star?";
			headline4.Source = "Daily Mail";
			headline4.Url = "http://www.dailymail.co.uk/femail/article-2068915/Since-did-womens-lib-mean-dressing-like-porn-star.html";
			headline4.IsTrue = true;
			headlines.Add(headline4);

			var headline5 = new Models.Headline();
			headline5.Text = "Since when did women's lib mean dressing like a porn star?";
			headline5.Source = "Daily Mail";
			headline5.Url = "http://www.dailymail.co.uk/femail/article-2068915/Since-did-womens-lib-mean-dressing-like-porn-star.html";
			headline5.IsTrue = true;
			headlines.Add(headline5);

			var headline6 = new Models.Headline();
			headline6.Text = "Police 'are too worried about political correctness to prevent abuse linked to witchcraft'";
			headline6.Source = "Daily Mail";
			headline6.Url = "http://www.dailymail.co.uk/news/article-2188444/Police-worried-political-correctness-prevent-abuse-linked-witchcraft.html";
			headline6.IsTrue = true;
			headlines.Add(headline6);

			var headline7 = new Models.Headline();
			headline7.Text = "I've designed my baby";
			headline7.Source = "Daily Mail";
			headline7.Url = "http://www.dailymail.co.uk/health/article-416297/Ive-designed-baby.html";
			headline7.IsTrue = true;
			headlines.Add(headline7);

			var headline8 = new Models.Headline();
			headline8.Text = "Why women become LESS bitchy as they get older (and yes, it's to do with men)";
			headline8.Source = "Daily Mail";
			headline8.Url = "http://www.dailymail.co.uk/femail/article-1084940/Why-women-LESS-bitchy-older-yes-men.html";
			headline8.IsTrue = true;
			headlines.Add(headline8);

			var headline9 = new Models.Headline();
			headline9.Text = "Labour MP turns up with no trousers on to David Miliband's farewell party";
			headline9.Source = "Daily Mail";
			headline9.Url = "http://www.dailymail.co.uk/news/article-2362760/Labour-MP-turns-trousers-David-Milibands-farewell-party.html";
			headline9.IsTrue = true;
			headlines.Add(headline9);

			var headline10 = new Models.Headline();
			headline10.Text = "Wearing Flip-Flops can give you skin cancer";
			headline10.Source = "Daily Mail";
			headline10.Url = "http://www.dailymail.co.uk/health/article-1025915/Wearing-FLIP-FLOPS-skin-cancer-doctors-warn.html";
			headline10.IsTrue = true;
			headlines.Add(headline10);

			var headline11 = new Models.Headline();
			headline11.Text = "How a romantic candle-lit dinner can give you cancer";
			headline11.Source = "Daily Mail";
			headline11.Url = "http://www.dailymail.co.uk/health/article-1207726/Candles-release-scents-laced-cancer-chemicals-warn-scientists.html";
			headline11.IsTrue = true;
			headlines.Add(headline11);

			var headline12 = new Models.Headline();
			headline12.Text = "Women become good cooks at the age of 55 - that is when they can cook a roast, rescue a meal... and FINALLY boil an egg";
			headline12.Source = "Daily Mail";
			headline12.Url = "http://www.dailymail.co.uk/femail/article-2225771/Women-FINALLY-master-cooking-55.html";
			headline12.IsTrue = true;
			headlines.Add(headline12);

			var headline13 = new Models.Headline();
			headline13.Text = "Uh oh... You can spend a fortune trying to look young but those droopy ears will give you away (are you listening, Madonna)!";
			headline13.Source = "Daily Mail";
			headline13.Url = "http://www.dailymail.co.uk/femail/article-2222747/Uh-oh--You-spend-fortune-trying-look-young-droopy-ears-away-listening-Madonna.html";
			headline13.IsTrue = true;
			headlines.Add(headline13);

			var headline14 = new Models.Headline();
			headline14.Text = "I thought tattoos were for sluts...until I was branded with a 4-inch high prancing horse. My boyfriend's reaction? 'Rock and roll! Now you might have sex with your top off!";
			headline14.Source = "Daily Mail";
			headline14.Url = "http://www.dailymail.co.uk/femail/article-2210486/LIZ-JONES-I-thought-tattoos-sluts--I-branded-4-inch-high-prancing-horse.html";
			headline14.IsTrue = true;
			headlines.Add(headline14);

			var headline15 = new Models.Headline();
			headline15.Text = "Women make the best spies because they can combine sympathy with a ruthless streak, says former chief of MI5";
			headline15.Source = "Daily Mail";
			headline15.Url = "http://www.dailymail.co.uk/news/article-3130556/Former-MI5-chief-says-women-make-best-spies.html";
			headline15.IsTrue = true;
			headlines.Add(headline15);

			var headline16 = new Models.Headline();
			headline16.Text = "Women don't need Viagra... just a good chat: Surprise solution to lack of libido";
			headline16.Source = "Daily Mail";
			headline16.Url = "http://www.dailymail.co.uk/news/article-1312724/Women-dont-need-Viagra--just-good-chat-Surprise-solution-lack-libido.html";
			headline16.IsTrue = true;
			headlines.Add(headline16);

			var headline17 = new Models.Headline();
			headline17.Text = "Women who want to succeed at work should shut up - while men who want the same should keep talking, research says";
			headline17.Source = "Daily Mail";
			headline17.Url = "http://www.dailymail.co.uk/news/article-2146015/Women-want-succeed-work-shut--men-want-talking.html";
			headline17.IsTrue = true;
			headlines.Add(headline17);

			var headline18 = new Models.Headline();
			headline18.Text = "Woman, 63, 'becomes PREGNANT in the mouth' with baby squid after eating calamari";
			headline18.Source = "Daily Mail";
			headline18.Url = "http://www.dailymail.co.uk/sciencetech/article-2159692/Womans-mouth-falls-pregnant-squid-biting-sea-creature-scientists-claim.html";
			headline18.IsTrue = true;
			headlines.Add(headline18);

			var headline19 = new Models.Headline();
			headline19.Text = "Big headed babies 'more prone to cancer'";
			headline19.Source = "Daily Mail";
			headline19.Url = "http://www.dailymail.co.uk/health/article-370870/Big-headed-babies-prone-cancer.html";
			headline19.IsTrue = true;
			headlines.Add(headline19);

			var headline20 = new Models.Headline();
			headline20.Text = "One out of every five killers is an immigrant";
			headline20.Source = "Daily Mail";
			headline20.Url = "http://www.dailymail.co.uk/news/article-1210129/One-killers-immigrant.html";
			headline20.IsTrue = true;
			headlines.Add(headline20);

			var headline21 = new Models.Headline();
			headline21.Text = "Nearly a fifth of all suspected rapists and murderers arrested last year were immigrants";
			headline21.Source = "Daily Mail";
			headline21.Url = "http://www.dailymail.co.uk/news/article-2175798/A-fifth-suspected-rapists-murderers-Britain-immigrants.html";
			headline21.IsTrue = true;
			headlines.Add(headline21);

			var headline22 = new Models.Headline();
			headline22.Text = "Racism is 'hardwired' into the human brain";
			headline22.Source = "Daily Mail";
			headline22.Url = "http://www.dailymail.co.uk/sciencetech/article-2164844/Racism-hardwired-human-brain--people-racists-knowing-it.html";
			headline22.IsTrue = true;
			headlines.Add(headline22);

			var headline23 = new Models.Headline();
			headline23.Text = "Oral sex can cause throat cancer";
			headline23.Source = "Daily Mail";
			headline23.Url = "http://www.dailymail.co.uk/news/article-3411245/Oral-sex-raises-risk-getting-cancer-22-times.html";
			headline23.IsTrue = true;
			headlines.Add(headline23);

			var headline24 = new Models.Headline();
			headline24.Text = "Muslim bus drivers refuse to let guide dogs on board";
			headline24.Source = "Daily Mail";
			headline24.Url = "http://www.dailymail.co.uk/news/article-1295749/Muslim-bus-drivers-refuse-let-guide-dogs-board.html";
			headline24.IsTrue = true;
			headlines.Add(headline24);

			//Daily Mash
			var headline101 = new Models.Headline();
			headline101.Text = "People who say ‘If you don’t know me don’t judge me’ all dreadful";
			headline101.Source = "Daily Mash";
			headline101.Url = "http://www.thedailymash.co.uk/news/society/people-who-say-if-you-dont-know-me-dont-judge-me-all-dreadful-20160314107126";
			headline101.IsTrue = false;
			headlines.Add(headline101);

			var headline102 = new Models.Headline();
			headline102.Text = "Britain to leave EU because of massive, blond-haired child";
			headline102.Source = "Daily Mash";
			headline102.Url = "http://www.thedailymash.co.uk/politics/politics-headlines/britain-to-leave-eu-because-of-massive-blond-haired-child-20160222106453";
			headline102.IsTrue = false;
			headlines.Add(headline102);

			var headline103 = new Models.Headline();
			headline103.Text = "Woman surprised to still be overweight despite having running app";
			headline103.Source = "Daily Mash";
			headline103.Url = "http://www.thedailymash.co.uk/news/health/woman-surprised-to-still-be-overweight-despite-having-running-app-20160225106588";
			headline103.IsTrue = false;
			headlines.Add(headline103);

			var headline104 = new Models.Headline();
			headline104.Text = "New cafe opens for men trapped in ‘Friend Zone’";
			headline104.Source = "Daily Mash";
			headline104.Url = "http://www.thedailymash.co.uk/news/society/new-cafe-opens-for-men-trapped-in-friend-zone-20160311107049";
			headline104.IsTrue = false;
			headlines.Add(headline104);

			//Randoms
			var headline601 = new Models.Headline();
			headline601.Text = "Swedish health minister: Loud sex is healthy";
			headline601.Source = "UPI";
			headline601.Url = "http://www.upi.com/Odd_News/2016/03/13/Swedish-health-minister-Loud-sex-is-healthy/7681457888320/?spt=sec&or=on";
			headline601.IsTrue = true;
			headlines.Add(headline601);

			var headline602 = new Models.Headline();
			headline602.Text = "Pornography declared 'public health crisis'; Elder Holland calls it an 'infectious, fatal epidemic'";
			headline602.Source = "KSL";
			headline602.Url = "https://www.ksl.com/?sid=38871640";
			headline602.IsTrue = true;
			headlines.Add(headline602);

			var headline603 = new Models.Headline();
			headline603.Text = "€1m allocated to encourage Irish people to eat potatoes";
			headline603.Source = "Irish Examiner";
			headline603.Url = "http://www.irishexaminer.com/breakingnews/business/1m-allocated-to-encourage-irish-people-to-eat-potatoes-696396.html";
			headline603.IsTrue = true;
			headlines.Add(headline603);

			var headline604 = new Models.Headline();
			headline604.Text = "Rugby player's penis almost torn off in tackle";
			headline604.Source = "BBC News";
			headline604.Url = "http://www.bbc.co.uk/newsbeat/article/35801847/rugby-players-penis-almost-torn-off-in-tackle";
			headline604.IsTrue = true;
			headlines.Add(headline604);

			var headline605 = new Models.Headline();
			headline605.Text = "Secret pedophile symbol found on children's toy sold at Monster Jam";
			headline605.Source = "DrDREW";
			headline605.Url = "http://www.hlntv.com/shows/dr-drew/articles/2016/03/10/secret-pedophile-symbol-found-on-children-s-toy-sold-at-monster-jam";
			headline605.IsTrue = true;
			headlines.Add(headline605);

			var headline606 = new Models.Headline();
			headline606.Text = "George Osborne said pre-election Budget would only help 'stupid, affluent and lazy people', claims former minister";
			headline606.Source = "DrDREW";
			headline606.Url = "http://www.independent.co.uk/news/uk/politics/inside-story-of-david-cameron-and-nick-cleggs-coalition-government-revealed-in-memoir-a6928491.html";
			headline606.IsTrue = true;
			headlines.Add(headline606);

			var headline607 = new Models.Headline();
			headline607.Text = "U.K. man jailed 5 days in St. John's after friend's ashes mistaken for ketamine";
			headline607.Source = "CBC News";
			headline607.Url = "http://www.cbc.ca/news/canada/newfoundland-labrador/jailed-saint-john-s-british-ashes-ketamine-border-services-1.3488751";
			headline607.IsTrue = true;
			headlines.Add(headline607);

			var headline608 = new Models.Headline();
			headline608.Text = "Brothel holds open day for children's charity";
			headline608.Source = "NZ Herald";
			headline608.Url = "http://www.nzherald.co.nz/nz/news/article.cfm?c_id=1&objectid=11604649";
			headline608.IsTrue = true;
			headlines.Add(headline608);

			var headline609 = new Models.Headline();
			headline609.Text = "EasyJet rewards hero doctor with free coffee - but makes him pay £1.20 for KitKat to go with it";
			headline609.Source = "Independent";
			headline609.Url = "http://www.independent.co.uk/news/uk/home-news/easyjet-passenger-gets-free-coffee-for-saving-persons-life-on-plane-and-preventing-flight-from-a6923541.html";
			headline609.IsTrue = true;
			headlines.Add(headline609);

			return headlines;
		}
	}
}

