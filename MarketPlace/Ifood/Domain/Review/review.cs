using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ifood.Domain.Review
{
    public class review
    {     
        public review() 
        {
            questions = new List<review_question>();
        }

        public string id { get; set; }
        public string createdAt { get; set; }
        public string customerName { get; set; }
        public bool discarded { get; set; }
        public bool moderated { get; set; }
        public decimal score { get; set; }
        public string surveyId { get; set; }
        public bool published { get; set; }
        public review_order order { get; set; }
        public List<review_question> questions { get; set; }
    }

    public class review_order
    {
        public string id { get; set; }
        public string createdAt { get; set; }
    }

    public class review_question
    {
        public review_question()
        {
            answers = new List<review_question_answer>();
        }

        public string id { get; set; }
        public string type { get; set; }
        public string title { get; set; }

        public List<review_question_answer> answers { get; set; }
    }

    public class review_question_answer
    {
        public string id { get; set; }        
        public string title { get; set; }
    }
}
