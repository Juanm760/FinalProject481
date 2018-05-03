using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Prism;
using Prism.Mvvm;

namespace TravelingApp481.ViewModels
{
    public class Page1ViewModel : BindableBase, IActiveAware
    {
        private string _title;
        private string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public event EventHandler IsActiveChanged;
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
                IsActiveChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public Page1ViewModel()
        {
            Debug.WriteLine($)
        }
    }
}
