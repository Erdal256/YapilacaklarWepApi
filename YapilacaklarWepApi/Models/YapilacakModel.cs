using System;
using System.ComponentModel.DataAnnotations;
using YapilacaklarWebApi.Records.Bases;

namespace YapilacaklarWepApi.Models
{
    public class YapilacakModel :RecordBase
    {
        [Required]
        public string Gorev { get; set; }
        public DateTime? Tarih { get; set; }
        public bool YapildiMi { get; set; }
        public int KullaniciId { get; set; }
      

    }
}