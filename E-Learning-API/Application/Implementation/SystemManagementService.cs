using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Learning_API.Application.Interfaces;
using E_Learning_API.Application.Utility;
using E_Learning_API.Application.ViewModels;
using E_Learning_API.Data.Interfaces;
using E_Learning_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Application.Implementation
{
    public class SystemManagementService : ISystemManagementService
    {
        private readonly IRepositoryVideo<TB_EL_System_Role, long> _repositoryTB_EL_System_Role;
        private readonly IRepositoryUser<TB_EB_DOMAIN, long> _repositoryTB_EB_DOMAIN;
        private readonly IRepositoryUser<TB_EB_USER, string> _repositoryTB_EB_USER;
        private readonly DBContextUser _contextUser;
        public SystemManagementService(IRepositoryVideo<TB_EL_System_Role, long> repositoryTB_EL_System_Role,
            IRepositoryUser<TB_EB_DOMAIN, long> repositoryTB_EB_DOMAIN,
            IRepositoryUser<TB_EB_USER, string> repositoryTB_EB_USER,
            DBContextUser contextUser)
        {
            _repositoryTB_EL_System_Role = repositoryTB_EL_System_Role;
            _repositoryTB_EB_DOMAIN = repositoryTB_EB_DOMAIN;
            _repositoryTB_EB_USER = repositoryTB_EB_USER;
            _contextUser = contextUser;
        }
        public void AddSystemRole(TB_EL_System_Role systemRole)
        {
            _repositoryTB_EL_System_Role.Add(systemRole);
        }

        public void DeleteSystemRole(TB_EL_System_Role systemRole)
        {
            _repositoryTB_EL_System_Role.Remove(systemRole);
        }

        public async Task<List<TB_EL_System_Role>> GetAllSystemRole()
        {
            var data = await _repositoryTB_EL_System_Role.FindAll().ToListAsync();
            return data;
        }

        public async Task<PagedResult<SystemRoleViewModel>> GetAllSystemRolePaging(int page, int pageSize)
        {
            var query = _repositoryTB_EL_System_Role.FindAll();

            int totalRow = await query.CountAsync();

            query = query.OrderBy(x => x.Account).Skip((page - 1) * pageSize).Take(pageSize);

            var data = await query.Select(x => new SystemRoleViewModel() {
                SID = x.SID,
                Character = x.Character,
                Dept = x.Dept,
                Factory = x.Factory,
                Name = x.Name,
                Account = x.Account
            }).ToListAsync();

            var paginationSet = new PagedResult<SystemRoleViewModel>()
            {
                Result = data,
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = totalRow
            };

            return paginationSet;
        }

        public async Task<TB_EL_System_Role> GetSystemRole(long sid)
        {
            var data = await _repositoryTB_EL_System_Role.FindSingle(x => x.SID == sid);
            return data;
        }

        public async Task<bool> SaveAll()
        {
            return await _repositoryTB_EL_System_Role.SaveAll();
        } 

        public async Task<List<TB_EB_DOMAIN>> GetAllFactory()
        {
            var data = await _repositoryTB_EB_DOMAIN.FindAll().ToListAsync();
            return data;
        }

        public async Task<bool> CheckExistUser(string account)
        {
            var data = await _repositoryTB_EB_USER.FindAll(x => x.ACCOUNT.ToLower() == account.ToLower()).ToListAsync();
            if (data.Count() == 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
            
        }

        public async Task<bool> CheckDuplicateSystemRole(string account)
        {
            var data = await _repositoryTB_EL_System_Role.FindSingle(x => x.Account.ToLower() == account.ToLower());

            if (data == null)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public async Task<object> GetNameAndDetpByAccount(string account)
        {
            var accountName = await _contextUser.VW_USER_Dept.Where(x => x.ACCOUNT.ToLower() == account.ToLower()).Select(x => x.NAME).FirstOrDefaultAsync();
            var groupName = await _contextUser.VW_USER_Dept.Where(x => x.ACCOUNT.ToLower() == account.ToLower()).Select(x => x.GROUP_NAME).ToListAsync();
            var data = new {
                name = accountName,
                dept = string.Join(" - ", groupName)
            };
            return data;
        }
    }
}