using System.Linq;
using YapilacaklarWebApi.Models;

namespace YapilacaklarWebApi.Servcices.Bases
{
    public interface IKullaniciService
    {
        IQueryable<KullaniciModel> GetQuery();
    }
}
