using Parse;
using SagacityWP.Models;
using SagacityWP.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
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
    public sealed partial class AuthorsPage4 : Page
    {
        List<Authors> lstSource;
        public AuthorsPage4()
        {
            this.InitializeComponent();


            lstSource = new List<Authors>();


            //  HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            getAuthors();






        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
        }

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame != null && rootFrame.CanGoBack)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
        private void lstImpaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            SharedInformationAuthors.sharedAuthor = lstImpaire.SelectedItem as Authors;
            Frame.Navigate(typeof(DetailsAuthorPage));

        }

        private void lstPaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SharedInformationAuthors.sharedAuthor = lstPaire.SelectedItem as Authors;
            Frame.Navigate(typeof(DetailsAuthorPage));

        }

        private async Task getAuthors()
        {
            LoadingBar.IsEnabled = true;
            LoadingBar.Visibility = Visibility.Visible;

            try
            {
                var query = ParseObject.GetQuery("Authors");
                //query = query.Limit(10);

                IEnumerable<ParseObject> results = await query.FindAsync();

                int i = 0;

                foreach (ParseObject result in results)
                {
                    string idParse = result.ObjectId;
                    var applicantResumeFile = result.Get<ParseFile>("image");
                    string url = await new HttpClient().GetStringAsync(applicantResumeFile.Url);

                    //string url2 = result.Get<ParseFile>("image").Url;
                    string description = result.Get<string>("Description");
                    string name = result.Get<string>("Name");
                    //string idParse = result.Get<string>("objectId");
                    // System.Diagnostics.Debug.WriteLine("********* c'st l'url de l'image : " + url);
                    System.Diagnostics.Debug.WriteLine("********* nom : " + name);
                    System.Diagnostics.Debug.WriteLine("-------URL : ------- " + result.Get<ParseFile>("image").Url);

                    //Uri uri = new Uri(result.Get<ParseFile>("image").Url, UriKind.Absolute);
                    //imageContr.Sourc= new BitmapImage(result.Get<ParseFile>("image").Url);


                    var bitmap = new BitmapImage(result.Get<ParseFile>("image").Url);


                    lstSource.Add(new Authors() { IdParse = idParse, Id = i, Nom = name, Description = description, Image = bitmap });

                    i++;
                }
                LoadingBar.IsEnabled = false;
                LoadingBar.Visibility = Visibility.Collapsed;

            }
            catch (Exception e)
            {

                var bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/a-milne.jpg"));
                lstSource.Add(new Authors() { Id = 1, Nom = "A-A Milne", Description = "Novelist , Playwright , Poet ,Britsh Born on 18 January 1882 AD Died 31 January 1956 AD", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/abbie-hoffman.jpg"));
                lstSource.Add(new Authors() { Id = 2, Nom = "Abbie Hoffman", Description = "Writer, Activist, Psychologist, Speaker ,American  Born on 30 November 1936 AD Died 12 April 1989 AD", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/abraham-cowley.jpg"));
                lstSource.Add(new Authors() { Id = 3, Nom = "Abraham Cowley", Description = "Poet ,Britsh Born on 1618 AD Died 28 July 1667 AD", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/aeschylus-1.jpg"));
                lstSource.Add(new Authors() { Id = 4, Nom = "Aeschylus ", Description = "Poet ,Greek Born on 525 BC Died 456 BC", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/ahlam-mosteghanemi-5.jpg"));
                lstSource.Add(new Authors() { Id = 5, Nom = "Ahlam Mosteghanemi", Description = "Novelist ,Writer ,Algerian Born on 13 April 1953 AD", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/alan-jay-lerner-2.jpg"));
                lstSource.Add(new Authors() { Id = 6, Nom = "Alan Jay Lerner", Description = "Poet ,American Born on 31 August 1918 AD Died 31 January 1956 AD", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/alan-cumming.jpg"));
                lstSource.Add(new Authors() { Id = 7, Nom = "Alan Cumming", Description = "Actors, Theater Personalities, Non-Fiction Writers ,Scottish Born on 27 January 1965 AD ", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/alexander-graham-bell.jpg"));
                lstSource.Add(new Authors() { Id = 8, Nom = "Alexander Graham Bell", Description = "Electrical Engineers, Electronics Entrepreneurs, Scientists ,Britsh Born on 03 March 1847 AD Died 02 August 1922 AD", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/bill-gates.jpg"));
                lstSource.Add(new Authors() { Id = 9, Nom = "Bill Gates", Description = "Computer Engineers, IT & Software Entrepreneurs, Born on 28 October 1955 AD ", Image = bitmap });

                bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/albert-einstein-2.jpg"));
                lstSource.Add(new Authors() { Id = 10, Nom = "Albert Einstein", Description = "Physicists, German Born on 14 March 1879 AD Died 18 April 1955 AD", Image = bitmap });

                LoadingBar.IsEnabled = false;
                LoadingBar.Visibility = Visibility.Collapsed;

            }

            lstImpaire.DataContext = lstSource.Where(e => e.Id % 2 == 0);
            lstPaire.DataContext = lstSource.Where(e => e.Id % 2 != 0);
        }
    }
}
