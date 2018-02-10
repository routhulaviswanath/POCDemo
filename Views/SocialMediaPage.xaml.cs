using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POCDemo.Models;
using Xamarin.Forms;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace POCDemo.Views{
    public partial class SocialMediaPage : ContentPage{
        
        public SocialMediaAssets _socialMediaAssets;
        public string userAccessToken;

        public SocialMediaPage(SocialMediaAssets socialMediaAssets){
            InitializeComponent();
            _socialMediaAssets = socialMediaAssets;
            WebViewNavigate(_socialMediaAssets.stdUrl1);
            webAccess.Navigated += WebNavigated;
        }
        public void WebViewNavigate(string url){
            try{
                loaderShow.IsRunning = true;
                webAccess.Source = url;
            }
            catch (Exception ex){
                var msg = ex.Message;
                loaderShow.IsRunning = false;
            }
        }
        async void WebNavigated(object sender, WebNavigatedEventArgs e){
            try{
                loaderShow.IsRunning = true;
                var navigatedUrl = e.Url;
                if (e.Url != ""){
                    if (e.Url.Contains("facebook")){
                        var accessToken = ExtractAccessTokenFromUrl(e.Url);
                        if (!string.IsNullOrEmpty(accessToken)){
                            userAccessToken = accessToken;
                            FacebookServices fbServies = new FacebookServices();
                            var fbResponse = await fbServies.GetFacebookProfileAsync(accessToken);
                            var smud = new SocialMediaUserDetails(){
                                profileName = fbResponse.FirstName + " " + fbResponse.LastName,
                                profilePicUrl = fbResponse.Picture.Data.Url,
                                age = fbResponse.AgeRange.Min,
                                gender = fbResponse.Gender,
                                accessToken = accessToken,
                                profileId = fbResponse.Id
                            };
                            var fullName= fbResponse.FirstName + " " + fbResponse.LastName;
                            Settings.IsUserLogin = true;
                            Settings.exitUserName = fullName;
                            Settings.exitUserPicture = fbResponse.Picture.Data.Url;

                            await Navigation.PushModalAsync(new HomeMasterPage(fullName,fbResponse.Picture.Data.Url));
                        }
                    }
                    loaderShow.IsRunning = false;
                }
            }
            catch (Exception ex){
                var msg = ex.Message;
                loaderShow.IsRunning = false;
            }
        }
        private string ExtractAccessTokenFromUrl(string url){
            try{
                if (url.Contains("access_token") && url.Contains("&expires_in=")){
                    var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");
                    var accessToken = at.Remove(at.IndexOf("&expires_in="));
                    return accessToken;
                }
            }
            catch (Exception ex){
                var msg = ex.Message;
                loaderShow.IsRunning = false;
            }
            return string.Empty;
        }

        private void LblBakTapped(object sender,EventArgs e){
            Navigation.PopModalAsync();
        }
    }

    public class SocialMediaUserDetails{
        public string profileName { get; set; }
        public string profilePicUrl { get; set; }
        public int age { get; set; }
        public string accessToken { get; set; }
        public string gender { get; set; }
        public string profileId { get; set; }
    }
}


