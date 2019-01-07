using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Test
{
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var userN = UserN.Text;
            var passW = PassW.Password;

            if (userN == "1234" && passW == "1234")
            {
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                ContentDialog wrongCredentialsDialog = new ContentDialog
                {
                    Title = "Error",
                    Content = "Username or Password invalid",
                    CloseButtonText = "Ok"
                };
                ContentDialogResult res = await wrongCredentialsDialog.ShowAsync();
            }
        }
    }
}
