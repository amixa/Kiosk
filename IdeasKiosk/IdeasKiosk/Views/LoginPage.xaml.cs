using System;
using System.Collections.Generic;
using IdeasKiosk.ViewModels;
using Xamarin.Forms;

namespace IdeasKiosk.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }
    }
}
