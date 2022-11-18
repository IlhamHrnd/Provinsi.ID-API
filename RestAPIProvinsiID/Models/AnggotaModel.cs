using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestAPIProvinsiID.Models
{
    public class AnggotaModel
    {
        [Key]
        public int ID { get; set; }
        public string NamaAnggota { get; set; } = string.Empty;
        public int JenisKelamin { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public GenderModel? GetGender { get; set; }
        public string Provinsi { get; set; } = string.Empty;
        public string Kabupaten { get; set; } = string.Empty;
        public string Kecamatan { get; set; } = string.Empty;
        public string Kelurahan { get; set; } = string.Empty;
        public string Telepon { get; set; } = string.Empty;
        public int Pekerjaan { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PekerjaanModel? GetPekerjaan { get; set; }
        public double TanggalDaftar { get; set; }
        public string TempatLahir { get; set; } = string.Empty;
        public DateTime TanggalLahir { get; set; }
        public string Username { get; set; } = string.Empty;
    }

    public class AnggotaResult
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<AnggotaModel>? anggotaModels { get; set; }
    }
}
