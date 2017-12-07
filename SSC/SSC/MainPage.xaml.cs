using Xamarin.Forms;

namespace SSC
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}
