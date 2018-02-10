using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using POCDemo.Models;
using Xamarin.Forms;

namespace POCDemo.Views{
    public partial class HomePage : ContentPage{

        public HomePage(){
            InitializeComponent();
            GetRespose();

            listView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
                var selectedItem = ((ListView)sender).SelectedItem;
                var item = (CoinMarketCap)selectedItem;
                DisplayAlert("Selected Item","Name: " + item.name+ "\n" + "Symbol: " + item.symbol + "\n" + "Rank: " + item.rank, "Ok");
            };
        }
        public async void GetRespose(){
            if (CheckNetworkAccess.IsNetworkConnected()){
                loaderShow.IsRunning = true;
                var requestUrl = "https://api.coinmarketcap.com/v1/ticker/";
                var httpClient = new HttpClient();
                var jsonstring = await httpClient.GetStringAsync(requestUrl);
                jsonstring = jsonstring.Replace("[", "").Replace("]", "");
                jsonstring = "{" + "CoinMarketCapList:[" + jsonstring + "]}";
                var  _responseList = JsonConvert.DeserializeObject<Result>(jsonstring);
                listView.ItemsSource = _responseList.CoinMarketCapList;
                loaderShow.IsRunning = false;
            }
            else{
                await DisplayAlert("POCDemo", "Please check your network connection", "OK");
            }
        }
    }
}
