using SagacityWP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Facebook;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Activation;
using Parse;
using Windows.Storage.Pickers;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SagacityWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuoteDetails : Page
    {

        Uri x;
        BitmapImage imageshare;
        public QuoteDetails()
        {
            this.InitializeComponent();
            
        imageshare =   SharedInformation.sharedQuotes.Image;
            quoteImage.Source = imageshare;
      //  quote.Text = SharedInformation.sharedQuotes.Text;
      x = SharedInformation.sharedQuotes.Imagepath;
            quoteImage.DataContext = x;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            DataTransferManager.GetForCurrentView().DataRequested += dtManager_DataRequested;

        }
        
        private async void dtManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
        


            var deferral = args.Request.GetDeferral();
            args.Request.Data.Properties.Title = "Sagacity";
            args.Request.Data.SetWebLink(x);
            deferral.Complete();





        }

        private async Task show()
        {
            var content = SharedInformation.sharedQuotes.Text;
            var img = SharedInformation.sharedQuotes.Image;
            //var content = SharedInformation.sharedQuotes;

            DataBaseController.insertData(content, "jlilç", "k_k__");
            MessageDialog msg = new MessageDialog("Added Successfully");
            await msg.ShowAsync();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            show();
        }
        public string ImagePath { get; set; }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationCacheMode = NavigationCacheMode.Disabled;

            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }

        private void shareFb_buttonClick(object sender, RoutedEventArgs e)
        {

            /* DataTransferManager dtmanager = DataTransferManager.GetForCurrentView();
             dtmanager.DataRequested += dtManager_DataRequested;

             DataTransferManager.ShowShareUI();*/
            DataTransferManager.ShowShareUI();

      
           



    }
    }
}
