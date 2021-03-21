using System;
using System.Data.Entity;
using System.Web.Http;
using YapilacaklarWebApi.Contexts;
using YapilacaklarWebApi.Servcices;
using YapilacaklarWebApi.Servcices.Bases;

namespace YapilacaklarWepApi.Controllers
{
    public class KullaniciYapilacakController : ApiController
    {
        private readonly DbContext _db;
        private readonly IKullaniciService _kullaniciService;

        public KullaniciYapilacakController()
        {
            _db = new YapilacaklarContext();
            _kullaniciService = new KullaniciService(_db);
        }
        // kulyap
        public IHttpActionResult Get()
        {
            try
            {
                var model = _kullaniciService.GetKullanicilarIncludingYapilacaklar();
                return Ok(model);
            }
            catch (Exception exc)
            {

                return BadRequest();
            }
        }
    }
}
