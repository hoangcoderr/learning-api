using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPIApp.Models;

namespace MyWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        public static List<NguoiDung> nguoiDungs = new List<NguoiDung>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(nguoiDungs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var nguoiDung = nguoiDungs.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (nguoiDung == null)
                {
                    return NotFound();
                }
                return Ok(nguoiDung);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(NguoiDungVM nguoiDungVM)
        {
            NguoiDung nguoiDung = new NguoiDung
            {
                Id = Guid.NewGuid(),
                Ten = nguoiDungVM.Ten,
                Email = nguoiDungVM.Email,
                MatKhau = nguoiDungVM.MatKhau
            };
            nguoiDungs.Add(nguoiDung);
            return Ok( new
            {
                Success = true, Data = nguoiDung
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, NguoiDungVM nguoiDungVM)
        {
            try
            {
                var nguoiDung = nguoiDungs.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (nguoiDung == null)
                {
                    return NotFound();
                }
                if (id != nguoiDung.Id.ToString())
                {
                    return BadRequest();
                }
                nguoiDung.Ten = nguoiDungVM.Ten;
                nguoiDung.Email = nguoiDungVM.Email;
                nguoiDung.MatKhau = nguoiDungVM.MatKhau;
                return Ok(new
                {
                    Success = true, Data = nguoiDung
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var nguoiDung = nguoiDungs.SingleOrDefault(x => x.Id == Guid.Parse(id));
                if (nguoiDung == null)
                {
                    return NotFound();
                }
                if (id != nguoiDung.Id.ToString())
                {
                    return BadRequest();
                }
                nguoiDungs.Remove(nguoiDung);
                return Ok(new
                {
                    Success = true, Data = nguoiDung
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
