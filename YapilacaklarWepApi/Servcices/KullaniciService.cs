using System.Data.Entity;
using System.Linq;
using YapilacaklarWebApi.Contexts;
using YapilacaklarWebApi.Entities;
using YapilacaklarWebApi.Models;
using YapilacaklarWebApi.Servcices.Bases;

namespace YapilacaklarWebApi.Servcices
{
    public class KullaniciService :IKullaniciService
    {
        private readonly DbContext _db;
        public KullaniciService(DbContext db) // dependency constructor injection
        {
            _db = db;
        }
        public IQueryable<KullaniciModel> GetQuery()
        {
            return _db.Set<Kullanici>().Where(k=>k.IsDeleted  == false).Select(k => new KullaniciModel()
            {
                Id = k.Id,
                KullaniciAdi = k.KullaniciAdi,
                Sifre = k.Sifre,
                Adi = k.Adi,
                Soyadi = k.Soyadi,
                CreateDate = k.CreateDate,
                CreatedBy = k.CreatedBy,
                UpdateDate = k.UpdateDate,
                UpdatedBy = k.UpdatedBy
            });

        }
    }
}