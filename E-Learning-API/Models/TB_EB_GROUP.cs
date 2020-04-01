using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models
{
    public partial class TB_EB_GROUP
    {
        [Key]
        [StringLength(50)]
        public string GROUP_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string GROUP_TYPE { get; set; }

        [StringLength(50)]
        public string GROUP_NAME { get; set; }

        [StringLength(50)]
        public string PARENT_GROUP_ID { get; set; }

        public int LFT { get; set; }

        public int RGT { get; set; }

        public int LEV { get; set; }

        [StringLength(50)]
        public string GROUP_CODE { get; set; }

        public bool? ACTIVE { get; set; }

        [StringLength(50)]
        public string COMPANY_ID { get; set; }
    }
}