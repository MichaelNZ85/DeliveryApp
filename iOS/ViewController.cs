using System;
using Foundation;
using UIKit;
using System.Linq;

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

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                alert = UIAlertController.Create("Incomplete", "Email and password cannot be empty", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            }
            else
            {
                    var user = (await AppDelegate.MobileService.GetTable<DeliveryUser>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                    if (user.Password == password)
                    {
                        alert = UIAlertController.Create("Success!", "Welcome to the Delivery App", UIAlertControllerStyle.Alert);
                        alert.AddAction(UIAlertAction.Create("Fair Dinkum", UIAlertActionStyle.Default, null));
                    }
                    else
                    {
                        alert = UIAlertController.Create("Bloody hell!", "You got the feckin password wrong", UIAlertControllerStyle.Alert);
                        alert.AddAction(UIAlertAction.Create("Feck Off", UIAlertActionStyle.Default, null));
                    }
                    PresentViewController(alert, true, null);
            }
            
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