using System.Linq;
using System.Threading.Tasks;
using E_Learning_API.Application.Interfaces;
using E_Learning_API.Application.ViewModels;
using E_Learning_API.Data.Interfaces;
using E_Learning_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Application.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryUser<TB_EB_USER, string> _repositoryTB_EB_USER;
        private readonly IRepositoryVideo<TB_EL_System_Role, string> _repositoryTB_EL_System_Role;
        private readonly DBContextUser _contextUser;
        public AuthService(IRepositoryUser<TB_EB_USER, string> repositoryTB_EB_USER,
            DBContextUser contextUser,
            IRepositoryVideo<TB_EL_System_Role, string> repositoryTB_EL_System_Role)
        {
            _repositoryTB_EB_USER = repositoryTB_EB_USER;
            _contextUser = contextUser;
            _repositoryTB_EL_System_Role = repositoryTB_EL_System_Role;
        }

        public async Task<UserForLoggedViewModel> Login(string userName, string password)
        {
            var user = await _repositoryTB_EB_USER.FindSingle(x => x.ACCOUNT.ToLower() == userName.ToLower() && x.OPTION1 == password);

            if (user == null)
                return null;

            var GROUP_NAME = _contextUser.VW_USER_Dept.Where(x => x.USER_GUID == user.USER_GUID).Select(x => x.GROUP_NAME).ToList();

            var result = new UserForLoggedViewModel{
                GROUP_NAME = string.Join(" - ", GROUP_NAME),
                ACCOUNT = user.ACCOUNT,
                DOMAIN = user.DOMAIN,
                NAME = user.NAME,
                OPTION1 = user.OPTION1,
                USER_GUID = user.USER_GUID,
            };

            return result;
        }

        public async Task<bool> IsAdministrator(string account)
        {
            var data = await _repositoryTB_EL_System_Role.FindSingle(x => x.Account.ToLower() == account.ToLower());

            if (data != null)
            {
                if (data.Character == "Administrator")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else  
            {
                return false;
            } 
        }

        public async Task<UserForLoggedViewModel> GetUser(string account)
        {
            var user = await _repositoryTB_EB_USER.FindSingle(x => x.ACCOUNT == account);

            if (user == null)
                return null;

            var GROUP_NAME = _contextUser.VW_USER_Dept.Where(x => x.USER_GUID == user.USER_GUID).Select(x => x.GROUP_NAME).ToList();

            var result = new UserForLoggedViewModel{
                GROUP_NAME = string.Join(" - ", GROUP_NAME),
                ACCOUNT = user.ACCOUNT,
                DOMAIN = user.DOMAIN,
                NAME = user.NAME,
                OPTION1 = user.OPTION1,
                USER_GUID = user.USER_GUID,
            };

            return result;
        }
    }
}