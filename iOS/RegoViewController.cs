using DeliveryApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveryApp.iOS
{
    public partial class RegoViewController : UIViewController
    {
        public string emailAddress;
        
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
            UIAlertController alert = null;
            var result = await DeliveryUser.Register(emailTextField.Text, passwordTextField.Text, confirmPasswordTextField.Text);
            if (result)
            {
                 alert = UIAlertController.Create("Success", "User successfully registered", UIAlertControllerStyle.Alert);

            }
            else
            {
                alert = UIAlertController.Create("Failure", "Registration failed", UIAlertControllerStyle.Alert);                
            }
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }
    }
}