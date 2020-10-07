using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using THERAPP.Model;


namespace THERAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallPage : ContentPage
    {
        private int i = 0;

        public CallPage()
        {
            InitializeComponent();
        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            
            var status = PermissionStatus.Unknown;

            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (status != PermissionStatus.Granted)
            {

                status = await Utils.CheckPermissions(Permission.Camera);
            }

            if (status == PermissionStatus.Granted)
            {
                if (i < 1)
                {
                    webView.Source = "https://freetos.ml/video/nomeVideoChamada#config.disableDeepLinking=true/"; //"https://test.webrtc.org/";
                    App.MensagemAlerta(Global.Cliente.name + " agora é só aguardar!", "\nUm terapeuta já irá atende-lo...");
                    _button.Text = "Consulta de " + Global.Cliente.name;
                    i = i + 1;
                }
                else
                {
                    App.MensagemAlerta("Por favor aguarde", "Um profissional já está a caminho...");
                }
            }

        }

        private async void _buttonEnd_Clicked(object sender, EventArgs e)
        {
            var status = PermissionStatus.Unknown;

            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (status != PermissionStatus.Granted)
            {

                status = await Utils.CheckPermissions(Permission.Camera);
            }

            if (status == PermissionStatus.Granted)
            {
                webView.Source = "https://freetos.ml/video/nomeVideoChamada#config.disableDeepLinking=true/"; //"https://test.webrtc.org/";
                App.MensagemAlerta(Global.Cliente.name + " agora é só aguardar!", "\nUm terapeuta já irá atende-lo...");
            }

        }


        protected override void OnAppearing()
        {
            base.OnAppearing(); //must happen FIRST
            RunTimePermission();
            //Device.BeginInvokeOnMainThread(() => { DisplayAlert(Global.Cliente.name + " agora é só aguardar!", "\nUm terapeuta já irá atende-lo...", "OK"); });
            //String ae= "Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.4) Gecko/20100101 Firefox/4.0";
        }

        public async void RunTimePermission()
        {
            var status = PermissionStatus.Unknown;

            status = await Plugin.Permissions.CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (status != PermissionStatus.Granted)
            {

                status = await Utils.CheckPermissions(Permission.Camera);
                await Utils.CheckPermissions(Permission.Microphone);

            }

            status = await Plugin.Permissions.CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Microphone);
            if (status != PermissionStatus.Granted)
            {
                status = await Utils.CheckPermissions(Permission.Microphone);

            }

            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (status != PermissionStatus.Granted)
            {

                status = await Utils.CheckPermissions(Permission.Camera);
            }
        }

        public void ConsultasClicked(object o, EventArgs e)
        {
            MessagingCenter.
                Send<ConsultasPage>(
                    new ConsultasPage(),
                    "ConsultasPageAbrir");
        }
    }
}