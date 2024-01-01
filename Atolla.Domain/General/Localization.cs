using Atolla.Core.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atolla.Domain.General
{
    [Table("LOCALIZATION")]
    public class Localization : AuditableEntity<long>
    {
        [Column("STRING_KEY")]
        [Required]
        public string StringKey { get; set; }
        [Column("LANGUAGE_CODE")]
        [Required]
        public string LanguageCode { get; set; }
        [Column("STRING_VALUE")]
        [Required]
        public string StringValue { get; set; }
    }
}
