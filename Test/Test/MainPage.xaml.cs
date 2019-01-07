using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace Test
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UIElement_OnDragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Move;
        }
        private void objectManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var stackDragged = e.OriginalSource as StackPanel;
            (stackDragged.RenderTransform as TranslateTransform).X += e.Delta.Translation.X;
            (stackDragged.RenderTransform as TranslateTransform).Y += e.Delta.Translation.Y;
        }

        private async void UIElement_OnDrop(object sender, DragEventArgs e)
        {
            if ((e.AcceptedOperation & DataPackageOperation.Move) != 0)
            {

            }
            Image1.Source = Image.Source;
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Count > 0)
                {
                    var storageFile = items[0] as StorageFile;
                    var bitmapImage = new BitmapImage();
                    bitmapImage.SetSource(await storageFile.OpenAsync(FileAccessMode.Read));
                    Image.Source = bitmapImage;
                }
            }
            else
            {
                ContentDialog wrongCredentialsDialog = new ContentDialog
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
