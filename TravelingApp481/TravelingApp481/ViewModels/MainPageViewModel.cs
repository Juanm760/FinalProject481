using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TravelingApp481.Views;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.ComponentModel;
using TravelingApp481.Helpers;
using TravelingApp481.Models;
using Prism.Services;

namespace TravelingApp481.ViewModels
{
    public class MainPageViewModel : BindableBase
    {

        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand ShowAlertCommand { get; set; }
        INavigationService _navigationService;
        IPageDialogService _pageDialogService;

        //Note:  This is bound to the ItemsSource for the ListView on MainPage.


        //Note:  Bound to both the ContentPage's AND the ListView's busy properties:  IsBusy is the
        //          property for the ContentPage, and IsRefreshing is the property for the ListView.


        //Note:  This is bound to the currently selected person in the ListView.
        private string _search;
        public string Search
        {
            get { return _search; }
            set { SetProperty(ref _search, value); }
        }

        private City _citySearch;
        public City CitySearch
        {
            get { return _citySearch; }
            set { SetProperty(ref _citySearch, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            SearchCommand = new DelegateCommand(OnSearch);
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            ShowAlertCommand = new DelegateCommand(OnShowAlert);
        }

        private async void OnShowAlert()
        {
              await _pageDialogService.DisplayAlertAsync("Incorrect Format", "You have entered an incorrect format, try again", "Ok");
        }

        private async void OnSearch()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnSearch)}");
            CitySearch = new City();
            CitySearch.CityName = Search;
            if(Search.Contains(','))
            {
                CitySearch.CityName = Search;
                NavigationParameters navParam = new NavigationParameters();
                navParam.Add(Helpers.NavParameterKeys.cityNameSt, CitySearch);
                await _navigationService.NavigateAsync("TravelAppContainerPage", navParam);
            }
            else
            {
                OnShowAlert();
                return;
            }
            
        }
    }
}