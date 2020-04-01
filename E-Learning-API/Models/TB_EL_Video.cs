using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models
{
    public partial class TB_EL_Video
    {
        [Key]
        public long SID { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        [StringLength(200)]
        public string Path { get; set; }

        [StringLength(100)]
        public string Character { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(10)]
        public string Status { get; set; }
    }
}