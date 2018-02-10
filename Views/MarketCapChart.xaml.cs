using Microcharts;
using SkiaSharp;
using Microcharts.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using System.Net.Http;
using Newtonsoft.Json;
using POCDemo.Models;

namespace POCDemo.Views{
    public partial class MarketCapChart : ContentPage{

        public MarketCapChart(){
            InitializeComponent();
            GetRespose();
            listView.ItemSelected+=(object sender, SelectedItemChangedEventArgs e) => {
                var selectedItem = ((ListView)sender).SelectedItem;
                var item = (CoinMarketCap)selectedItem;
                DisplayAlert("Selected Item", "Percent changed 1H: " + item.percent_change_1h + "\n" + "Percent changed 24H: " + item.percent_change_24h + "\n" + "Percent changed 7Days: " + item.percent_change_7d, "Ok");
                Navigation.PushModalAsync(new ChartPage((CoinMarketCap)selectedItem));
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
                var _responseList = JsonConvert.DeserializeObject<Result>(jsonstring);
                listView.ItemsSource = _responseList.CoinMarketCapList;
                loaderShow.IsRunning = false;
            }else{
                await DisplayAlert("POCDemo", "Please check your network connection", "OK");
            }
        }
    }
}