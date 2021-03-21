using System.Linq;
using YapilacaklarWepApi.Models;

namespace YapilacaklarWepApi.Servcices.Bases
{
    public interface IYapilacakService
    {
        IQueryable<YapilacakModel> GetQuery();
        void Add(YapilacakModel model);        
        void Update(YapilacakModel model);
        void Delete(int id, string deletedBy);
    }
}