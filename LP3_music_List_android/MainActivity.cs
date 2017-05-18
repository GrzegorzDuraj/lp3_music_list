using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace LP3_music_List_android
{
    [Activity(Label = "LP3_music_List_android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        FetchList fetchList = new FetchList();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Console.WriteLine("GRDU MainActivity OnCreate()");
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button fetchListButton = this.FindViewById<Button>(Resource.Id.FetchListButton);

            fetchList.GetSite();
          
        }
    }
}

//$ nox_adb connect 127.0.0.1:62001
