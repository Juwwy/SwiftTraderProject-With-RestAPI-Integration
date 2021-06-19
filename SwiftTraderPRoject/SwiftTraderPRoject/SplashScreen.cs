using SwiftTraderPRoject.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwiftTraderPRoject
{
    public class SplashScreen : ContentPage
    {
        Image SplashImage;
        public SplashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var RunThis = new AbsoluteLayout();
            SplashImage = new Image
            {
                Source = "splash1.jpg",
                HeightRequest = 300,
                WidthRequest = 300
            };

            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            RunThis.Children.Add(SplashImage);
            this.BackgroundColor = Color.FromHex("#FFF7F2F2");
            this.BackgroundImageSource = ImageSource.FromResource("splash1.jpg");
            this.Content = RunThis;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            await SplashImage.ScaleTo(1, 2000);
            await SplashImage.ScaleTo(0.9, 1500, Easing.BounceOut);
            //await SplashImage.ScaleTo(150, 1200, Easing.BounceOut);
            //SplashImage.TranslationX = 20.3;
            //var b = new LoginPage();
            //App.Current.MainPage.Navigation.InsertPageBefore(new LoginPage(), new SplashScreen());
        }
    }
}
