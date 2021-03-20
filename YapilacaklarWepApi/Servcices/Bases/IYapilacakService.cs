using System.Linq;
using YapilacaklarWepApi.Models;

namespace YapilacaklarWepApi.Servcices.Bases
{
    public interface IYapilacakService
    {
        IQueryable<YapilacakModel> GetQuery();
    }
}