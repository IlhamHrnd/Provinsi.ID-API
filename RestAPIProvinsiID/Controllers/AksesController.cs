using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIProvinsiID.Data;
using RestAPIProvinsiID.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RestAPIProvinsiID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AksesController : ControllerBase
    {
        private readonly Datacontext _datacontext;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public AksesController(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<AksesModel>>> GetAllAkses()
        {
            var _ok = new OkResult();
            var result = new AksesResult
            {
                Code = _ok.StatusCode,
                Message = _ok.GetType().Name,
                userModels = await _datacontext.Akses.ToListAsync()
            };

            string jsonString = JsonSerializer.Serialize(result, options);

            return Ok(jsonString);
        }
    }
}
