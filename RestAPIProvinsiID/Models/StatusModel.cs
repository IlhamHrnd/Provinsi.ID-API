using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestAPIProvinsiID.Models
{
    public class StatusModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public UserModel? GetUser { get; set; }
    }

    public class StatusResult
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<StatusModel>? statusModels { get; set; }
    }
}
