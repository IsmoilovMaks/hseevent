using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE_Event.Models;
using HSE_Event.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSE_Event.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lb_Username.TextColor = Constants.MainTextColor;
            Lb_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            En_Username.Completed += (s, e) => En_Password.Focus();
            En_Password.Completed += (s, e) => SignInProcedure(s, e);
        }

        async void SignInProcedure(object sender, EventArgs e)
        {
           
            try
            {
                User user = new User(En_Username.Text, En_Password.Text);

                if (user.CheckInformation())
                {
                    ActivitySpinner.IsVisible = true;
                    
                    if(Device.OS == TargetPlatform.Android)
                    {
                        Application.Current.MainPage = new MasterMenu();
                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        await Navigation.PushAsync(new NavigationPage(new MasterMenu()));
                    }  
                }
                else
                {
                    await DisplayAlert("Login", "Login Failed\nEmpty username or password!", "Ok");
                }
            }
            catch (NullReferenceException)
            {
                await DisplayAlert("Login", "Login Failed\nEmpty username or password!", "Ok");
            }

        }
    }
}