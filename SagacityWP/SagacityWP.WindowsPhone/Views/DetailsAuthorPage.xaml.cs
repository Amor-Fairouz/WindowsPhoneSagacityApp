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
using SagacityWP.ViewModel;
using Windows.UI.Xaml.Media.Imaging;
using Parse;
using SagacityWP.Models;
using System.Threading.Tasks;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SagacityWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsAuthorPage : Page
    {
        List<Citations> lst;
        List<Citations> lst1;


        public DetailsAuthorPage()
        {
            this.InitializeComponent();

            lst = new List<Citations>();
            lst1 = new List<Citations>();

           // var bitmap = new BitmapImage(new Uri());

            // imgAuth.Source = new BitmapImage(new Uri(SharedInformationAuthors.sharedAuthor.Image));
            //imgAuth.Source = SharedInformationAuthors.sharedAuthor.Image;
            nameAuth.Text = SharedInformationAuthors.sharedAuthor.Nom;
            desAuth.Text = SharedInformationAuthors.sharedAuthor.Description;
            string idParse = SharedInformationAuthors.sharedAuthor.IdParse;

            System.Diagnostics.Debug.WriteLine("********* id : " + idParse);
            img.ImageSource= SharedInformationAuthors.sharedAuthor.Image;

            // lst1.Add(new Citations() { Id = 1, Rate = 5.2f, Text = , Categorie = , Image = bitmap });

            getQuotesByAuthors(idParse);
        }

        
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
        }



        private async Task getQuotesByAuthors(string id)
        {
            LoadingBar.IsEnabled = true;
            LoadingBar.Visibility = Visibility.Visible;

            try
            {
                var query = ParseObject.GetQuery("Quotes")
                          .WhereEqualTo("idAuthor", ParseObject.CreateWithoutData("Authors", id));

                IEnumerable<ParseObject> results = await query.FindAsync();

                System.Diagnostics.Debug.WriteLine("+++++++++++++++ id : " + id);

                int i = 0;

                foreach (ParseObject result in results)
                {

                    var applicantResumeFile = result.Get<ParseFile>("image");
                    //string url = await new HttpClient().GetStringAsync(applicantResumeFile.Url);

                    //string url2 = result.Get<ParseFile>("image").Url;
                    string content = result.Get<string>("content");

                    float rate = result.Get<float>("rate");

                    string categorie = result.Get<string>("category");


                    System.Diagnostics.Debug.WriteLine("------------- Category : " + categorie);


                    // System.Diagnostics.Debug.WriteLine("********* c'st l'url de l'image : " + url);
                    //Uri uri = new Uri(result.Get<ParseFile>("image").Url, UriKind.Absolute);
                    //imageContr.Sourc= new BitmapImage(result.Get<ParseFile>("image").Url);


                    var bitmap = new BitmapImage(result.Get<ParseFile>("image").Url);


                    //lstSource.Add(new Authors() { Id = i, Nom = name, Description = description, Image = bitmap });
                    lst.Add(new Citations() { Id = i, Rate = rate, Text = content, Categorie = categorie, Image = bitmap });

                    i++;
                }
                LoadingBar.IsEnabled = false;
                LoadingBar.Visibility = Visibility.Collapsed;

                // lstImpaire.DataContext = lstSource.Where(e => e.Id % 2 == 0);
                // lstPaire.DataContext = lstSource.Where(e => e.Id % 2 != 0);
            }
            catch (Exception e)
            {
                for (int i = 1; i < 10; i++)
                {
                }
            }

            lstSource.DataContext = lst;

        }

  

        private void item1_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }

        private void item2_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }


        private void MainPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstSource_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            SharedInformation.sharedQuotes = lstSource.SelectedItem as Citations;
            Frame.Navigate(typeof(QuoteDetails));

        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationCacheMode = NavigationCacheMode.Disabled;

            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }
    }
}
