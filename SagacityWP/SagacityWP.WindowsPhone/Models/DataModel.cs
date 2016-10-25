using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagacityWP.Models
{
   public class DataModel
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string CorrectAnswer { get; set; }

        public DataModel() { }
        public DataModel(string Question, string Answer1, string Answer2, string Answer3, string CorrectAnswer)
        {
           
            this.Answer1 = Answer1;
            this.Answer2 = Answer2;
            this.CorrectAnswer = CorrectAnswer;
            this.Answer3 = Answer3;
            this.Question = Question;
          
        }
  
        public DataModel(int ID,string Question, string Answer1, string Answer2, string Answer3, string CorrectAnswer)
        {
            this.ID = ID;
            this.Answer1 = Answer1;
            this.Answer2 = Answer2;
            this.CorrectAnswer = CorrectAnswer;
            this.Answer3 = Answer3;
            this.Question = Question;

        }

        public override string ToString()
        {
            return "ID: " + ID + "   Question: " + Question + "   Answer1: " + Answer1 + "   Answer2: " + Answer2 + "   Answer3: " + Answer3 + "   CorrectAnswer: " + CorrectAnswer;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            DataModel objAsPart = obj as DataModel;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public bool Equals(DataModel other)
        {
            if (other == null) return false;
            return (this.ID.Equals(other.ID));
        }


    }
}
