using Api.Models;
using Api.Views.DinamicList;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Api.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        #region Attributes
        public string numero;
        public string nombrepro;

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Properties
        public string NumeroTxt
        {
            get { return this.numero; }
            set { SetValue(ref this.numero, value); }
        }

        public string NombreProTxt
        {
            get { return this.nombrepro; }
            set { SetValue(ref this.nombrepro, value); }
        }

        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        #endregion

        #region Commands
        public ICommand ProductCommand
        {
            get
            {
                return new RelayCommand(ProductMethod);
            }
        }
        #endregion

        #region Methods
        public async void ProductMethod()
        {
            if (string.IsNullOrEmpty(this.numero))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Code.",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.nombrepro))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a Name.",
                    "Accept");
                return;
            }
            this.IsVisibleTxt = true;
            this.IsRunningTxt = true;
            this.IsEnabledTxt = false;


            var prod = new ProductModel
            {
                Numero = numero,
                NombrePro = nombrepro,
            };
            await App.Database.SaveProdModelAsync(prod);
           
            this.IsRunningTxt = false;
            this.IsVisibleTxt = false;
            this.IsEnabledTxt = true;
            await Application.Current.MainPage.Navigation.PushAsync(new ListViewPage());
        }

        

        #endregion

        #region Constructor
        public ProductsViewModel()
        {
            this.IsEnabledTxt = true;
        }
        #endregion
    }
}
