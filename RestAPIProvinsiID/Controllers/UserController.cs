using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using RestAPIProvinsiID.Data;
using RestAPIProvinsiID.Models;

namespace RestAPIProvinsiID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Datacontext _datacontext;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        { 
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };

        public UserController(Datacontext datacontext)
        {
            _datacontext = datacontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUser()
        {
            var _ok = new OkResult();
            var result = new UserResult
            {
                Code = _ok.StatusCode,
                Message = _ok.GetType().Name,
                userModels = await _datacontext.User
                    .Include(u => u.GetAkses)
                    .Include(a => a.GetStatus)
                    .ToListAsync()
            };

            string jsonString = JsonSerializer.Serialize(result, options);

            return Ok(jsonString);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<UserModel>> GetUsername(string? username)
        {
            var _ok = new OkResult();
            var _notfound = new NotFoundResult();
            var user = await _datacontext.User.FindAsync(username);

            if (user == null)
            {
                var result = new UserResult
                {
                    Code = _notfound.StatusCode,
                    Message = _notfound.GetType().Name,
                    userModels = new List<UserModel>
                    {
                        new UserModel
                        {
                            Username = string.Empty,
                            Password = string.Empty,
                            Akses = 0,
                            GetAkses = new AksesModel
                            {
                                ID = 0,
                                Level = string.Empty
                            },
                            Email = string.Empty,
                            Status = 0,
                            GetStatus = new StatusModel
                            {
                                ID = 0,
                                Name = string.Empty
                            }
                        }
                    }
                };

                string jsonString = JsonSerializer.Serialize(result, options);

                return NotFound(jsonString);
            }
            else
            {
                var result = new UserResult
                {
                    Code = _ok.StatusCode,
                    Message = _ok.GetType().Name,
                    userModels = new List<UserModel>
                    {
                        new UserModel
                        {
                            Username = user.Username,
                            Password = user.Password,
                            Akses = user.Akses,
                            GetAkses = new AksesModel
                            {
                                //Data masih belum valid
                                ID = 1,
                                Level = string.Empty
                            },
                            Email = user.Email,
                            Status = user.Status,
                            GetStatus = new StatusModel
                            {
                                //Data masih belum valid
                                ID = 1,
                                Name = string.Empty
                            }
                        }
                    }
                };

                string jsonString = JsonSerializer.Serialize(result, options);

                return Ok(jsonString);
            }
        }

        /*[HttpPost]
        public async Task<ActionResult<List<UserModel>>> AddUser(UserModel userModel)
        {
            var _ok = new OkResult();
            _datacontext.User.Add(userModel);
            await _datacontext.SaveChangesAsync();

            var result = new UserResult
            {
                Code = _ok.StatusCode,
                Message = _ok.GetType().Name,
                userModels = await _datacontext.User.ToListAsync()
            };

            string jsonString = JsonSerializer.Serialize(result, options);

            return Ok(jsonString);
        }

        [HttpPut]
        public async Task<ActionResult<List<UserModel>>> UpdateUser(UserModel userModel)
        {
            var _ok = new OkResult();
            var _notfound = new NotFoundResult();
            var user = await _datacontext.User.FindAsync(userModel.Username);
            
            if (user == null)
            {
                var result = new UserResult
                {
                    Code = _notfound.StatusCode,
                    Message = _notfound.GetType().Name,
                    userModels = new List<UserModel>
                    {
                        new UserModel
                        {
                            Username = "",
                            Password = "",
                            Akses = 0,
                            Email = "",
                            Status = 0
                        }
                    }
                };

                string jsonString = JsonSerializer.Serialize(result, options);

                return NotFound(jsonString);
            }
            else
            {
                user.Password = userModel.Password;
                user.Akses = userModel.Akses;
                user.Email = userModel.Email;
                user.Status = userModel.Status;

                await _datacontext.SaveChangesAsync();

                var result = new UserResult
                {
                    Code = _ok.StatusCode,
                    Message = _ok.GetType().Name,
                    userModels = new List<UserModel>
                    {
                        new UserModel
                        {
                            Username = user.Username,
                            Password = user.Password,
                            Akses = user.Akses,
                            Email = user.Email,
                            Status = user.Status
                        }
                    }
                };

                string jsonString = JsonSerializer.Serialize(result, options);

                return Ok(jsonString);

            }
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult<List<UserModel>>> DeleteUser(string username)
        {
            var _ok = new OkResult();
            var _notfound = new NotFoundResult();
            var user = await _datacontext.User.FindAsync(username);
            
            if (user == null)
            {
                var result = new UserResult
                {
                    Code = _notfound.StatusCode,
                    Message = _notfound.GetType().Name,
                    userModels = new List<UserModel>
                    {
                        new UserModel
                        {
                            Username = "",
                            Password = "",
                            Akses = 0,
                            Email = "",
                            Status = 0
                        }
                    }
                };

                string jsonString = JsonSerializer.Serialize(result, options);

                return NotFound(jsonString);
            }
            else
            {
                _datacontext.User.Remove(user);
                await _datacontext.SaveChangesAsync();
                var result = new UserResult
                {
                    Code = _ok.StatusCode,
                    Message = _ok.GetType().Name,
                    userModels = await _datacontext.User.ToListAsync()
                };

                string jsonString = JsonSerializer.Serialize(result, options);

                return Ok(jsonString);
            }
        }*/
    }
}
