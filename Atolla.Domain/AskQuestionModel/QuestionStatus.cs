using System;
using System.Collections.Generic;
using System.Text;

namespace Atolla.Domain.General
{
    public class QuestionStatus
    {
        public int AppealNo { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
        public string Answer { get; set; }
    }
}
