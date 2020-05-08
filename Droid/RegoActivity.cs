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
            regoButton = FindViewById<Button>(Resource.Id.regoUserButton);

            regoButton.Click += RegoButton_Click;
            string email = Intent.GetStringExtra("email");
            emailEditText.Text = email;
        }

        private async void RegoButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordEditText.Text))
            {
                if(passwordEditText.Text == confirmPasswordEditText.Text )
                {
                    var deliveryUser = new DeliveryUser()
                    {
                        Email = emailEditText.Text,
                        Password = passwordEditText.Text
                    };
                    try
                    {
                        await MainActivity.MobileService.GetTable<DeliveryUser>().InsertAsync(deliveryUser);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: SOMETHING WENT WRONG WITH THE AZURE CONNECTION");
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine($"Exception message: {ex.Message}");
                        Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner Exception: { ex.InnerException.Message}");
                        }
                        Console.WriteLine("END OF ERROR REPORTING");
                        Toast.MakeText(this, $"Error occurred: {ex.Message}", ToastLength.Long).Show();
                    }
                    Toast.MakeText(this, "Success", ToastLength.Long).Show();
                }

                Toast.MakeText(this, "Passwords do not match", ToastLength.Long).Show(); ;
            }
            Toast.MakeText(this, "Password cannot be empty", ToastLength.Long).Show(); ;
        }
    }
}