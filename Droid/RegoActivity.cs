using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliveryApp.Model;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DeliveryApp.Droid
{
    [Activity(Label = "RegoActivity")]
    public class RegoActivity : Activity
    {
        EditText emailEditText, passwordEditText, confirmPasswordEditText;
        Button regoButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            emailEditText = FindViewById<EditText>(Resource.Id.regoEmailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.regoPasswordEditText);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.regoConfirmPassword);
            regoButton = FindViewById<Button>(Resource.Id.regoUserButton);

            regoButton.Click += RegoButton_Click;
            string email = Intent.GetStringExtra("email");
            emailEditText.Text = email;
        }

        private async void RegoButton_Click(object sender, EventArgs e)
        {
            var result = await DeliveryUser.Register(emailEditText.Text, passwordEditText.Text, confirmPasswordEditText.Text);
            if (result)
                Toast.MakeText(this, "Registration Successful", ToastLength.Long).Show();
            else
                Toast.MakeText(this, "Registration Failed", ToastLength.Long).Show();
        }
    }
}