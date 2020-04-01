using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models
{
    public partial class TB_EB_DOMAIN
    {
        [Key]
        [StringLength(50)]
        public string DOMAIN_GUID { get; set; }

        [StringLength(50)]
        public string DOMAIN_NAME { get; set; }

        [StringLength(50)]
        public string DOMAIN_NICKNAME { get; set; }

        public bool? DEFAULT_DOMAIN { get; set; }

        [StringLength(50)]
        public string FULLY_DOMAIN_NAME { get; set; }
    }
}