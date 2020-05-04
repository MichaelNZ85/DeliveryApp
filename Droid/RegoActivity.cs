using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            regoButton = FindViewById<Button>(Resource.Id.regoButton);

            regoButton.Click += RegoButton_Click;
            string email = Intent.GetStringExtra("email");
            emailEditText.Text = email;
        }

        private void RegoButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}