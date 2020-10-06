using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THERAPP.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace THERAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeusDadosPage : ContentPage
    {
        public MeusDadosPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing(); //must happen FIRST
            Device.BeginInvokeOnMainThread(() => { DisplayAlert("Para te atender melhor.", "\nPedimos que você mantenha seus dados atualizados.", "OK"); });

            if (Global.Cliente.gender == "nb")
            {
                PickerSex.SelectedIndex = 3;
            }
            //forums say the below line (with async method) should work the same as BeginInvokeOnMainThread(), but in actual testing, it fails.
            //await DisplayAlert("Title", "My Message", "OK"); 
        }
    }
}