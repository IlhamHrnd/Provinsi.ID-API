using System.ComponentModel.DataAnnotations;

namespace RestAPIProvinsiID.Models
{
    public class AksesModel
    {
        [Key]
        public int ID { get; set; }
        public string Level { get; set; } = string.Empty;
    }
}
