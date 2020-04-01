using System.Collections.Generic;
using System.Threading.Tasks;
using E_Learning_API.Application.Utility;
using E_Learning_API.Application.ViewModels;
using E_Learning_API.Models;

namespace E_Learning_API.Application.Interfaces
{
    public interface ISystemManagementService
    {
        Task<List<TB_EL_System_Role>> GetAllSystemRole();

        Task<PagedResult<SystemRoleViewModel>> GetAllSystemRolePaging(int page, int pageSize);

        void AddSystemRole(TB_EL_System_Role systemRole);

        void DeleteSystemRole(TB_EL_System_Role systemRole);

        Task<bool> SaveAll();

        Task<TB_EL_System_Role> GetSystemRole(long sid);
        
        Task<List<TB_EB_DOMAIN>> GetAllFactory();

        Task<bool> CheckExistUser(string account);

        Task<bool> CheckDuplicateSystemRole(string account);

        Task<object> GetNameAndDetpByAccount(string account);
    }
}