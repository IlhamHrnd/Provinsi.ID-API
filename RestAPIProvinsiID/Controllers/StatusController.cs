using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPIProvinsiID.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RestAPIProvinsiID.Models;

namespace RestAPIProvinsiID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly Datacontext _datacontext;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public StatusController(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusModel>>> GetAllStatus()
        {
            var _ok = new OkResult();
            var result = new StatusResult
            {
                Code = _ok.StatusCode,
                Message = _ok.GetType().Name,
                statusModels = await _datacontext.Status.ToListAsync()
            };

            string jsonString = JsonSerializer.Serialize(result, options);

            return Ok(jsonString);
        }
    }
}
