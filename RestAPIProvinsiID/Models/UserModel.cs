using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestAPIProvinsiID.Models
{
    public class UserModel
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Akses { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AksesModel? GetAkses { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Status { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StatusModel? GetStatus { get; set; }
    }

    public class UserResult
    {
        public int Code { get; set;}
        public string Message { get; set;} = string.Empty;
        public List<UserModel>? userModels { get; set; }
    }
}
