using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using YapilacaklarWebApi.Contexts;
using YapilacaklarWebApi.Models;
using YapilacaklarWebApi.Servcices;
using YapilacaklarWebApi.Servcices.Bases;

namespace YapilacaklarWebApi.Controllers
{
    [Authorize]
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
                if (model == null)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception exc)
            {

                return BadRequest();
            }
        }
        //[Httppost]
        // /api/Kullanici
        public IHttpActionResult Post(KullaniciModel model)
        {
            try
            {
                model.CreatedBy = User.Identity.Name;
                if (ModelState.IsValid)
                {
                    _kullaniciService.Add(model);
                    return Ok();
                }
                return BadRequest();

            }
            catch (Exception exc)
            {
                return InternalServerError();
            }
        }
        public IHttpActionResult Put(KullaniciModel model)
        {
            try
            {
                model.UpdatedBy = User.Identity.Name;
                if (ModelState.IsValid)
                {
                    _kullaniciService.Update(model);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception exc)
            {

                return InternalServerError();
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                string updatedBy = User.Identity.Name;
                _kullaniciService.Delete(id, updatedBy);
                return Ok(id);
            }
            catch (Exception exc)
            {
                return InternalServerError();
            }
        }
    }
}
