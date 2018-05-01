using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using TravelingApp481.Helpers;
using TravelingApp481.Models;

namespace TravelingApp481.Services
{
    public class YelpApiService
    {
        /*  
         * ANDROID WARNING:  Your api calls will almost certainly fail with the default Android project
         * settings, which use the default, "Managed (HttpClientHandler)" setting for the HttpClient Implementation.
         *
         * Switch this setting to "AndroidClientHandler" in order to make things work correctly.
         * For reference:  https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/http-stack?tabs=vsmac
         */


        private bool _useVerboseOutput = false;
        private string _baseUrl = "https://api.yelp.com";

        private HttpClient _httpClient;

        public YelpApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",AppSecrets.YelpFinderApiKey);
           // _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
          //  _httpClient.Timeout = TimeSpan.FromSeconds(5);
        }

        public bool DoIHaveInternet()
        {
            if (!CrossConnectivity.IsSupported)
            {
                Debug.WriteLine($"**** {this.GetType().Name}.{nameof(DoIHaveInternet)}:  Not supported... Returning true no matter what.");
                return true;
            }

            bool hasNet = CrossConnectivity.Current.IsConnected;
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(DoIHaveInternet)}:  returning {hasNet}");
            return hasNet;
        }

        public async Task<ObservableCollection<string>> GetDestinationsAsync(string cityname)
        {
            
            int i=0;
            if (!DoIHaveInternet())
                return null;

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri($"{_baseUrl}/v3/businesses/search?term=tourist&location={cityname}");

            var content = new StringContent(string.Empty);
            ObservableCollection<string> locations = null;

            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GetDestinationsAsync)}:  Sending request={request.RequestUri.ToString()}");

            try
            {
                // Since HttpResponseMessage is IDisposable, we put it in a "using" block to be automatically disposed.
                using (HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request))
                {
                    if (httpResponseMessage.IsSuccessStatusCode == false)
                    {
                        Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GetDestinationsAsync)}:  Request failed. StatusCode={httpResponseMessage.StatusCode}");
                        return null;
                    }

                    string responseAsString = await httpResponseMessage.Content.ReadAsStringAsync();

                    TouristPlaceResponse resultsDeserialized = JsonConvert.DeserializeObject<TouristPlaceResponse>(responseAsString);
                    locations = new ObservableCollection<string>(resultsDeserialized.Businesses.Select(s => s.Name));
                      

         var debugComment = _useVerboseOutput
             ? $"Request succeeded!\n{responseAsString}"
             : $"Request succeeded! We've got {resultsDeserialized.Businesses} breeds!";

         Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GetDestinationsAsync)}:  {debugComment}");
    } // our HttpResponseMessage gets disposed here.
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GetDestinationsAsync)}:  EXCEPTION:  {ex}");
            }

            return locations;
        }
    }
}