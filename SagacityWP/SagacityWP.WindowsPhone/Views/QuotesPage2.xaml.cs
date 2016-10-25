using Parse;
using SagacityWP.Models;
using SagacityWP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class QuotesPage2 : Page
    {
        List<Citations> lst;

        public QuotesPage2()
        {
            this.InitializeComponent();

            lst = new List<Citations>();
            getQuotes();


        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        private void lstImpaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SharedInformation.sharedQuotes = lstImpaire.SelectedItem as Citations;

            Frame.Navigate(typeof(QuoteDetail2));
        }

        //private void lstPaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private async Task getQuotes()
        {
            LoadingBar.IsEnabled = true;
            LoadingBar.Visibility = Visibility.Visible;

            try
            {

                var query = ParseObject.GetQuery("Quotes");
                var count = await query.CountAsync();

                //  query.Limit(20);
                IEnumerable<ParseObject> results = await query.FindAsync();

                int i = 0;

                foreach (ParseObject result in results)
                {
                    string idParse = result.ObjectId;
                    var applicantResumeFile = result.Get<ParseFile>("image");
                    //string url = await new HttpClient().GetStringAsync(applicantResumeFile.Url);

                    string content = result.Get<string>("content");
                    string categories = result.Get<string>("category");
                    //string idParse = result.Get<string>("objectId");
                    System.Diagnostics.Debug.WriteLine("********* nom : " + content);
                    System.Diagnostics.Debug.WriteLine("-------URL : ------- " + result.Get<ParseFile>("image").Url);
                    Uri Imagepath = result.Get<ParseFile>("image").Url;
                    var bitmap = new BitmapImage(result.Get<ParseFile>("image").Url);
                    float rate = result.Get<float>("rate");
                    // lst.Add(new Citations() { IdParse = idParse, Id = i, Text = content, Description = description, Image = bitmap });
                    lst.Add(new Citations() { Id = i, Rate = rate, Text = content, Categorie = categories, Image = bitmap, Imagepath = Imagepath });

                    i++;
                }

                LoadingBar.IsEnabled = false;
                LoadingBar.Visibility = Visibility.Collapsed;

                lstImpaire.DataContext = lst;


                // lstImpaire.DataContext = lst.Where(e => e.Id % 2 == 0);
                // lstPaire.DataContext = lst.Where(e => e.Id % 2 != 0);
            }
            catch (ParseException e)
            {
                if (e.Code == ParseException.ErrorCode.ObjectNotFound)
                {
                    // Uh oh, we couldn't find the object!
                }
                else
                {
                    // Some other error occurred
                }
            }

        }

    }
}
