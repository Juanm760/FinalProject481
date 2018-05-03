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

namespace TravelingApp481.ViewModels
{
    public class MainPageViewModel : BindableBase
    {

        public DelegateCommand SearchCommand { get; set; }
        INavigationService _navigationService;

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
        
        public MainPageViewModel(INavigationService navigationService) 
        {
            SearchCommand = new DelegateCommand(OnSearch);
            _navigationService = navigationService;
        }

        private async void OnSearch()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnSearch)}");
            await _navigationService.NavigateAsync("TravelAppContainerPage");
        }
    }
}