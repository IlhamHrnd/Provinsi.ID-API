using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestAPIProvinsiID.Models
{
    public class PekerjaanModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public AnggotaModel? GetAnggota { get; set; }
    }

    public class PekerjaanResult
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<PekerjaanModel>? pekerjaanModels { get; set; }
    }
}
