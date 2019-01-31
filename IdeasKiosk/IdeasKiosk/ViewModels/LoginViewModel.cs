using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using IdeasKiosk.Data;
using IdeasKiosk.Helpers;
using IdeasKiosk.Models.Core;
using IdeasKiosk.Views;
using Xamarin.Forms;

namespace IdeasKiosk.ViewModels
{
    public class LoginViewModel
    {
        public Command LoginCommand { get; set; }
        public INavigation Navigation { get; set; }
        private IRepository<Preferences> _contactRepo;

        public List<Preferences> Prefrences { get; set; }

        public string Server { get; set; }

        public LoginViewModel(INavigation navigation )
        {
            this.Navigation = navigation;

            _contactRepo = new Repository<Preferences>(App.ConnectionService);
            LoginCommand = new Command(async () => await OnLoginButtonClicked());

            Preferences pre = AsyncHelpers.RunSync(() => _contactRepo.GetAllAsync()).FirstOrDefault();

            if (pre !=null)
                this.Server = pre.Url;
        }

        private async Task OnLoginButtonClicked()
        {
            Prefrences = await _contactRepo.GetAllAsync();
            if (Prefrences.Any())
            {
                Prefrences[0].Url = Server;
                await _contactRepo.UpdateAsync(Prefrences[0]);
            }
            else
            {
                await _contactRepo.InsertAsync(new Preferences()
                {
                    Url = Server,
                });
            }

            App.AppPreferences = await _contactRepo.GetAllAsync();
            await Navigation.PushModalAsync(new HomePage());
        }
    }
}
