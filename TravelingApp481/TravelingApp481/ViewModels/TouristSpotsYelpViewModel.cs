﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TravelingApp481.Helpers;
using TravelingApp481.Services;
using TravelingApp481.Views;
using Prism.Commands;
using Prism.Navigation;

namespace TravelingApp481.ViewModels
{
    public class TouristSpotsPageViewModel : ViewModelBase
    {
        public DelegateCommand BreedListRefreshCommand { get; set; }
        public DelegateCommand<string> BreedTappedCommand { get; set; }

        YelpApiService _petFinderService;

        private ObservableCollection<string> _locations;
        public ObservableCollection<string> Locations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { SetProperty(ref _isRefreshing, value); }
        }

        public TouristSpotsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _petFinderService = new YelpApiService();
            BreedListRefreshCommand = new DelegateCommand(OnPullToRefresh);
            BreedTappedCommand = new DelegateCommand<string>(OnBreedTapped);
           
        }


        private async void OnBreedTapped(string breedTapped)
        {
           // NavigationParameters navParams = new NavigationParameters();
            //navParams.Add(NavigationParameterKeys.BREED_OBJECT_KEY, breedTapped);
            //await _navigationService.NavigateAsync(nameof(BreedDetailsPage), navParams, false, true);
        }

        private async void OnPullToRefresh()
        {
            await RefreshBreedListAsync();
        }

        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            IsRefreshing = true;
            await RefreshBreedListAsync();
        }

        private async Task RefreshBreedListAsync()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RefreshBreedListAsync)}");

            try
            {
                Locations = await _petFinderService.GetDestinationsAsync("SanDiego,CA");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RefreshBreedListAsync)}: EXCEPTION!!! {ex}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}