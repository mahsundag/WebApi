using Atolla.Core.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atolla.Domain.General
{
    [Table("CONFIGURATION")]
    public class Configuration:AuditableEntity<int>
    {
        [Column("CONFIGURATION_KEY")]
        [MaxLength(100)]
        [Required]
        public string ConfigurationKey { get; set; }
        [Column("CONFIGURATION_VALUE")]
        [MaxLength(1000)]
        [Required]
        public string ConfigurationValue { get; set; }
        [Column("ENVIRONMENT")]
        [MaxLength(20)]
        public string Environment { get; set; }
    }
}
