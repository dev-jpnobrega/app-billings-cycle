using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Gcm.Client;
using FormsPlugin.Iconize.Droid;

namespace MyMoney.Droid
{
    [Activity(Label = "MyMoney", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static MainActivity instance = null;

        public static MainActivity CurrentActivity
        {
            get
            {
                return instance;
            }
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            instance = this;

            IconControls.Init(Resource.Layout.Toolbar, Resource.Layout.Tabbar);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            
            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            LoadApplication(new App());

            CheckGcmClient();
        }


        private void CheckGcmClient()
        {
            try
            {
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);

                GcmClient.Register(this, Service.PushHandlerBroadcastReceiver.SENDER_IDS);
            }
            catch (Java.Net.MalformedURLException)
            {
                CreateAndShowDialog("There was an error creating the client. Verify theURL.", "Error");
            }
            catch (Exception e)
            {
                CreateAndShowDialog(e.Message, "Error");
            }
        }


        private void CreateAndShowDialog(String message, String title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}

