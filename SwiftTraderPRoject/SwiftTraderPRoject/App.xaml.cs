using SwiftTraderPRoject.Views;
using SwiftTraderPRoject.Views.Admin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Catchland_PERSONAL_USE_ONLY.otf", Alias = "FontAwesome")]
[assembly: ExportFont("Pacifico-Regular.ttf", Alias = "FontPacific")]
[assembly: ExportFont("AkayaKanadaka-Regular.ttf", Alias = "FontAk")]
[assembly: ExportFont("Teko-Regular.ttf", Alias = "FontTk")]

namespace SwiftTraderPRoject
{
    
    public partial class App : Application
    {
        //public bool Checker { get; set; } = true;
        public App()
        {
            InitializeComponent();
           // string userName = Prefer
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
