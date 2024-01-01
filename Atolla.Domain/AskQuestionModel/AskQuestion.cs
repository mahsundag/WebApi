using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Atolla.Domain.General
{
    public class AskQuestion
    {
        //private string _category;
        //public string Category { get { return _category; } set { _category = "ZS25"; } }
        //public string Case_Type { get; set; }
        //public int Stat_OrderNo { get; set; }
        //public string ZZFAT_TESISAT { get; set; }
        //public string Notes_Id { get; set; }
        public string TCKN { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string Notes_Value { get; set; }

    }
}
