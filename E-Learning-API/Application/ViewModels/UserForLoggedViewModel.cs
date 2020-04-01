using System.Collections.Generic;
using E_Learning_API.Models;

namespace E_Learning_API.Application.ViewModels
{
    public class UserForLoggedViewModel
    {
        public string USER_GUID { get; set; }
        public string ACCOUNT { get; set; }
        public string NAME { get; set; }
        public string OPTION1 { get; set; }
        public string DOMAIN { get; set; }
        public string GROUP_NAME { get; set; }
    }
}