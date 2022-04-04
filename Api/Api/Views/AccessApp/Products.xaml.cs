using Api.Services;
using Api.ViewModels;
using Api.Views.DinamicList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Api.Views.AccessApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        public Products()
        {
            InitializeComponent();
            BindingContext = new ProductsViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = DependencyService.Get<IScanner>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode.Text = result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}