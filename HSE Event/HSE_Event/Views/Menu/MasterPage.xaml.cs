using HSE_Event.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE_Event.Views.DetailViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSE_Event.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return ListMenu; } }
        public List<MasterMenuItem> items;

        public MasterPage()
        {
            InitializeComponent();
            SetItems();
        }
        
        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("News", "newsicon.png", typeof(NewsPage)));
            items.Add(new MasterMenuItem("Communities", "groupsicon.png", typeof(CommunitiesPage)));
            items.Add(new MasterMenuItem("Account", "accounticon.png", typeof(AccountPage)));
            items.Add(new MasterMenuItem("Settings", "setingsicon.png", typeof(SettingsPage)));
            ListView.ItemsSource = items;
        }

    }
}