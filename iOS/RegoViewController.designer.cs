// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DeliveryApp.iOS
{
    [Register ("RegoViewController")]
    partial class RegoViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField confirmPasswordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField emailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField passwordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton regoButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (confirmPasswordTextField != null) {
                confirmPasswordTextField.Dispose ();
                confirmPasswordTextField = null;
            }

            if (emailTextField != null) {
                emailTextField.Dispose ();
                emailTextField = null;
            }

            if (passwordTextField != null) {
                passwordTextField.Dispose ();
                passwordTextField = null;
            }

            if (regoButton != null) {
                regoButton.Dispose ();
                regoButton = null;
            }
        }
    }
}