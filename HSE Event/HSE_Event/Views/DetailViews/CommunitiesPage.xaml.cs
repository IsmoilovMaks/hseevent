using HSE_Event.Models;
using Microsoft.WindowsAzure.MobileServices;
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
    public partial class CommunitiesPage : ContentPage
    {
        public static MobileServiceClient MobileService =
    new MobileServiceClient(
    "https://hseevent.azurewebsites.net"
);
        //Объявление элементов ListView
        List<CommunitiesListViewItem> Items;

        public CommunitiesPage()
        {
            InitializeComponent();
            InitList();
            InitSearch();
        }

        /// <summary>
        /// Элемент для поиска
        /// </summary>
        private void InitSearch()
        {
            SearchCommunity.TextChanged += (s, e) => FilterItem(SearchCommunity.Text);
            SearchCommunity.SearchButtonPressed += (s, e) => FilterItem(SearchCommunity.Text);
        }

        /// <summary>
        /// Метод поиска
        /// </summary>
        /// <param name="filter"></param>
        private void FilterItem(string filter)
        {
            CommunityListView.BeginRefresh();
            if (string.IsNullOrWhiteSpace(filter))
            {
                CommunityListView.ItemsSource = Items;
            }
            else
            {
                CommunityListView.ItemsSource = Items.Where(x => x.Name.ToLower().Contains(filter.ToLower()));
            }
            CommunityListView.EndRefresh();
        }

        /// <summary>
        /// Элементы ListView
        /// </summary>
        void InitList()
        {
            Items = new List<CommunitiesListViewItem>();
            Items.Add(new CommunitiesListViewItem
            {
                Name = "Eminem",
                Text = "Not Afraid\nLose Yourself\nRap God\nMockingbird\nStan\nRiver\nLove The Way You Lie",
                ImageComList = "CommunityLogo.jpg"
            });
            Items.Add(new CommunitiesListViewItem
            {
                Name = "Linkin Park",
                Text = "The Messenger\nNumb\nIridescent\nWhat I've Done\nCastle of Glass\nNew Divide",
                ImageComList = "CommunityLogo.jpg"
            });
            Items.Add(new CommunitiesListViewItem
            {
                Name = "Imagine Dragons",
                Text = "The Fall\nGold\nSmoke and Mirrors\nLovesong\nDemons\nRadioactive",
                ImageComList = "CommunityLogo.jpg"
            });

            CommunityListView.ItemsSource = Items;
            CommunityListView.ItemTapped += CommunityListView_ItemTapped;
        }

        /// <summary>
        /// Переход на страницу из элемента ListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommunityListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CommunitiesListViewItem item = (CommunitiesListViewItem)e.Item;
            Navigation.PushAsync(new CommunityPage(item));
            
        }
    }
}