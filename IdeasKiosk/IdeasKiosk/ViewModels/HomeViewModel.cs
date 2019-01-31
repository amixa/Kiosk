using System;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IdeasKiosk.Data;
using IdeasKiosk.Helpers;
using IdeasKiosk.Models.Core;
using IdeasKiosk.Views;
using Planbox.ViewModels;
using Xamarin.Forms;

namespace IdeasKiosk.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private IRepository<Preferences> _contactRepo;

        public string ServerUrl { get; set; }

        private string currentUrl;
        public string CurrentUrl
        {
            get
            {
                return currentUrl;
            }
            set 
            {
                currentUrl = value;
                OnPropertyChanged();
            } 
        }
      
        public HomeViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            _contactRepo = new Repository<Preferences>(App.ConnectionService);

            Preferences pre = AsyncHelpers.RunSync(() => _contactRepo.GetAllAsync()).FirstOrDefault();           
            this.ServerUrl = pre.Url;
            this.CurrentUrl = ServerUrl;
        }
    }
}
