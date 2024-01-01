using Atolla.Core.Caching;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atolla.Core.BaseRepository
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class BaseEntity
    {
        public object Id { get; set; }
    }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        [Column("ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }
       
    }

    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }
        DateTime UpdatedDate { get; set; }

        string UpdatedBy { get; set; }
    }


    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity
    {
        [Column("CREATE_DATE")]
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [Column("CREATE_BY")]
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }
        [Column("UPDATE_DATE")]
        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }
        [Column("UPDATE_BY")]
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
        [Column("ROW_STATUS")]
        [ScaffoldColumn(false)]
        public RowStatus RowStatus { get; set; }
    }

    public enum RowStatus : short
    {
        Passive = 0,
        Active = 1,
        Deleted = 2,
        Approval = 3
    }
}
