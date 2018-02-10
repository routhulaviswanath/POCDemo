using POCDemo.Droid;
using Xamarin.Forms;
using System.Net;
using Android.Webkit;

[assembly: Dependency(typeof(IClearCookiesImplementation))]
namespace POCDemo.Droid{
    public class IClearCookiesImplementation : IClearCookies{
        public void Clear(){
            var cookieManager = CookieManager.Instance;
            cookieManager.RemoveAllCookie();
        }
    }
}
