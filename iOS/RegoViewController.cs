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
        }
    }
}