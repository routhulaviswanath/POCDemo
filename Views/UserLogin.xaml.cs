using System;
using System.Collections.Generic;
using POCDemo.Models;
using Xamarin.Forms;

namespace POCDemo.Views{
    public partial class UserLogin : ContentPage{

        public string _userExit;

        public UserLogin(){
            InitializeComponent();
        }
        async void btnFBClick(object sender, EventArgs args){
            if (CheckNetworkAccess.IsNetworkConnected()){
                var socialMediaAssets = new SocialMediaAssets();
                var clientId = "254358548371081";
                socialMediaAssets.socialMediaName = "FaceBook";
                socialMediaAssets.apiKey = clientId;
                socialMediaAssets.secret = "";
                socialMediaAssets.stdUrl1 = "https://www.facebook.com/dialog/oauth?client_id=" + clientId + "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";
                socialMediaAssets.shallNavigate = true;
                if(Settings.IsUserLogin){
                    await Navigation.PushModalAsync(new HomeMasterPage(Settings.exitUserName,Settings.exitUserPicture));
                }else{
                    await Navigation.PushModalAsync(new SocialMediaPage(socialMediaAssets));
                }
            }else{
                await DisplayAlert("POCDemo", "Please check your network connection", "OK");
            }
        }
    }
}
