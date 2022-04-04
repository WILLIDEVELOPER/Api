using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof(NavExp.Droid.Services.Escaner))]

namespace NavExp.Droid.Services
{
    public class Escaner : IScanner
    {
        public async Task<string> ScanAsync()
        {
            var Optons = new MobileBarcodeScanningOptions();
            var Custom = new MobileBarcodeScanningOptions();

            var scan = new MobileBarcodeScanner()
            {
                TopText = "acerca la camara",
                BottomText = "toca la pantalla para enfocar",
            };

            var Results = await scan.Scan(Custom);
            return Results.Text;
        }
    }
}