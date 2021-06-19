using SwiftTraderPRoject.Services;
using SwiftTraderPRoject.Services.APIServices;
using SwiftTraderPRoject.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwiftTraderPRoject.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string fullname;
        public string Fullname
        {
            get { return fullname; }
            set { fullname = value; OnPropertyChanged(); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value.Trim(); OnPropertyChanged(); }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }

        private string telephone;
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value.Trim(); OnPropertyChanged(); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value.Trim().ToLower(); OnPropertyChanged(); }
        }

        private string cpassword;
        public string CPassword
        {
            get { return cpassword; }
            set { cpassword = value.Trim().ToLower(); OnPropertyChanged(); }
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

        public Command RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;

                if(string.IsNullOrEmpty(Fullname))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Name cannot be empty", "Ok");
                    return;
                }
                else if (string.IsNullOrEmpty(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Email cannot be empty", "Ok");
                    return;
                }
                else if (string.IsNullOrEmpty(Username))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Username cannot be empty", "Ok");
                    return;
                }
                else if (string.IsNullOrEmpty(Telephone))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Telephone number cannot be empty", "Ok");
                    return;
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password cannot be empty", "Ok");
                    return;
                }
                else if (string.IsNullOrEmpty(CPassword))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Confirm Password cannot be empty", "Ok");
                    return;
                }

              if(Password == CPassword)
               {
                    //FireBase
                    UserServices userServices = new UserServices();
                    result = await userServices.RegisterUser(fullname, email, username, telephone, password, cpassword);

                    //RestAPI
                    //UserService userServices = new UserService();
                    //await userServices.AddUser(Fullname, Email, Username, Telephone, Password);

                    if (Result)
                    {
                        var currentuser = await userServices.UserData(Email, Password);
                        Preferences.Get("Fullname", currentuser.Fullname);
                        Preferences.Get("Email", currentuser.Email);
                        Preferences.Set("Username", currentuser.Username);
                        Preferences.Set("Telephone", currentuser.Telephone);

                        await Application.Current.MainPage.DisplayAlert("Success!", "Your Registration was succesful", "Ok");
                        Application.Current.MainPage = new DashBoard();
                    }
                    else { await Application.Current.MainPage.DisplayAlert("Error", "User already exist with the  following credentials", "Ok"); }
                }
                else { await Application.Current.MainPage.DisplayAlert("Error", "Password do not match", "Ok"); }


            }
            catch (Exception)
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Please check your Connection", "Ok");
            }
            finally { IsBusy = false; }
        }
    }
}
