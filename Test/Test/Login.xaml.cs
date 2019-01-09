using System;

namespace Test
{
    public sealed partial class Login : Windows.UI.Xaml.Controls.Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var userN = UserN.Text;
            var passW = PassW.Password;

            if (userN == "1234" && passW == "1234")
            {
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                Windows.UI.Xaml.Controls.ContentDialog wrongCredentialsDialog = new Windows.UI.Xaml.Controls.ContentDialog
                {
                    Title = "Error",
                    Content = "Username or Password invalid",
                    CloseButtonText = "Ok"
                };
                Windows.UI.Xaml.Controls.ContentDialogResult res = await wrongCredentialsDialog.ShowAsync();
            }
        }
    }
}
