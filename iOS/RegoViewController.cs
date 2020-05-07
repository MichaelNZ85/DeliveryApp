using Foundation;
using System;
using UIKit;

namespace DeliveryApp.iOS
{
    public partial class RegoViewController : UIViewController
    {
        public string emailAddress;

        public static 
        
        public RegoViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            emailTextField.Text = emailAddress;
            regoButton.TouchUpInside += RegoButton_TouchUpInside;
        }

        private async void RegoButton_TouchUpInside(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordTextField.Text))
            {
                if (passwordTextField.Text == confirmPasswordTextField.Text)
                {
                    var deliveryUser = new DeliveryUser()
                    {
                        Email = emailTextField.Text,
                        Password = passwordTextField.Text
                    };
                    try
                    {
                        await AppDelegate.MobileService.GetTable<DeliveryUser>().InsertAsync(deliveryUser);
                        var alert = UIAlertController.Create("Success", "User inserted successfully", UIAlertControllerStyle.Alert);
                        alert.AddAction(UIAlertAction.Create("Okay", UIAlertActionStyle.Default, null));
                        PresentViewController(alert, true, null);
                        return;
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
                        //Toast.MakeText(this, $"Error occurred: {ex.Message}", ToastLength.Long).Show();
                    }
                    //Toast.MakeText(this, "Success", ToastLength.Long).Show();
                }

                //Toast.MakeText(this, "Passwords do not match", ToastLength.Long).Show(); ;
            }
            //Toast.MakeText(this, "Password cannot be empty", ToastLength.Long).Show(); ;
        }
    }
}