using System;
using System.Data.Entity;
using System.Linq;
using YapilacaklarWebApi.Contexts;
using YapilacaklarWebApi.Entities;
using YapilacaklarWebApi.Models;
using YapilacaklarWebApi.Servcices.Bases;

namespace YapilacaklarWebApi.Servcices
{
    public class KullaniciService : IKullaniciService
    {
        private readonly DbContext _db;
        public KullaniciService(DbContext db) // dependency constructor injection
        {
            _db = db;
        }
        public IQueryable<KullaniciModel> GetQuery()
        {
            return _db.Set<Kullanici>().Where(k => k.IsDeleted == false).Select(k => new KullaniciModel()
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
        public void Add(KullaniciModel model)
        {
            model.CreateDate = DateTime.Now;
            var entity = new Kullanici()
            {
                KullaniciAdi = model.KullaniciAdi,
                Sifre = model.Sifre,
                Adi = model.Adi.Trim(),
                Soyadi = model.Soyadi.Trim(),
                CreateDate = model.CreateDate,
                CreatedBy = model.CreatedBy // işlem yapıldığı zaman girilmektedir.
            };
            _db.Set<Kullanici>().Add(entity);
            _db.SaveChanges();
            model.Id = entity.Id;
        }
        public void Update(KullaniciModel model)
        {
            model.UpdateDate = DateTime.Now;
            var entity = _db.Set<Kullanici>().Find(model.Id);
            entity.KullaniciAdi = model.KullaniciAdi;
            entity.Sifre = model.Sifre;
            entity.Adi = model.Adi.Trim();
            entity.Soyadi = model.Soyadi.Trim();
            entity.UpdateDate = model.UpdateDate;
            entity.UpdatedBy = model.UpdatedBy;
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

     

        public void Delete(int id,string updatedBy)
        {
            
                var entity = _db.Set<Kullanici>().Find(id);
                entity.IsDeleted = true;
                entity.UpdateDate = DateTime.Now;
                entity.UpdatedBy = updatedBy;
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            
        }
    }
}