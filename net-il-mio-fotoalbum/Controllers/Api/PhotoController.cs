using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using net_il_mio_fotoalbum.Areas.Identity.Data;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPhotos()
        {
            using var ctx = new PhotoContext();
            IQueryable<Photo> photos = ctx.Photos;

            return Ok(photos.ToList());
        }
    }
}
