using Parse;
using SagacityWP.Models;
using SagacityWP.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SagacityWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccAngry : Page
    {
        ObservableCollection<Favoris> x;
        List<Citations> lst;


        public AccAngry()
        {
            this.InitializeComponent();



            // picProfile.Source = SharedInformtionFbUser.sharedUser.ProfilePic;

            if (SharedInformtionFbUser.sharedUser.FbNom != "guest")
            {

                StckPnlProfile_Layout.Visibility = Visibility.Visible;
                TxtUserProfile.Text = SharedInformtionFbUser.sharedUser.FbNom;

                imgProfile.ImageSource = SharedInformtionFbUser.sharedUser.ProfilePic;
                //ell.Width = 64;
                //ell.Height = 64;
            }

            pagename.Text = "The harder you work, the harder it is to surrender";

            // ReadHeaders();
            //dailySuote();
        }



        public void sendToast(int timeAddedSec, string toastdescription, string toastTitle)
        {
            try
            {
                DateTime dueTime = DateTime.Now.AddMinutes(timeAddedSec);
                // Set up the notification text.
                var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
                var strings = toastXml.GetElementsByTagName("text");
                strings[0].AppendChild(toastXml.CreateTextNode(toastTitle));
                strings[1].AppendChild(toastXml.CreateTextNode(toastdescription));

                // Create the toast notification object.
                var toast = new ScheduledToastNotification(toastXml, dueTime);
                var idNumber = 5;  // Generates a unique ID number for the notification.
                toast.Id = "Toast" + idNumber;

                // Add to the schedule.
                ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
            }
            catch (Exception)
            { }





        }



        private void show(object sender, RoutedEventArgs e)
        {
            string[] strStrings = { "The harder you work, the harder it is to surrender.", "To climb steep hills requires slow pace at first.", "Be positive, patient and persistent.", "It takes the same amount of energy to worry as it does to be positive. Use your energy to believe.", "The person who says it cannot be done should not interrupt the person doing it.", "When one bases his life on principle, 99 percent of his decisions are already made.", "Our Love is infinite within the Universe as it flows between our souls.", "I am always doing that which I cannot do, in order that I may learn how to do it.", "Ignore those that make you fearful and sad, that degrade you back towards disease and death.", "Now and then it's good to pause in our pursuit of happiness and just be happy.", "The only people with whom you should try to get even are those who have helped you.", "There is no beginning and there is no end to time. There is only your perception of time. ", "It's how you deal with failure that determines how you achieve success.", "Many problems in life are because we either act without thinking, or think without acting.", "Most people would rather be certain they're miserable, than risk being happy.", "It does not matter how slowly you go as long as you do not stop.", "Nobody's a natural. You work hard to get good and then work to get better.", "Goals are not only absolutely necessary to motivate us. They are essential to really keep us alive.", "Life's a party, dress like it.", "The only person you are destined to become is the person you decide to be.", "Your love is like a secret that's been passed around.", "You can't stop the waves, but you can learn how to surf. ", "Accept that your life is going on beyond your usual understanding.", "We shall have no better conditions in the future if we are satisfied with all those which we have at present.", "To know what you do no know is the best. To pretend to know when you do not know is disease.", "Excellence is not a skill. It is an attitude.", "Change your thoughts and you change your world.", "People rarely succeed unless they have fun in what they are doing.", "Success does not consist in never making mistakes but in never making the same one a second time.", "Most people would rather be certain they're miserable, than risk being happy.", "Take a risk take an experience.", "I  don't know what my future holds, but I do know who holds my future.", "Difficult doesn't mean impossible. It simply means that you have to work hard.", "If you see no reason for giving thanks, the fault lies in yourself. ", "Choose being kind over being right and you'll be right every time.", "If you think you are so enlightened go and spend a week with your parents.", "If you go to work on your plan, your plan will go to work on you.", "You have to be absolutely dedicated to the work, you have to give everything of yourself.", "Open your arms to change, but don't let go of your values.", "Train your mind and heart to see the good in everything. There is always something to be grateful for.", "People rarely succeed unless they have fun in what they are doing.", "Only those who dare to fail greatly can ever achieve greatly.", "Life will give you a second chance. It's called 'tomorrow'.", "Patience is not the ability to wait, but how you act while you're waiting.", "You will never find time for anything. If you want the time, you must make it.", "Your mistakes in life do not define you.", "Believe you can do something and you're halfway there.", "Forgive yourself for your faults and your mistakes and move on.", "Nobody remembers the person that gave up.", "The truth is the truth regardless of who believes it.", "Everything has beauty, but not everyone can see it." };
            // Choose a random slogan
            Random RandString = new Random();
            // Display the random slogan



            pagename.Text = strStrings[RandString.Next(0, strStrings.Length)];
        }
        public void dailyQuote()
        {

        }





        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MainPivot.SelectedIndex)
            {
                case 0:
                    {
                        Select1();
                    }
                    break;
                case 1:
                    {
                        Select2();
                    }
                    break;
                case 2:
                    {
                        Select3();
                    }
                    break;

            }
        }

        private void item1_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Select1();
        }

        private void Select1()
        {
            item1.Opacity = 1;
            item2.Opacity = 0;
            item3.Opacity = 0;
            MainPivot.SelectedIndex = 0;



        }
        private void Select2()
        {


            item1.Opacity = 0;
            item2.Opacity = 1;
            item3.Opacity = 0;
            MainPivot.SelectedIndex = 1;

            x = DataBaseController.getValues();
            lstImpaire.DataContext = x;
        }

        private void item2_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Select2();

        }

        private void Select3()
        {
            item1.Opacity = 0;
            item2.Opacity = 0;
            item3.Opacity = 1;
            MainPivot.SelectedIndex = 2;
            getQuotes();

        }

        private void item3_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Select3();

        }

        private void Navigate_Authors_Page(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(AuhtorsPage2));
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string[] strStrings = { "The harder you work, the harder it is to surrender.", "To climb steep hills requires slow pace at first.", "Be positive, patient and persistent.", "It takes the same amount of energy to worry as it does to be positive. Use your energy to believe.", "The person who says it cannot be done should not interrupt the person doing it.", "When one bases his life on principle, 99 percent of his decisions are already made.", "Our Love is infinite within the Universe as it flows between our souls.", "I am always doing that which I cannot do, in order that I may learn how to do it.", "Ignore those that make you fearful and sad, that degrade you back towards disease and death.", "Now and then it's good to pause in our pursuit of happiness and just be happy.", "The only people with whom you should try to get even are those who have helped you.", "There is no beginning and there is no end to time. There is only your perception of time. ", "It's how you deal with failure that determines how you achieve success.", "Many problems in life are because we either act without thinking, or think without acting.", "Most people would rather be certain they're miserable, than risk being happy.", "It does not matter how slowly you go as long as you do not stop.", "Nobody's a natural. You work hard to get good and then work to get better.", "Goals are not only absolutely necessary to motivate us. They are essential to really keep us alive.", "Life's a party, dress like it.", "The only person you are destined to become is the person you decide to be.", "Your love is like a secret that's been passed around.", "You can't stop the waves, but you can learn how to surf. ", "Accept that your life is going on beyond your usual understanding.", "We shall have no better conditions in the future if we are satisfied with all those which we have at present.", "To know what you do no know is the best. To pretend to know when you do not know is disease.", "Excellence is not a skill. It is an attitude.", "Change your thoughts and you change your world.", "People rarely succeed unless they have fun in what they are doing.", "Success does not consist in never making mistakes but in never making the same one a second time.", "Most people would rather be certain they're miserable, than risk being happy.", "Take a risk take an experience.", "I  don't know what my future holds, but I do know who holds my future.", "Difficult doesn't mean impossible. It simply means that you have to work hard.", "If you see no reason for giving thanks, the fault lies in yourself. ", "Choose being kind over being right and you'll be right every time.", "If you think you are so enlightened go and spend a week with your parents.", "If you go to work on your plan, your plan will go to work on you.", "You have to be absolutely dedicated to the work, you have to give everything of yourself.", "Open your arms to change, but don't let go of your values.", "Train your mind and heart to see the good in everything. There is always something to be grateful for.", "People rarely succeed unless they have fun in what they are doing.", "Only those who dare to fail greatly can ever achieve greatly.", "Life will give you a second chance. It's called 'tomorrow'.", "Patience is not the ability to wait, but how you act while you're waiting.", "You will never find time for anything. If you want the time, you must make it.", "Your mistakes in life do not define you.", "Believe you can do something and you're halfway there.", "Forgive yourself for your faults and your mistakes and move on.", "Nobody remembers the person that gave up.", "The truth is the truth regardless of who believes it.", "Everything has beauty, but not everyone can see it." };
            // Choose a random slogan
            Random RandString = new Random();
            int i = RandString.Next(5, strStrings.Count() - 1);
            sendToast(2, strStrings[i], "Quote of The Day");
            Frame.Navigate(typeof(QuotesPage2));
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }




        private void lstImpaire_ItemClick(object sender, ItemClickEventArgs e)
        {

            //Favoris s = lstImpaire.SelectedItem as Favoris;
            //Debug.WriteLine("xxx==== " + s.Id);
            //DataBaseController.delete(s.Id);
            //x.Remove(s);
            Favoris s = (Favoris)e.ClickedItem;
            Debug.WriteLine("xxx==== " + s.Id);
            DataBaseController.delete(s.Id);
            x.Remove(s);

        }


        private async Task getQuotes()
        {
            LoadingBar.IsEnabled = true;
            LoadingBar.Visibility = Visibility.Visible;
            lst = new List<Citations>();
            try
            {

                var query = ParseObject.GetQuery("Quotes");
                query.OrderBy("rate");
                query.Limit(10);

                IEnumerable<ParseObject> results = await query.FindAsync();

                int i = 0;

                foreach (ParseObject result in results)
                {
                    string idParse = result.ObjectId;
                    var applicantResumeFile = result.Get<ParseFile>("image");

                    string content = result.Get<string>("content");
                    string categories = result.Get<string>("category");

                    System.Diagnostics.Debug.WriteLine("********* nom : " + content);
                    System.Diagnostics.Debug.WriteLine("-------URL : ------- " + result.Get<ParseFile>("image").Url);

                    var bitmap = new BitmapImage(result.Get<ParseFile>("image").Url);
                    float rate = result.Get<float>("rate");

                    lst.Add(new Citations() { Id = i, Rate = rate, Text = content, Categorie = categories, Image = bitmap });

                    i++;
                }

                lstQuote.DataContext = lst;

                LoadingBar.IsEnabled = false;
                LoadingBar.Visibility = Visibility.Collapsed;
                // lstImpaire.DataContext = lst.Where(e => e.Id % 2 == 0);
                // lstPaire.DataContext = lst.Where(e => e.Id % 2 != 0);
            }
            catch (Exception e)
            {

            }

        }

        private void onclickQuizz(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Quizz2));
        }

        private void onClickMood(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MoodCoice));
        }

        private void Image_Tapped_1(object sender, TappedRoutedEventArgs e)
        {

            if (!media.IsMuted)
            {
                media.Stop();
                media.IsMuted = true;


                var bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Icons/mute.png"));
                soundPic.Source = bitmap;

            }
            else
            {
                media.Play();
                media.IsMuted = false;

                var bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Icons/no_mute.png"));
                soundPic.Source = bitmap;

            }

        }
    }

}

