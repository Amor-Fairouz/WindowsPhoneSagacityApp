using SagacityWP.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SagacityWP.ViewModel
{
    public class DataBaseController
    {
        public static void createTable()
        {
            using (var connection = new SQLiteConnection("Sagacity.db"))
            {
                using (var statement = connection.Prepare(@"CREATE TABLE IF NOT EXISTS Favoris (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL ,
                                                Content NVARCHAR(50),
                                                Author NVARCHAR(50),
                                                Image NVARCHUAR(50));"))
                {
                    statement.Step();
                }
            }
        }

        public static void insertData(string param1, string param2, string param3)
        {
            try
            {
                using (var connection = new SQLiteConnection("Sagacity.db"))
                {
                    using (var statement = connection.Prepare(@"INSERT INTO Favoris (Content,Author,Image)
                                            VALUES(?, ?,?);"))
                    {
                        statement.Bind(1, param1);
                        statement.Bind(2, param2);
                        statement.Bind(3, param3);

                        // Inserts data.
                        statement.Step();


                        statement.Reset();
                        statement.ClearBindings();


                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception\n" + ex.ToString());
            }
        }


        public static ObservableCollection<Favoris> getValues()
        {
            ObservableCollection<Favoris> list = new ObservableCollection<Favoris>();

            using (var connection = new SQLiteConnection("Sagacity.db"))
            {
                using (var statement = connection.Prepare(@"SELECT * FROM Favoris;"))
                {

                    while (statement.Step() == SQLiteResult.ROW)
                    {
                        var uri = statement[3].ToString();
                      //  var bitmap = new BitmapImage(new Uri(uri));

                       var bitmap = new BitmapImage(new Uri("ms-appx:///Assets/Authors/a-milne.jpg"));
                       Debug.WriteLine(statement[0] + " ---" + statement[1] + " ---" + statement[2] + "------------" + statement[3]);

                        list.Add(new Favoris()
                        {
                            Id = int.Parse(statement[0].ToString()),
                            Content = (string)statement[1],
                            Author = statement[2].ToString(),
                            Image = bitmap
                        });

                      //  Debug.WriteLine(statement[0] + " ---" + statement[1] + " ---" + statement[2] + "------------" + statement[3]);
                    }
                }
            }
            return list;
        }


        public static void delete(int id)
        {
            using (var connection = new SQLiteConnection("Sagacity.db"))
            {
                using (var statement = connection.Prepare(@"DELETE FROM Favoris WHERE ID=?"))
                {

                    statement.Bind(1, id);
                    statement.Step();
                }
                //  getValues();
            }
        }

    }
}
