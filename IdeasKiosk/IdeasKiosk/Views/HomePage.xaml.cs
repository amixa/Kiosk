using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using IdeasKiosk.ViewModels;
using Xamarin.Forms;

namespace IdeasKiosk.Views
{
    public partial class HomePage : ContentPage
    {
        private HomeViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel =new HomeViewModel(Navigation);
        }

        void backClicked(object sender, System.EventArgs e)
        {
            // Check to see if there is anywhere to go back to
            if (Browser.CanGoBack)
            {
                Browser.GoBack();
            }
            else
            { // If not, leave the view
                Navigation.PopAsync();
            }
        }

        void forwardClicked(object sender, System.EventArgs e)
        {
            if (Browser.CanGoForward)
            {
                Browser.GoForward();
            }
        }

        void Handle_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
        {
            viewModel.CurrentUrl = e.Url;
        }
    }
}
