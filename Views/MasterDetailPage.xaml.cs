using System;
using System.Collections.Generic;
using Xamarin.Forms;
namespace POCDemo
{
    public partial class MasterDetailPage : MasterDetailPage
    {

        public List<MasterPageItem> menuList { get; set; }

        public MasterDetailPage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();
            var page1 = new MasterPageItem() { Title = "Item 1", Icon = "imgBack.png", TargetType = typeof(UserLogin) };
            var page2 = new MasterPageItem() { Title = "Item 2", Icon = "imgBack.png", TargetType = typeof(UserLogin) };
            menuList.Add(page1);
            menuList.Add(page2);
            navigationDrawerList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(UserLogin)));
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

        public class MasterPageItem
        {
            public string Title { get; set; }
            public string Icon { get; set; }
            public Type TargetType { get; set; }
        }
    }
}