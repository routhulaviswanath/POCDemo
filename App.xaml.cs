using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using POCDemo.Models;
using Xamarin.Forms;

namespace POCDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new  NavigationPage(new Views.UserLogin());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
