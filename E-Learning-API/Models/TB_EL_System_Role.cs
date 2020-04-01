using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models
{
    public partial class TB_EL_System_Role
    {
        [Key]
        public long SID { get; set; }

        [StringLength(10)]
        public string Factory { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Account { get; set; }

        [StringLength(255)]
        public string Dept { get; set; }

        [StringLength(20)]
        public string Character { get; set; }
    }
}