using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Api.ViewModels;

namespace Api.Views.AccessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();

            txtEmail.Completed += (object sender, EventArgs e) =>
            {
                txtPass.Focus();
            };
            txtPass.Completed += (object sender, EventArgs e) =>
            {
                txtFullname.Focus();
            };
            txtFullname.Completed += (object sender, EventArgs e) =>
            {
                txtAge.Focus();
            };
            txtAge.Completed += async (object sender, EventArgs e) =>
            {
                await DisplayAlert("Listo", "Datos completos", "Ok");
            };

        }


        private async void NavToLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}