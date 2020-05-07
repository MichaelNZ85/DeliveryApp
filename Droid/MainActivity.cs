using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;
using System;

namespace DeliveryApp.Droid
{
    [Activity(Label = "DeliveryApp", MainLauncher = true, Icon = "@mipmap/icon", Theme="@android:style/Theme.Black.Fullscreen")]

    public class MainActivity : Activity
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://deliveriesapp-bigpurrrs.azurewebsites.net");

        EditText emailEditText,passwordEditText;
        Button signInButton, regoButton;
        Button testButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signInButton = FindViewById<Button>(Resource.Id.signInButton);
            regoButton = FindViewById<Button>(Resource.Id.regoButton);

            signInButton.Click += SignInButton_Click;
            regoButton.Click += RegoButton_Click;
            testButton.Click += TestButton_Click;

        }

        private void RegoButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RegoActivity));
            intent.PutExtra("email", emailEditText.Text);
            StartActivity(intent);
        }

        private void SignInButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private async void TestButton_Click(object sender, System.EventArgs ea)
        {
            try
            {
                var bigpurrs = await MobileService.GetTable<DeliveryUser>().ToListAsync();
                foreach (DeliveryUser del in bigpurrs)
                    Console.WriteLine(del);
            } 
            catch(Exception ex)
            {
                Console.WriteLine("ERROR: SOMETHING WENT WRONG ACCESSING THE AZURE CONNECTION");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine($"Exception message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: { ex.InnerException.Message}");
                }
                Console.WriteLine("END OF ERROR REPORTING. SO LONG SUCKERS!");
                Toast.MakeText(this, $"Error occurred: {ex.Message}", ToastLength.Long).Show();
            }
        }
    }
}

