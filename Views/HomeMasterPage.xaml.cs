using System;
using System.Collections.Generic;
using POCDemo.Models;
using POCDemo.Views;
using Xamarin.Forms;

namespace POCDemo{
    public partial class HomeMasterPage : MasterDetailPage{
        public HomeMasterPage(string name, string Picture){
            InitializeComponent();
            this.Title = "Menu";
            var menuList = new List<MasterPageItem>();
            var homePage = new MasterPageItem() { Title = "Home Page", Icon = "imgBack.png", TargetType = typeof(HomePage) };
            var marketCapPage = new MasterPageItem() { Title = "Market Cap Chart", Icon = "imgBack.png", TargetType = typeof(MarketCapChart) };
            var loginPage = new MasterPageItem() { Title = "Sign Out", Icon = "", TargetType = typeof(UserLogin) };
            menuList.Add(homePage);
            menuList.Add(marketCapPage);
            menuList.Add(loginPage);
            navigationDrawerList.ItemsSource = menuList;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomePage)));
            if (!string.IsNullOrEmpty(name)){
                lblUserName.Text =name;
            }
            if(!string.IsNullOrEmpty(Picture)){

                imgProfile.Source = new UriImageSource()
                {
                    Uri = new Uri("https://xamarin.com/content/images/pages/forms/example-app.png"),
                    CachingEnabled = false
                };
                imgProfile.BackgroundColor = Color.Red;
            }
        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e){
            var selectedItem = (MasterPageItem)e.SelectedItem;
            Type page = selectedItem.TargetType;
            if (selectedItem.Title == "Sign Out"){
                DependencyService.Get<IClearCookies>().Clear();
                Settings.IsUserLogin = false;
                Settings.exitUserName = null;
                Settings.exitUserPicture = null;
                Navigation.PushModalAsync(new UserLogin());
            }
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}