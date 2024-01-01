using Atolla.Core.BaseRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atolla.Domain.General
{
    [Table("CUSTOMER_INFORMATION")]
    public class CustomerInformation : AuditableEntity<long>
    {
        [Column("UNVAN")]
        [Required]
        public string Unvan { get; set; }
        [Column("AD_SOYAD")]
        [Required]
        public string AdSoyad { get; set; }
        [Column("TCKN_VKN")]
        [Required]
        public string TCKN_VKN { get; set; }
        [Column("TELEFON")]
        [Required]
        public string Telefon { get; set; }
        [Column("EPOSTA")]
        [Required]
        public string EPosta { get; set; }
        [Column("IL")]
        [Required]
        public string Il { get; set; }
        [Column("ILCE")]
        [Required]
        public string Ilce { get; set; }
        [Column("KURULU_GUC")]
        public decimal KuruluGuc { get; set; }
        [Column("NOMINAL_DEGER")]
        public string NominalDeger { get; set; }
        [Column("MAHSUPLASMA_TURU")]
        public string MahsuplasmaTuru { get; set; }
        [Column("TARIFE_TURU")]
        public string TarifeTuru { get; set; }
        [Column("TERIM_BILGISI")]
        public string TerimBilgisi { get; set; }
        [Column("KAYNAK_TURU")]
        public string KaynakTuru { get; set; }
        [DataType(DataType.Date)]
        [Column("GECICI_KABUL_TURU")]
        public DateTime GeciciKabulTarihi { get; set; }
        [Column("ODEME_SEKLI")]
        public string OdemeSekli { get; set; }
        [Column("BOLGE")]
        public string Bolge { get; set; }

    }
}
