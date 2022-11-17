using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestAPIProvinsiID.Models
{
    public class AksesModel
    {
        [Key]
        public int ID { get; set; }
        public string Level { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public UserModel? GetUser { get; set; }
    }

    public class AksesResult
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<AksesModel>? userModels { get; set; }
    }
}
