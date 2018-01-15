using HSE_Event.Data;
using HSE_Event.Models;
using Microsoft.WindowsAzure.MobileServices;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace HSE_Event.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {

        private MobileServiceCollection<accountsList, accountsList> items;
 
        public NewsPage()
        {
            InitializeComponent();
           // this.MobileService = new MobileServiceClient(Constants.ApplicationURL);
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

       accountsList item = new accountsList
       {
           login 
       }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckConnection();
        }

        private void Current_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            CheckConnection();
        }

        private void CheckConnection()
        {
            connectionStateLbl.IsVisible = !CrossConnectivity.Current.IsConnected;
            connectionDetailsLbl.IsVisible = CrossConnectivity.Current.IsConnected;

            if (CrossConnectivity.Current != null &&
                CrossConnectivity.Current.ConnectionTypes != null &&
                CrossConnectivity.Current.IsConnected == true)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                connectionDetailsLbl.Text = connectionType.ToString();
            }
        }
    }
}