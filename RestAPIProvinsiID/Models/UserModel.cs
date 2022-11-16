using System.ComponentModel.DataAnnotations;

namespace RestAPIProvinsiID.Models
{
    public class UserModel
    {
        [Key]
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Akses { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Status { get; set; }
    }

    public class Result
    {
        public int Code { get; set;}
        public string Message { get; set;} = string.Empty;
        public List<UserModel>? userModels { get; set; }
    }
}
