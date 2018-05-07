using System;
using Prism.Mvvm;

namespace TravelingApp481.Models
{
    /// <summary>
    /// Simple model class for a Person. This is the data type our ListView contains.
    /// </summary>
    public class City : BindableBase
    {


        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set { SetProperty(ref _cityName, value); }
        }

        public override string ToString()
        {
            return $"CategoryName={CityName}";
        }
    }
}