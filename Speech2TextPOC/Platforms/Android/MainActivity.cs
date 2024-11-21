using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Speech2TextPOC
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {

        const int MicrophonePermissionRequestCode = 100;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Check and request microphone permission at runtime
            CheckAndRequestMicrophonePermission();
        }
        /// <summary>
        /// Checks if the microphone permission is granted; if not, requests it.
        /// </summary>
        void CheckAndRequestMicrophonePermission()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                if (CheckSelfPermission(Android.Manifest.Permission.RecordAudio) != Permission.Granted)
                {
                    RequestPermissions(new[] { Android.Manifest.Permission.RecordAudio }, MicrophonePermissionRequestCode);
                }
                if (CheckSelfPermission(Android.Manifest.Permission.ModifyAudioSettings) != Permission.Granted)
                {
                    RequestPermissions(new[] { Android.Manifest.Permission.ModifyAudioSettings }, MicrophonePermissionRequestCode);
                }
                if (CheckSelfPermission(Android.Manifest.Permission.ReadExternalStorage) != Permission.Granted)
                {
                    RequestPermissions(new[] { Android.Manifest.Permission.ReadExternalStorage }, MicrophonePermissionRequestCode);
                }
                if (CheckSelfPermission(Android.Manifest.Permission.WriteExternalStorage) != Permission.Granted)
                {
                    RequestPermissions(new[] { Android.Manifest.Permission.WriteExternalStorage }, MicrophonePermissionRequestCode);
                }
            }
        }
        /// <summary>
        /// Handles the result of the runtime permission request.
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == MicrophonePermissionRequestCode)
            {
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    // Permission granted
                }
                else
                {
                    // Permission denied; consider showing a message to the user
                    Android.Widget.Toast.MakeText(this, "Microphone permission is required for this feature.", Android.Widget.ToastLength.Long).Show();
                }
            }
        }
    }
}
