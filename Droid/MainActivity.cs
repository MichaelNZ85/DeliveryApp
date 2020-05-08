using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Linq;

namespace DeliveryApp.Droid
{
    [Activity(Label = "DeliveryApp", MainLauncher = true, Icon = "@mipmap/icon")]

    public class MainActivity : Activity
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://deliveriesapp-bigpurrrs.azurewebsites.net");

        EditText emailEditText,passwordEditText;
        Button signInButton, regoButton;

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

        }

        private void RegoButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RegoActivity));
            intent.PutExtra("email", emailEditText.Text);
            StartActivity(intent);
        }

        private async void SignInButton_Click(object sender, System.EventArgs e)
        {
            var email = emailEditText.Text;
            var password = passwordEditText.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                Toast.MakeText(this, "Email and/or password is empty", ToastLength.Long).Show();
            else
            {
                try
                {
                    var user = (await MobileService.GetTable<DeliveryUser>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                
                if (user.Password == password)
                    Toast.MakeText(this, "Login successful", ToastLength.Long).Show();
                else
                    Toast.MakeText(this, "Incorrect password", ToastLength.Long).Show();

                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                    Toast.MakeText(this, "Error getting user details", ToastLength.Long).Show();
                }
            }

        }

        
    }
}

