using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Prism.Navigation;
using Prism.Commands;
using Prism.Unity;
using TravelingApp481.ViewModels;
using TravelingApp481.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelingApp481.ViewModels
{

    public class LoginPageViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        

        public static Dictionary<string, string> dict = new Dictionary<string, string>() { { "Jsmith", "123456" } };


        public DelegateCommand NavToRegisterCommand { get; set; }
        public DelegateCommand LoginPageCommand { get; set; }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _userC;
        public string userC
        {
            get { return _userC; }
            set { SetProperty(ref _userC, value); }
        }
        private string _userPass;
        public string userPass
        {
            get { return _userPass; }
            set { SetProperty(ref _userPass, value); }
        }

        public LoginPageViewModel(INavigationService navigationService)
        {

            Debug.WriteLine($"****{this.GetType()}:  ctor");


            Title = "Launch Page";
            _navigationService = navigationService;

            NavToRegisterCommand = new DelegateCommand(OnNavToRegisterPage);
            LoginPageCommand = new DelegateCommand(OnNavToMainPage);

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedTo)}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
        }

        private void OnNavToRegisterPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToRegisterPage)}");
            _navigationService.NavigateAsync("RegisterPage");
        }
        private void OnNavToMainPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToMainPage)}");
            if (userC == null || userPass == null)
            {
                userPass = "";
                userC = "";
            }

            if (dict.ContainsKey(userC))
            {

                if (dict[userC].Equals(userPass))
                {
                    _navigationService.NavigateAsync("/MainPage/");
                }
            }


        }

    }
}