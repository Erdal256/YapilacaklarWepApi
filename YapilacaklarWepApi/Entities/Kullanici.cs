using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YapilacaklarWebApi.Records.Bases;

namespace YapilacaklarWebApi.Entities
{
    public class Kullanici : RecordBase
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
        public List<Yapilacak> Yapilacaklar { get; set; }
        // clasla arası ilişkiyi kurduk  her iki tabloda Id olduğu için RecordBase classın için tanımladık diğer classlara adapte ettik.
    }
}