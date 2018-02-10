using POCDemo.iOS;
using Xamarin.Forms;
using System.Net;
using Foundation;

[assembly: Dependency(typeof(IClearCookiesImplementation))]
namespace POCDemo.iOS{
    public class IClearCookiesImplementation : IClearCookies{
        public void Clear(){
            NSHttpCookieStorage CookieStorage = NSHttpCookieStorage.SharedStorage;
            foreach (var cookie in CookieStorage.Cookies)
                CookieStorage.DeleteCookie(cookie);
        }
    }
}
