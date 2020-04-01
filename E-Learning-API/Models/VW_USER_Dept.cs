using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Learning_API.Models
{
    public partial class VW_USER_Dept
    {
        [Column(Order = 0)]
        [StringLength(50)]
        public string USER_GUID { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string ACCOUNT { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string NAME { get; set; }

        [Column(Order = 3)]
        [StringLength(255)]
        public string OPTION1 { get; set; }

        [StringLength(50)]
        public string DOMAIN { get; set; }

        [StringLength(50)]
        public string GROUP_NAME { get; set; }
    }
}