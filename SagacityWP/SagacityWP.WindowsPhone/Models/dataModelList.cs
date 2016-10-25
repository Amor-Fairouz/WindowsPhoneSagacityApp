using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagacityWP.Models
{
  public  class dataModelList
    {
        public int ID { get; set; }
        public string Question { get; set; }

        public dataModelList() { }
        public dataModelList(int ID, string Question) {
            this.ID = ID;
            this.Question = Question;  
    }
   public static void Quest()
        {
            List<dataModelList> data = new List<dataModelList>();
            data.Add(new dataModelList( 0, "I wake up early in the morning and cannot go back to sleep."));
            data.Add(new dataModelList(1, "I am more irritable than usual."));
            data.Add(new dataModelList(2, "I get tired for no reason."));
            data.Add(new dataModelList(3, "I have lost interest in things."));
            data.Add(new dataModelList(4, "I feel anxious when I go out of the house alone."));
            data.Add(new dataModelList(5, "I get off to sleep easily without using medication."));
            data.Add(new dataModelList(6, "I am restless and can't keep still."));
            data.Add(new dataModelList(7, "I still enjoy the things I used to."));
            data.Add(new dataModelList(8, "I have crying spells, or feel like it."));
            data.Add(new dataModelList(9, "I get very frightened or panicky feeling for no good reason at all."));
            data.Add(new dataModelList(10, "I find it easy to do the things I used to do."));
            data.Add(new dataModelList(11, "I feel miserable and sad")); 
        }
    }
}
