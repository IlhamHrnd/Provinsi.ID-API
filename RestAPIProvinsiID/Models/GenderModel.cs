using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestAPIProvinsiID.Models
{
    public class GenderModel
    {
        [Key]
        public int ID { get; set; }
        public string JenisKelamin { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public AnggotaModel? GetAnggota { get; set; }
    }

    public class GenderResult
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<GenderModel>? genderModels { get; set; }
    }
}
