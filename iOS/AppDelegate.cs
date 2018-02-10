using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace POCDemo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

            UITabBar.Appearance.TintColor = new UIColor(0.89f, 0.24f, 0.65f, 1.0f);

            var navBar = UINavigationBar.Appearance;
            navBar.TintColor = UIColor.White;
            navBar.BarTintColor = UIColor.FromRGB(83, 63, 149);
            navBar.Translucent = false;
            navBar.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = UIColor.White
            };

            return base.FinishedLaunching(app, options);
        }
    }
}
