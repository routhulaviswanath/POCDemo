using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using Xamarin.Forms;
using Entry = Microcharts.Entry;
using POCDemo.Models;
using System;

namespace POCDemo.Views
{
    public partial class ChartPage : ContentPage
    {
        List<Entry> _chartEntries;

        public ChartPage(CoinMarketCap marketCap)
        {
            InitializeComponent();
            var percentChange1h = float.Parse(marketCap.percent_change_1h);
            var percentChange24h = float.Parse(marketCap.percent_change_24h);
            var percentChange7d = float.Parse(marketCap.percent_change_7d);

            _chartEntries = new List<Entry>{
                new Entry(percentChange1h){
                    Color=SKColor.Parse("#FF1943"),
                    Label ="Percent Changed 1hour",
                    ValueLabel = percentChange1h.ToString()
                },
                new Entry(percentChange24h){
                    Color = SKColor.Parse("00BFFF"),
                    Label = "Percent Changed 24hours",
                    ValueLabel = percentChange24h.ToString()
                },
                new Entry(percentChange7d){
                    Color =  SKColor.Parse("#00CED1"),
                    Label = "Percent Changed 7days",
                    ValueLabel =percentChange7d.ToString()
                },
            };
            lineChart.Chart = new LineChart() { Entries = _chartEntries };
            donutChart.Chart = new DonutChart() { Entries = _chartEntries };
        }

        private void LblBakTapped(object sender, EventArgs e){
            Navigation.PopModalAsync();
        }
    }
}