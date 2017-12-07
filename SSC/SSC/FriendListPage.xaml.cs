using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SSC
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FriendListPage : ContentPage
	{
		public FriendListPage(long steamID)
		{
            Label header = new Label
            {
                Text = "Levels of Your Friends",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };
            ListMaker listmaker = new ListMaker();

            List<String> games = listmaker.getFriends(steamID);

            ListView gameList = new ListView
            {
                ItemsSource = games,
            };

            Button switchToIntro = new Button
            {
                Text = "back",
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            switchToIntro.Clicked += OnButtonClicked;

            Content = new StackLayout
            {
                Children = {
                    switchToIntro,
                    header,
                    gameList
                }
            };
            this.BackgroundColor = Color.FromHex("#666666");
            NavigationPage.SetHasNavigationBar(this, false);
        }
        void OnButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}