using System;
using Xamarin.Forms;
using APP.Views;
using Xamarin.Forms.Xaml;
using APP.Data;

namespace APP
{
    public partial class App : Application
    {
        public static UsuarioItemManager UsuarioManager { get; private set; }
        public App()
        {
            InitializeComponent();
            UsuarioManager = new UsuarioItemManager(new RestService());
            MainPage = new NavigationPage(new homePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
