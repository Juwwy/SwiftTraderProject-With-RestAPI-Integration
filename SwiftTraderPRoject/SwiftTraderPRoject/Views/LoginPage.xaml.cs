using SwiftTraderPRoject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwiftTraderPRoject.Views
{
    public partial class LoginPage : ContentPage
    {
        Page onBoarding;
        public LoginPage()
        {
            
            InitializeComponent();

            if (ShouldShowBoarding() == true)
            {
                Application.Current.ModalPopping += Current_ModalPopping;
                onBoarding = new OnBoardingPage();
                Navigation.PushModalAsync(onBoarding, false);
            }
        }

        private void Current_ModalPopping(object sender, ModalPoppingEventArgs e)
        {
            if(e.Modal == onBoarding)
            {
                FadeBox.FadeTo(0, 1000);
                onBoarding = null;
                App.Current.ModalPopping -= Current_ModalPopping;
            }
        }

        private bool ShouldShowBoarding()
        {
            return true;
        }

        private void Create_link(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new RegisterPage());
        }
    }
}
