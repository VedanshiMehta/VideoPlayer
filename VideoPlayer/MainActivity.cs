using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace VideoPlayer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private VideoView _videoView;
        private MediaController _mediaController;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            _videoView = FindViewById<VideoView>(Resource.Id.videoView);

            // _videoView.SetVideoPath("android.res://" + PackageName + "/" + Resource.Raw.story);
            _videoView.SetVideoURI(Android.Net.Uri.Parse($"android.resource://{Android.App.Application.Context.PackageName}/raw/story"));
            _mediaController = new MediaController(this);
            _mediaController.SetAnchorView(_videoView);
            _videoView.SetMediaController(_mediaController);

            _videoView.Start();

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}