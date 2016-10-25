using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagacityWP.Models
{
 public   class ScoreModel
    {
        public int Score { get; set; }
        public DateTime DateSaved { get; set; }

        public ScoreModel() { }

        public ScoreModel(int Score, DateTime DateSaved) {
            this.DateSaved = DateSaved;
            this.Score = Score;
        }


    }
}
