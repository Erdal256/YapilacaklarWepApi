using System;
using System.ComponentModel.DataAnnotations;
using YapilacaklarWebApi.Records.Bases;

namespace YapilacaklarWebApi.Entities
{
    public class Yapilacak : RecordBase
    {
        [Required]
        public string Gorev { get; set; }
        public DateTime? Tarih { get; set; }
        public bool YapildiMi { get; set; }
        public int KullaniciId { get; set; }// ıd tanımlıyorsak mullaka entity referansını mutlaka tanımlamak lazım.
        public Kullanici Kullanici { get; set; }

    }
}