using Android.App;
using Android.Widget;
using Android.OS;

namespace LP3_music_List_android
{
    [Activity(Label = "LP3_music_List_android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button fetchList = this.FindViewById<Button>(Resource.Id.FetchListButton);


          
        }
    }
}

