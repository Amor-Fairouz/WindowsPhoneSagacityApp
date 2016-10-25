using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SagacityWP.Models
{
   public class Authors
    {
        //[SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Nom { get; set; }

        public string Description { get; set; }

        // public string Image { get; set; }
        public BitmapImage Image { get; set; }

        public string IdParse { get; set; }
    }
}
