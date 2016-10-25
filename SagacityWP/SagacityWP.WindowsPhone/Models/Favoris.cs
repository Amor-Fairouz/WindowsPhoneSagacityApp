using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace SagacityWP.Models
{
    public class Favoris
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public BitmapImage Image { get; set; }


    }
}
