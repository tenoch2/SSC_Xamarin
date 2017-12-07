

using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace SSC
{
    public class IntroPage : ContentPage
	{
		public IntroPage ()
		{
            Label title = new Label
            {
                Text = "Enter your SteamID",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            var textEntry = new Entry
            {
                Placeholder = "enter here",
                BackgroundColor = Color.Black,
                TextColor = Color.White
            };

            Button engageFriendSearch = new Button
            {
                Text = "Search",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            engageFriendSearch.Clicked += (sender, EventArgs) =>
            {
                string entry = textEntry.Text;
                if (Regex.Matches(entry,@"[a-zA-Z]").Count > 0)
                {
                    // do nothing
                }
                else
                { 
                    OnButtonClicked(sender, EventArgs, Convert.ToInt64(entry));
                }
            };

            Image srch = new Image();
            srch.Source = "search.png";

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 15);
            this.Content = new StackLayout
            {
                Children =
                {
                    title,
                    textEntry,
                    engageFriendSearch,
                    srch
                }
            };

            this.BackgroundColor = Color.FromHex("#666666");
            NavigationPage.SetHasNavigationBar(this, false);

        }

        void OnButtonClicked(object sender, EventArgs e, long ID)
        {

            Navigation.PushAsync(new NavigationPage(new FriendListPage(ID)));
        }
	}
}