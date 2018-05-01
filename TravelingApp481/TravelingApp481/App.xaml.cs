using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using TravelingApp481.ViewModels;
using TravelingApp481.Views;
using Xamarin.Forms;

namespace TravelingApp481
{
    public partial class App : PrismApplication
    {
        //public App ()
        //{
        //	InitializeComponent();

        //	MainPage = new TravelingApp481.MainPage();
        //}
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnInitialized)}");
            InitializeComponent();

            NavigationService.NavigateAsync(nameof(MainPage));
        }
        protected override void RegisterTypes(Prism.Ioc.IContainerRegistry containerRegistry)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypes)}");

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<TouristSpotsYelp, TouristSpotsPageViewModel>();
            
           
        }
            

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
