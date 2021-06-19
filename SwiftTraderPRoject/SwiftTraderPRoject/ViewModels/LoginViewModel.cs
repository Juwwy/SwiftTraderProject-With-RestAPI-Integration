using SwiftTraderPRoject.Services;
using SwiftTraderPRoject.Views;
using SwiftTraderPRoject.Views.Admin;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwiftTraderPRoject.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value.Trim().ToLower(); OnPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value.Trim().ToLower(); OnPropertyChanged(); }
        }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged(); }
        }

        private bool result;
        public bool Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }

        public Command LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                if (string.IsNullOrEmpty(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Email cannot be empty", "Ok");
                    return;
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password cannot be empty", "Ok");
                    return;
                }

                UserServices userServices = new UserServices();
                Result = await userServices.LoginUser(Email, Password);

                if (Result)
                {
                    var currentuser = await userServices.UserData(Email, Password);
                    //Preferences.Set("Fullname", Email);
                    //Preferences.Set("Username", Username);

                    Preferences.Set("Email", currentuser.Email);
                    Preferences.Set("Username", currentuser.Username);
                    Preferences.Set("Telephone", currentuser.Telephone);

                    await Application.Current.MainPage.DisplayAlert("Success!", "You Login was succesful", "Ok");
                   if(Email == "Harry@gmail.com" || Username == "harry@gmail.com")
                    {
                        Application.Current.MainPage = new AdminMainPage();
                    }
                    else { Application.Current.MainPage = new MainDashBoard(); }
                }
                else { await Application.Current.MainPage.DisplayAlert("Error", "Incorrect details!", "Ok"); }


            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally { IsBusy = false; }
        }
    }
}
