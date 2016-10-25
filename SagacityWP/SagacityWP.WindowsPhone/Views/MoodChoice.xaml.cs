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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SagacityWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoodCoice : Page
    {
        public MoodCoice()
        {
            this.InitializeComponent();
            anim.Begin(); 
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void neutreImg(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccAngry));
        }

        private void clickloved(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccLoved));

        }

        private void clickannoyed(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccAngry));

        }

        private void clickSleepy(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Accsleepy));

        }

        private void clickHappy(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccHappy));

        }

        private void clickSad(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AccSad));

        }
    }
}
