using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BlocoNotas.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BlocoNotas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListNotesPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
