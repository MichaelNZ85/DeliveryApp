using System;
using Foundation;
using UIKit;
using System.Linq;
using DeliveryApp.Model;

namespace DeliveryApp.iOS
{
    public partial class ViewController : UIViewController
    {

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            signInButton.TouchUpInside += SignInButton_TouchUpInside;

        }

        private async void SignInButton_TouchUpInside(object sender, EventArgs e)
        {
            var email = emailTextField.Text;
            var password = passwordTextField.Text;
            UIAlertController alert = null;

            var result = await DeliveryUser.Login(email, password);

            if(result)
            {
                alert = UIAlertController.Create("Success", "Welcome to Big Purrrrrrrrrs", UIAlertControllerStyle.Alert);
            }
            else
            {
                alert = UIAlertController.Create("You have FAILED!", "Ur password is FAIL! Entry are denied!", UIAlertControllerStyle.Alert);
            }
            alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            PresentViewController(alert, true, null);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if(segue.Identifier == "registerSegue")
            {
                var destinationViewContoller = segue.DestinationViewController as RegoViewController;
                destinationViewContoller.emailAddress = emailTextField.Text;
            }
        }



        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		

        }
    }
}