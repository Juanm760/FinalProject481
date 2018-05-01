// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using TravelingApp481.models;
//
//    var touristPlaceResponse = TouristPlaceResponse.FromJson(jsonString);
using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TravelingApp481.Models
{
    
    public partial class TouristPlaceResponse
    {
        [JsonProperty("businesses")]
        public List<Business> Businesses { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }
    }

    public partial class Business
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("review_count")]
        public long ReviewCount { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("coordinates")]
        public Center Coordinates { get; set; }

        [JsonProperty("transactions")]
        public List<object> Transactions { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("display_phone")]
        public string DisplayPhone { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("alias")]
        public string Alias { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public partial class Center
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("address3")]
        public string Address3 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("display_address")]
        public List<string> DisplayAddress { get; set; }
    }

    public partial class Region
    {
        [JsonProperty("center")]
        public Center Center { get; set; }
    }

    public partial class TouristPlaceResponse
    {
        public static TouristPlaceResponse FromJson(string json) => JsonConvert.DeserializeObject<TouristPlaceResponse>(json, TravelingApp481.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TouristPlaceResponse self) => JsonConvert.SerializeObject(self, TravelingApp481.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
