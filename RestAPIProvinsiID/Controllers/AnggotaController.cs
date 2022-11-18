using Microsoft.AspNetCore.Mvc;
using RestAPIProvinsiID.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using RestAPIProvinsiID.Models;
using Microsoft.EntityFrameworkCore;

namespace RestAPIProvinsiID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnggotaController : ControllerBase
    {
        private readonly Datacontext _datacontext;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public AnggotaController(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnggotaModel>>> GetAllAnggota()
        {
            var _ok = new OkResult();
            var result = new AnggotaResult
            {
                Code = _ok.StatusCode,
                Message = _ok.GetType().Name,
                anggotaModels = await _datacontext.Anggota
                    .Include(g => g.GetGender)
                    .Include(p => p.GetPekerjaan)
                    .ToListAsync()
            };

            string jsonString = JsonSerializer.Serialize(result, options);

            return Ok(jsonString);
        }
    }
}
