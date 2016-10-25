using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SagacityWP.Models
{
   public class Citations
    {
        //[SQLite.PrimaryKey, SQLite.AutoIncrement]
        public string IdParse { get; set; }
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Text { get; set; }
        public Uri Imagepath { get; set; }
        public BitmapImage Image { get; set; }
       
        public int? IdAuthor { get; set; }

        public string Categorie { get; set; }

        public float Rate { get; set; }



    }
}
