using HSE_Event.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSE_Event.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommunityPage : ContentPage
	{
        public CommunityPage(CommunitiesListViewItem item)
        {
            InitializeComponent();
            CommunityTittle.Text = item.Name;
            CommunityIcon.Source = item.ImageComList;
            CommunityText.Text = item.Text;
        }

        //async void Com(object sender, EventArgs e)
        //{
        //    TodoItem itema = new TodoItem { Text = "Awesome item" };
        //    await MobileService.GetTable<TodoItem>().InsertAsync(itema);
        //}
    }
}