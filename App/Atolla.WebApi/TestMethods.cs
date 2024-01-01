using Atolla.Domain.General;
using Atolla.Services.GeneralServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atolla.WebApi
{
    public static class TestMethods
    {

        public static List<AskQuestion> questions = new List<AskQuestion>();
        public static List<QuestionStatus> statuses = new List<QuestionStatus>();
        public static string AddAskQuestion(AskQuestion askQuestion)
        {
            questions.Add(askQuestion);
            return questions.Count.ToString()+" No'lu Talep Başarıyla Alınmıştır.";
        } 
        public static List<QuestionStatus> GetQuestionStatus()
        {
            
            int i = 1;
            
            foreach (var item in questions)
            {
                double kalan = i % 2;
                
                QuestionStatus questionStatus = new QuestionStatus
                {
                    Answer = item.Notes_Value,
                    AppealNo = i,
                    CreateDate = DateTime.Now,
                    Status = "Cevaplanmadı"

                };

                if (kalan == 0)
                {
                    questionStatus.Status = "Cevaplandı";
                }
                
                i++;
                bool value = false;
                foreach (var item1 in statuses)
                {
                    if (questionStatus.AppealNo==item1.AppealNo)
                    {
                        value = true;
                    }
                }
                if (!value)
                {
                    statuses.Add(questionStatus);
                }
                
            }
            
            return statuses;
        }
        public static QuestionAnswer GetAnswer(int appealNo)
        {
            QuestionAnswer questionAnswer = new QuestionAnswer();
            questionAnswer.AppealNo = appealNo;
            questionAnswer.Question = questions[appealNo - 1].Notes_Value;
            questionAnswer.Answer = "Talebiniz gerçekleşmiştir. Teşekkürler";
            return questionAnswer;
        }
    }
}
