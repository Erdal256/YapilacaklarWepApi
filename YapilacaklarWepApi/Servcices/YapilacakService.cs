using System.Data.Entity;
using System.Linq;
using YapilacaklarWebApi.Entities;
using YapilacaklarWepApi.Models;
using YapilacaklarWepApi.Servcices.Bases;

namespace YapilacaklarWepApi.Servcices
{
    public class YapilacakService :IYapilacakService
    {
        private readonly DbContext _db;

        public YapilacakService(DbContext db)
        {
            _db = db;
        }
        public IQueryable<YapilacakModel> GetQuery()
        {
            return _db.Set<Yapilacak>().OrderByDescending(y => y.Tarih).Where(y => !y.IsDeleted).Select(y => new YapilacakModel()
            {
                Id = y.Id,
                CreateDate = y.CreateDate,
                CreatedBy = y.CreatedBy,
                UpdateDate = y.UpdateDate,
                UpdatedBy = y.UpdatedBy,
                KullaniciId = y.KullaniciId,
                YapildiMi = y.YapildiMi,
                Tarih = y.Tarih,
                Gorev = y.Gorev
            });

        }
    }
}