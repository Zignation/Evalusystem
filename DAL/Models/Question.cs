using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Models
{
    public class Question
    {
        [Key]
        public int question_id { get; set; }

        public int questionnaire_id { get; set; }

        public string description { get; set; }

        public List<QuestionOption> questionOptions
        {
            get
            {
                using (var db = new EvalContext())
                {
                    var getQuestionsOptions = db.Question_Option.Where(x => x.question_id == question_id);
                    if (!getQuestionsOptions.Any()) return null;

                    return getQuestionsOptions.ToList();
                }
            }
            set { }
        }
    }
}
