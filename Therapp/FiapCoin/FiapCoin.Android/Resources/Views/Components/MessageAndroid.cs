using System;
using Android.App;
using Android.Widget;
using THERAPP.Droid.Views.Components;
using THERAPP.Views.Components;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))] 
namespace THERAPP.Droid.Views.Components
{
    public class MessageAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}
