using System;

namespace Test
{
    public sealed partial class MainPage : Windows.UI.Xaml.Controls.Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void UIElement_OnDragOver(object sender, Windows.UI.Xaml.DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move;
        }
        private void objectManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            var stackDragged = e.OriginalSource as Windows.UI.Xaml.Controls.StackPanel;
            (stackDragged.RenderTransform as Windows.UI.Xaml.Media.TranslateTransform).X += e.Delta.Translation.X;
            (stackDragged.RenderTransform as Windows.UI.Xaml.Media.TranslateTransform).Y += e.Delta.Translation.Y;
        }

        private async void UIElement_OnDrop(object sender, Windows.UI.Xaml.DragEventArgs e)
        {
            if ((e.AcceptedOperation & Windows.ApplicationModel.DataTransfer.DataPackageOperation.Move) != 0)
            {

            }
            Image1.Source = Image.Source;
            if (e.DataView.Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    var storageFile = items[0] as Windows.Storage.StorageFile;
                    var bitmapImage = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmapImage.SetSource(await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read));
                    Image.Source = bitmapImage;
                }
            }
            else
            {
                Windows.UI.Xaml.Controls.ContentDialog wrongCredentialsDialog = new Windows.UI.Xaml.Controls.ContentDialog
                {
                    Title = "Info",
                    Content = "Can't copy element to this position!",
                    CloseButtonText = "Ok"
                };
                await wrongCredentialsDialog.ShowAsync();
            }
        }
    }
}
