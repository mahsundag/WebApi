using Atolla.Core.BaseRepository;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atolla.Domain.General
{
    [Table("GROUP")]
    public class Group : AuditableEntity<int>
    {
        [Column("GROUP_CODE")]
        public string GroupCode { get; set; }
        [Column("GROUP_NAME")]
        public string GroupName { get; set; }
        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}
