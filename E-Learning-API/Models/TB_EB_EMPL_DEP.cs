using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_API.Models
{
    public partial class TB_EB_EMPL_DEP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string USER_GUID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string GROUP_ID { get; set; }

        [StringLength(50)]
        public string TITLE_ID { get; set; }

        public int? ORDERS { get; set; }
    }
}