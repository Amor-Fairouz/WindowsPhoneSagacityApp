using SagacityWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Quizz : Page
    {
        Random rand = new Random();
        List<ScoreModel> scoreModelList = new List<ScoreModel>();
        List<DataModel> dataModelListe = new List<DataModel>();


        int number1, number2, number3, number4, score = 0, scoreToHave = 4;
        String CorrectAnswer;
        int QuestionID = 0;
        public Quizz()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            dataModelListe.Add(new DataModel
            {
                ID = 1,
                Question = "The best and most beautiful things in the world cannot be seen or even touched - they must be felt with the heart.",
                Answer1 = "Mahatma Gandhi",
                Answer2 = "William Feather",
                Answer3 = " Stephen Covey",
                CorrectAnswer = " Helen Keller"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 2,
                Question = "Try to be a rainbow in someone's cloud.",
                Answer1 = "Mark Twain",
                Answer2 = "Leonardo da Vinci",
                Answer3 = " Johann Wolfgang von Goethe",
                CorrectAnswer = "Maya Angelou"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 3,
                Question = "Believe you can and you're halfway there.",
                Answer1 = "Mark Twain",
                Answer2 = "Henry David Thoreau",
                Answer3 = " Paulo Coelho",
                CorrectAnswer = "Theodore Roosevelt"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 4,
                Question = "We know what we are, but know not what we may be.",
                Answer1 = "Anatole France",
                Answer2 = "Joseph Campbell",
                Answer3 = " Theodore Roosevelt",
                CorrectAnswer = "William Shakespeare"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 5,
                Question = " As we express our gratitude, we must never forget that the highest appreciation is not to utter words, but to live by them.",
                Answer1 = "Og Mandino",
                Answer2 = "Warren Buffett",
                Answer3 = " B. C. Forbes",
                CorrectAnswer = "John F. Kennedy"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 6,
                Question = "It is during our darkest moments that we must focus to see the light.",
                Answer1 = "Bill Parcells",
                Answer2 = "Joel Osteen",
                Answer3 = " Zig Ziglar",
                CorrectAnswer = " Aristotle Onassis"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 7,
                Question = "Change your thoughts and you change your world.",
                Answer1 = "Alexander Graham Bell",
                Answer2 = "Ambrose Bierce",
                Answer3 = " Bill Parcells",
                CorrectAnswer = " Norman Vincent Peale"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 8,
                Question = " Everyone here has the sense that right now is one of those moments when we are influencing the future.",
                Answer1 = "Bryant H. McGill",
                Answer2 = "Carl Jung",
                Answer3 = " Charles Caleb Colton",
                CorrectAnswer = " Steve Jobs"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 9,
                Question = "Even if I knew that tomorrow the world would go to pieces, I would still plant my apple tree.",
                Answer1 = "Deepak Chopra",
                Answer2 = "Ernest Hemingway",
                Answer3 = " Franklin D. Roosevelt",
                CorrectAnswer = " Martin Luther"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 10,
                Question = "Our greatest weakness lies in giving up. The most certain way to succeed is always to try just one more time.",
                Answer1 = "Harvey Mackay",
                Answer2 = "Aristotle",
                Answer3 = "James Allen",
                CorrectAnswer = "Thomas A. Edison"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 11,
                Question = "The key is to keep company only with people who uplift you, whose presence calls forth your best. ",
                Answer1 = "John Burroughs",
                Answer2 = "Ayn Rand",
                Answer3 = "Helen Keller",
                CorrectAnswer = "Epictetus"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 12,
                Question = "The secret of getting ahead is getting started. ",
                Answer1 = "Ralph Marston",
                Answer2 = "John Wooden",
                Answer3 = "Dalai Lama",
                CorrectAnswer = "Mark Twain"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 13,
                Question = "You are never too old to set another goal or to dream a new dream.",
                Answer1 = "Ralph Marston",
                Answer2 = "Maya Angelou",
                Answer3 = "Ralph Marston",
                CorrectAnswer = "C. S. Lewis"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 14,
                Question = "Always do your best. What you plant now, you will harvest later. ",
                Answer1 = "William James",
                Answer2 = "Dalai Lama",
                Answer3 = "Les Brown",
                CorrectAnswer = "Og Mandino"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 15,
                Question = "You have to learn the rules of the game. And then you have to play better than anyone else.",
                Answer1 = "Khalil Gibran",
                Answer2 = "Paulo Coelho",
                Answer3 = "Robert H. Schuller",
                CorrectAnswer = "Albert Einstein"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 16,
                Question = "Start where you are. Use what you have. Do what you can.",
                Answer1 = "Thomas Carlyle",
                Answer2 = "Dalai Lama",
                Answer3 = "Louis C. K.",
                CorrectAnswer = "Arthur Ashe"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 17,
                Question = "If you can dream it, you can do it.",
                Answer1 = "Dalai Lama",
                Answer2 = "Napoleon Bonaparte",
                Answer3 = "Ernest Hemingway",
                CorrectAnswer = "Walt Disney"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 18,
                Question = "In order to succeed, we must first believe that we can.",
                Answer1 = "Stephen Covey",
                Answer2 = "Ralph Marston",
                Answer3 = "Bo Bennett",
                CorrectAnswer = "Nikos Kazantzakis"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 19,
                Question = "A creative man is motivated by the desire to achieve, not by the desire to beat others.",
                Answer1 = "Swami Sivananda",
                Answer2 = "Ronald Reagan",
                Answer3 = "Napoleon Hill",
                CorrectAnswer = "Ayn Rand"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 20,
                Question = "Problems are not stop signs, they are guidelines. ",
                Answer1 = "Jim Rohn",
                Answer2 = "Thomas Jefferson",
                Answer3 = "Rodney King",
                CorrectAnswer = "Robert H. Schuller"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 21,
                Question = "Once I knew only darkness and stillness... my life was without past or future... but a little word from the fingers of another fell into my hand that clutched at emptiness, and my heart leaped to the rapture of living.",
                Answer1 = "Thomas Paine",
                Answer2 = "Johann Wolfgang von Goethe",
                Answer3 = "Tony Robbins",
                CorrectAnswer = "Helen Keller"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 22,
                Question = "What you get by achieving your goals is not as important as what you become by achieving your goals.",
                Answer1 = "Bill Gates",
                Answer2 = "Mother Terresa",
                Answer3 = "Mohamed Ali Klay",
                CorrectAnswer = "Henry David Thoreau"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 23,
                Question = "Even if you fall on your face, you're still moving forward. ",
                Answer1 = "Henry Ford",
                Answer2 = "Nelson Mandela",
                Answer3 = "George S. Patton",
                CorrectAnswer = "Victor Kiam"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 24,
                Question = "By failing to prepare, you are preparing to fail. ",
                Answer1 = "Maya Angelou",
                Answer2 = "Bible",
                Answer3 = "D",
                CorrectAnswer = "Benjamin Franklin"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 25,
                Question = "Be kind whenever possible. It is always possible.",
                Answer1 = "Lao Tzu",
                Answer2 = "Bill Gates",
                Answer3 = "B. F. Skinner",
                CorrectAnswer = "Dalai Lama"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 26,
                Question = "Do you want to know who you are? Don't ask. Act! Action will delineate and define you. ",
                Answer1 = "Yasmina Khadra",
                Answer2 = "Bill Cosby",
                Answer3 = "Alfred A. Montapert",
                CorrectAnswer = "Thomas Jefferson"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 27,
                Question = "Expect problems and eat them for breakfast. ",
                Answer1 = "Dwight D. Eisenhower",
                Answer2 = "Elbert Hubbard",
                Answer3 = "Bo Bennett",
                CorrectAnswer = "Alfred A. Montapert"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 28,
                Question = "Optimism is the faith that leads to achievement. Nothing can be done without hope and confidence.",
                Answer1 = "Franklin D. Roosevelt",
                Answer2 = "Martin Luther",
                Answer3 = "Bo Bennett",
                CorrectAnswer = "Helen Keller"
            });
            dataModelListe.Add(new DataModel
            {
                ID = 0,
                Question = "Do the difficult things while they are easy and do the great things while they are small. A journey of a thousand miles must begin with a single step.",
                Answer1 = "George Bernard Shaw",
                Answer2 = "Franklin D. Roosevelt",
                Answer3 = "Henry David Thoreau",
                CorrectAnswer = "Lao Tzu"
            });

            Question();

        }



        private void Question()
        {
           

            foreach (var item in dataModelListe)
            {
                if (item.ID == QuestionID)
                {
                    TextBlock_Question.Text = item.Question;
                    CorrectAnswer = item.CorrectAnswer;
                    RandomAnswerPlaces(item.Answer1, item.Answer2, item.Answer3, item.CorrectAnswer);
                }

            }
        }
        public void RandomAnswerPlaces(string Answer1, string Answer2, string Answer3, string Answer4)
        {
            String[] Answers = new string[4];
            noRepeat();
            Answers[number1] = Answer1;
            Answers[number2] = Answer2;
            Answers[number3] = Answer3;
            Answers[number4] = Answer4;
            btnAnswer1.Content = Answers[0];
            btnAnswer2.Content = Answers[1];
            btnAnswer3.Content = Answers[2];
            btnAnswer4.Content = Answers[3];
        }
        private void noRepeat()
        {
            number1 = rand.Next(0, 4);
            number2 = rand.Next(0, 4);
            number3 = rand.Next(0, 4);
            number4 = rand.Next(0, 4);
            if (number1 == number2 ||
            number1 == number3 ||
            number1 == number4 ||
            number2 == number3 ||
            number2 == number4 ||
            number3 == number4)
            {
                noRepeat();
            }
        }


        private async void Button_AnswerClick(object sender, RoutedEventArgs e)
        {
            string ClickedAnswer = ((Button)sender).Content.ToString();
            string ClickedButtonName = ((Button)sender).Name.ToString();
            switch (ClickedButtonName)
            {
                case "btnAnswer1":
                    btnAnswer1.IsEnabled = false;
                    break;
                case "btnAnswer2":
                    btnAnswer2.IsEnabled = false;
                    break;
                case "btnAnswer3":
                    btnAnswer3.IsEnabled = false;
                    break;
                case "btnAnswer4":
                    btnAnswer4.IsEnabled = false;
                    break;
                default:
                    break;
            }
            if (QuestionID == 28)

            {
                MessageDialog msgbox = new MessageDialog("Quiz Over! your percentage of khnolage is : " + score + "  ", " Sagacity");
                msgbox.Commands.Add(new UICommand { Label = "ok", Id = "0" });
                //msgbox.Commands.Add(new UICommand { Label = "Restart", Id = "1" });
                var res = await msgbox.ShowAsync();
                if (res.Id.Equals("0"))
                {


                    Frame.Navigate(typeof(AccLoved));

                    // this.Frame.Visibility = Visibility.Collapsed;
                }
                //          popupText.Text = "Quiz Over! your final score : " + score + "  ";
                SaveHighScore();
            }


            else {
                if (CorrectAnswer == ClickedAnswer)
                {
                    if (QuestionID < dataModelListe.Count()-1)
                    {
                        QuestionID++;
                    }
                    else
                    {

                        Popup codePopup = new Popup();
                        TextBlock popupText = new TextBlock();
                        popupText.Text = "Quiz Over! your final score : " + score + "  ";
                        codePopup.Child = popupText;
                        SaveHighScore();
                        //       btnAnswer4.Visibility = Visibility.Collapsed;
                    }
                    System.Diagnostics.Debug.WriteLine("+++++++++++++++ question : " + QuestionID);
                    System.Diagnostics.Debug.WriteLine("+++++++++++++++ data model : " + dataModelListe.Count());
                    score += scoreToHave;
                    scoreToHave = 5;
                    Question();
                    btnAnswer1.IsEnabled = true;
                    btnAnswer2.IsEnabled = true;
                    btnAnswer3.IsEnabled = true;
                    btnAnswer4.IsEnabled = true;
                }

                else
                {
                    scoreToHave -= 2;
                }
            }

            TextBlock_ScoreToHave.Text = string.Format("Score you can get: {0}", scoreToHave.ToString());
            TextBlock_Score.Text = string.Format("Score: {0}", score.ToString());
        }
        private void SaveHighScore()
        {


            scoreModelList.Add(new ScoreModel { Score = score, DateSaved = DateTime.Now.Date });

            IsolatedStorageHelper.SaveObject("scoreList", scoreModelList);



            var tempList =
            from item in scoreModelList
            where item.Score > 0
            orderby item.Score descending
            select string.Format("Date: {0} Score: {1}", item.DateSaved, item.Score);

            score = 0;
            scoreToHave = 5;
            QuestionID = 0;

        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
        }
    }
}
