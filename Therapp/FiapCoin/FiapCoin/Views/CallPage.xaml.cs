using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
    public partial class CallPage : ContentPage
    {
        public CallPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); //must happen FIRST
            Device.BeginInvokeOnMainThread(() => { DisplayAlert(Global.Cliente.name+" agora é só aguardar!", "\nUm terapeuta já irá atende-lo...", "OK"); });
            RunTimePermission();

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