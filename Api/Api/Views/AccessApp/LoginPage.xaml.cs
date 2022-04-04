using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Api.ViewModels;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace Api.Views.AccessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();

            txtEmail.Completed += (object sender, EventArgs e) =>
            {
                txtPassw.Focus();
            };
            txtPassw.Completed += async (object sender, EventArgs e) =>
            {
                await DisplayAlert("Listo", "Datos completos", "Ok");
            };
        }


        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            bool suported = await
                CrossFingerprint.Current.IsAvailableAsync(true);

            if (suported)
            {
                AuthenticationRequestConfiguration conf =
                    new AuthenticationRequestConfiguration("access your account", "access");
                var result = await CrossFingerprint.Current.AuthenticateAsync(conf);
                if (result.Authenticated)
                {
                    await DisplayAlert("sucess", "autenticated", "ok");
                    await Navigation.PushAsync(new Products());
                }
                else
                {
                    await DisplayAlert("error", "no autenticated", "ok");
                }

            }
            else
            {
                await DisplayAlert("sorry", "no biometrics", "ok");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Products());
        }
    }
}