using System.ComponentModel.DataAnnotations;

namespace RestAPIProvinsiID.Models
{
    public class StatusModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
