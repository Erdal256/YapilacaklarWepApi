using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using YapilacaklarWebApi.Contexts;
using YapilacaklarWebApi.Servcices;
using YapilacaklarWebApi.Servcices.Bases;

namespace YapilacaklarWebApi.Controllers
{
    public class KullaniciController : ApiController
    {
        private readonly DbContext _db = new YapilacaklarContext();  
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController()
        {
            _kullaniciService = new KullaniciService(_db);
        }

        // [HttpGet]
        // /api/kullanici
        public IHttpActionResult Get()
        {
            try
            {
                var model = _kullaniciService.GetQuery().ToList();
                return Ok(model); // 200: OK
            }
            catch (Exception exc)
            {
                return BadRequest(); // 404: Bad Request
            }
        
        }
        //[HttpGet]
        // /api/Kullanici

        public IHttpActionResult Get(int id)
        {
            try
            {
                var model = _kullaniciService.GetQuery().SingleOrDefault(k => k.Id == id);
                return Ok(model);
            }
            catch (Exception exc )
            {

                return BadRequest();
            }
        }
    }
}
