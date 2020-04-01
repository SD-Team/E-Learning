using System;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models
{
    public partial class TB_EL_View_Record
    {
        [Key]
        public long SID { get; set; }

        [StringLength(20)]
        public string Account { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Work_Id { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(200)]
        public string Path { get; set; }

        public DateTime? Start_time { get; set; }

        public DateTime? End_time { get; set; }

        public int? Total_time { get; set; }

        [StringLength(50)]
        public string Factory { get; set; }

        [StringLength(255)]
        public string Dept { get; set; }
    }
}