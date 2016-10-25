using Facebook;
using SagacityWP.Models;
using SagacityWP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace SagacityWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page, IWebAuthenticationBrokerContinuable
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        readonly Uri _loginUrl;
       
        public LoginPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
           


        }

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }



        #endregion
        private void guesstclick(object sender, TappedRoutedEventArgs e)
        {
            var bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Icons/guestImage.png"));

            var fbuser = new FbUser() { FbNom = "guest", ProfilePic = bitmap };


            SharedInformtionFbUser.sharedUser = fbuser;

            Frame.Navigate(typeof(AccLoved));
        }

        FaceBookHelper ObjFBHelper = new FaceBookHelper();

        private void fbIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // ObjFBHelper.LoginAndContinue();
            ObjFBHelper.LoginAndContinue();
                popup.IsOpen = true;
            
           

        }
        FacebookClient fbclient = new FacebookClient();



        public async void ContinueWithWebAuthenticationBroker(WebAuthenticationBrokerContinuationEventArgs args)
        {
            ObjFBHelper.ContinueAuthentication(args);
            if (ObjFBHelper.AccessToken != null)
            {
                fbclient = new Facebook.FacebookClient(ObjFBHelper.AccessToken);

                //Fetch facebook UserProfile:
                dynamic result = await fbclient.GetTaskAsync("me");
                string id = result.id;
                string email = result.email;
                string FBName = result.name;

                string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", id, "square", ObjFBHelper.AccessToken);
                // picProfile.Source = new BitmapImage(new Uri(profilePictureUrl));

                var bitmap = new BitmapImage(new Uri(profilePictureUrl));
                //Format UserProfile:
                // GetUserProfilePicture(id);
                // s= FBName;
                var fbuser = new FbUser() { FbNom = FBName, ProfilePic = bitmap };

                SharedInformtionFbUser.sharedUser = fbuser;
             

                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(AccLoved));

            }
            else
            {
                var bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Icons/guestImage.png"));

                var fbuser = new FbUser() { FbNom = "guest", ProfilePic = bitmap };

                SharedInformtionFbUser.sharedUser = fbuser;


                var rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(MoodCoice));
            }

        }

        private void GetUserProfilePicture(string UserID)
        {
            //string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", UserID, "square", ObjFBHelper.AccessToken);

           //  picProfile.Source = new BitmapImage(new Uri(profilePictureUrl));
        }

       // private async void BtnFaceBookPost_Click(object sender, RoutedEventArgs e)
       // {
       //     var postParams = new
       //     {
       //         name = "Facebook Post Testing from App.",
       //         caption = "WindowsPhone 8.1 FaceBook Integration.",
       //         link = "http://bsubramanyamraju.blogspot.in",
       ////         description = TxtStatusMsg.Text,
       //         picture = "http://facebooksdk.net/assets/img/logo75x75.png"
       //     };
       //     try
       //     {
       //         dynamic fbPostTaskResult = await fbclient.PostTaskAsync("/me/feed", postParams);
       //         var responseresult = (IDictionary<string, object>)fbPostTaskResult;
       //         MessageDialog SuccessMsg = new MessageDialog("Message posted sucessfully on facebook wall");
       //         await SuccessMsg.ShowAsync();
       //     }
       //     catch (Exception ex)
       //     {
       //         //MessageDialog ErrMsg = new MessageDialog("Error Ocuured!");

       //     }
       // }
        Uri _logoutUrl;

     


        //private async void BtnFaceBookLogout_Click(object sender, RoutedEventArgs e)
        //{
        //    _logoutUrl = fbclient.GetLogoutUrl(new
        //    {
        //        next = "https://www.facebook.com/connect/login_success.html",
        //        access_token = ObjFBHelper.AccessToken
        //    });
        //    WebAuthenticationBroker.AuthenticateAndContinue(_logoutUrl);
        //   // BtnLogin.Visibility = Visibility.Visible;
        //   // BtnLogout.Visibility = Visibility.Collapsed;
        //}
    }
}
