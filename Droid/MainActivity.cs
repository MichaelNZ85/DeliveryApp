using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
//using Microsoft.WindowsAzure.MobileServices;

namespace DeliveryApp.Droid
{
    [Activity(Label = "DeliveryApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

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

        private void SignInButton_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}

