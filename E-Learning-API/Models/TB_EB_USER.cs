using System;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models
{
    public partial class TB_EB_USER
    {
        [Key]
        [StringLength(50)]
        public string USER_GUID { get; set; }

        [Required]
        [StringLength(50)]
        public string ACCOUNT { get; set; }

        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string LANG { get; set; }

        [StringLength(255)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(128)]
        public string PASSWORD { get; set; }

        public bool IS_PASSWORD_RESET { get; set; }

        public DateTimeOffset CREATE_DATE { get; set; }

        public bool IS_LOCKED_OUT { get; set; }

        public DateTimeOffset? LAST_ACTIVITY_DATE { get; set; }

        public DateTimeOffset? LAST_LOCKED_OUT_DATE { get; set; }

        public DateTimeOffset? LAST_LOGIN_DATE { get; set; }

        public DateTimeOffset? LAST_PASSWORD_CHANGE_DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string USER_TYPE { get; set; }

        public DateTimeOffset? EXPIRE_DATE { get; set; }

        [StringLength(50)]
        public string THEME { get; set; }

        [StringLength(50)]
        public string MSG_TYPE { get; set; }

        public bool? IS_AD_AUTH { get; set; }

        [StringLength(255)]
        public string EMAIL_A { get; set; }

        [StringLength(255)]
        public string EMAIL_B { get; set; }

        [StringLength(255)]
        public string EMAIL_C { get; set; }

        [StringLength(255)]
        public string EMAIL_D { get; set; }

        public int PASSWORD_INVALID_ATTEMPTS { get; set; }

        public int PW_RESET_REASON { get; set; }

        public bool? IS_USB_AUTH { get; set; }

        [StringLength(50)]
        public string USB_KEY { get; set; }

        public bool IS_SUSPENDED { get; set; }

        public DateTimeOffset? LAST_SUSPENDED_DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string SID { get; set; }

        [Required]
        [StringLength(255)]
        public string OPTION1 { get; set; }

        [Required]
        [StringLength(255)]
        public string OPTION2 { get; set; }

        [Required]
        [StringLength(255)]
        public string OPTION3 { get; set; }

        [Required]
        [StringLength(255)]
        public string OPTION4 { get; set; }

        [Required]
        [StringLength(255)]
        public string OPTION5 { get; set; }

        [Required]
        [StringLength(255)]
        public string OPTION6 { get; set; }

        [StringLength(255)]
        public string PERSONAL1 { get; set; }

        [StringLength(255)]
        public string PERSONAL2 { get; set; }

        [StringLength(255)]
        public string PERSONAL3 { get; set; }

        [StringLength(255)]
        public string PERSONAL4 { get; set; }

        [StringLength(255)]
        public string PERSONAL5 { get; set; }

        [StringLength(255)]
        public string PERSONAL6 { get; set; }

        [Required]
        [StringLength(50)]
        public string NICKNAME { get; set; }

        public int PROXY { get; set; }

        [Required]
        [StringLength(50)]
        public string CA_SERIAL_NUM { get; set; }

        [StringLength(50)]
        public string DOMAIN { get; set; }

        [StringLength(50)]
        public string ACCOUNT_MAPPING { get; set; }

        public bool? IS_UPDATE_PERSONAL_INFO { get; set; }

        public DateTimeOffset? LAST_UPDATE_PERSONAL_INFO_DATE { get; set; }

        [StringLength(50)]
        public string TIMEZONE_TEXT { get; set; }

        [StringLength(50)]
        public string LOCATION_ID { get; set; }

        [StringLength(50)]
        public string DISPLAY_TIMEZONE { get; set; }

        [StringLength(8)]
        public string COMPANY_UNIFIED_ID { get; set; }

        [StringLength(10)]
        public string COMPANY_NO { get; set; }
    }
}