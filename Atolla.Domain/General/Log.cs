using Atolla.Core.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atolla.Domain.General
{
    [Table("LOG")]
    public class Log : AuditableEntity<long>
    {
        [Column("SERVICE_NAME")]
        [MaxLength(100)]
        public string ServiceName { get; set; }
        [Column("METHOD_NAME")]
        [MaxLength(100)]
        public string MethodName { get; set; }
        [Column("REQUEST_DATA")]
        [MaxLength()]
        public string RequestData { get; set; }
        [Column("RESPONSE_DATA")]
        [MaxLength()]
        public string ResponceData { get; set; }
        [Column("REQUEST_DATE")]
        public DateTime RequestDate { get; set; }
        [Column("RESPONSE_DATE")]
        public DateTime ResponseDate { get; set; }
        [Column("PROCESS_TIME")]
        public int ProcessTime { get; set; }
    }
}
