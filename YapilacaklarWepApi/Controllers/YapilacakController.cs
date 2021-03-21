using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using YapilacaklarWebApi.Contexts;
using YapilacaklarWepApi.Models;
using YapilacaklarWepApi.Servcices;
using YapilacaklarWepApi.Servcices.Bases;

namespace YapilacaklarWepApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Yapilacaklar")]
    public class YapilacakController : ApiController
    {
        private readonly DbContext _db;
        private readonly IYapilacakService _yapilacakService;

        public YapilacakController()
        {
            _db = new YapilacaklarContext();
            _yapilacakService = new YapilacakService(_db);
        }
        // api/Yapilacaklar/Getir
        [Route("Getir")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Listele()
        {
            try
            {
                var model = _yapilacakService.GetQuery().ToList();
                return Ok(model);
            }
            catch (Exception exc)
            {

                return BadRequest();
            }
        }
        // api/Yapilacak/Getir/7
        //[Route("Getir/{yapilacakId}")] //1
        [Route("Getir/{yapilacakId}")] //2
        [HttpGet]
        [AllowAnonymous]
        //public IHttpActionResult Getir(int? yapilacakId)
        public IHttpActionResult Getir(int yapilacakId) //2
        {
            try
            {
                var model = _yapilacakService.GetQuery().SingleOrDefault(y => y.Id == yapilacakId);
                if (model == null)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception exc)
            {

                return BadRequest();
            }
        }

        [Route("Getir/{tarih1}/{tarih2}")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Getir(DateTime tarih1, DateTime tarih2)
        {
            try
            {
                var model = _yapilacakService.GetQuery().Where(y => y.Tarih >= tarih1 && y.Tarih <= tarih2).ToList();
                if (model == null || model.Count == 0)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception exc)
            {

                return BadRequest();
            }
        }
        //api/Yapilacaklar/tariheGoreGetir
        [Route("TariheGoreGetir")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult GetirByTarih(YapilacaklarFilterModel tarihler)
        {
            try
            {
                var model = _yapilacakService.GetQuery().Where(y => y.Tarih >= tarihler.Tarih1 && y.Tarih <= tarihler.Tarih2).ToList();
                if (model == null || model.Count == 0)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception exc)
            {

                return BadRequest();
            }
        }
        // /api/Yapilacaklar/Ekle
        [Route("Ekle")]
        [HttpPost]
        public IHttpActionResult YapilacakEkle(YapilacakModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = User.Identity.Name;
                    _yapilacakService.Add(model);
                    return Ok(model);
                }
                return BadRequest();
            }
            catch (Exception exc)
            {

                return InternalServerError();
            }
        }
        // /api/Yapilacaklar/Guncelle
        [Route("Guncele")]
        [HttpPut]
        public IHttpActionResult YapilacakGuncelle(YapilacakModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = User.Identity.Name;
                    _yapilacakService.Update(model);
                    return Ok(model);
                }
                return BadRequest();
            }
            catch (Exception exc)
            {

                return InternalServerError();
            }
        }
        // /api/Yapilacaklar/Sil/8
        [Route("Sil/{yapilacakId}")]
        [HttpDelete]
        public IHttpActionResult YapilacakSil(int yapilacakId)
        {
            try
            {
                _yapilacakService.Delete(yapilacakId, User.Identity.Name);
                return Ok(yapilacakId);
            }
            catch (Exception exc)
            {

                return InternalServerError();
            }
        }

    }
}
