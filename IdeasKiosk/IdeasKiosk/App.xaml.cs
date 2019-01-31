using System.Collections.Generic;
using System.Linq;
using IdeasKiosk.Data;
using IdeasKiosk.Models.Core;
using IdeasKiosk.Views;
using Xamarin.Forms;

namespace IdeasKiosk
{
    public partial class App : Application
    {

        static List<Preferences> appPreferences;
        public static List<Preferences> AppPreferences
        {
            get { return appPreferences; }
            set { appPreferences = value; }
        }

        private IRepository<Preferences> _contactRepo;

        static ISQLiteConnection connectionService;
        public static ISQLiteConnection ConnectionService
        {
            get
            {
                if (connectionService == null)
                {
                    connectionService = DependencyService.Get<ISQLiteConnection>();
                }
                return connectionService;
            }
        }



        public App()
        {
            InitializeComponent();
           
            _contactRepo = new Repository<Preferences>(ConnectionService);
            MainPage = new NavigationPage(new LoginPage());        
        }

        protected async override void OnStart()
        {
            base.OnStart();
            AppPreferences = await _contactRepo.GetAllAsync();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
