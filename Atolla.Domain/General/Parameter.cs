using Atolla.Core.BaseRepository;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atolla.Domain.General
{
    [Table("PARAMETER")]
    public class Parameter : AuditableEntity<int>
    {
        [Column("GROUP_ID")]
        public int GroupId { get; set; }
        [Column("GROUP_CODE")]
        public string GroupCode { get; set; }
        [Column("PARAMETER_CODE")]
        public string ParameterCode { get; set; }
        [Column("PARAMETER_NAME")]
        public string ParameterName { get; set; }
        [Column("PARAMETER_DESCRIPTION")]
        public string ParameterDescription { get; set; }
    }
}
