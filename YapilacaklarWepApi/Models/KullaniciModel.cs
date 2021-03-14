using System.ComponentModel.DataAnnotations;
using YapilacaklarWebApi.Records.Bases;

namespace YapilacaklarWebApi.Models
{
    public class KullaniciModel :RecordBase
    {
        [Required]
        [StringLength(32)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(16)]
        public string Sifre { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }
    }
}