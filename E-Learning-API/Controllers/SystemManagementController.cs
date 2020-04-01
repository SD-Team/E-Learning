using System.Threading.Tasks;
using E_Learning_API.Application.Interfaces;
using E_Learning_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    public class SystemManagementController : ApiController
    {
        private readonly ISystemManagementService _systemManagementService;
        public SystemManagementController(ISystemManagementService systemManagementService)
        {
            _systemManagementService = systemManagementService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllSystemRole()
        {
            var data = await _systemManagementService.GetAllSystemRole();
            return Ok(data);
        }

        [HttpGet("[action]/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllSystemRolePaging(int page, int pageSize)
        {
            var data = await _systemManagementService.GetAllSystemRolePaging(page, pageSize);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddSystemRole(TB_EL_System_Role systemRole)
        {
            var checkExistUser = await _systemManagementService.CheckExistUser(systemRole.Account.Trim());
            if (!checkExistUser)
            {
                return Ok(new {resultAdd = "notexistuser"});
            }
            var checkDuplicateSystemRole = await _systemManagementService.CheckDuplicateSystemRole(systemRole.Account);
            if (checkDuplicateSystemRole)
            {
                return Ok(new {resultAdd = "existsystemrole"});
            }
            _systemManagementService.AddSystemRole(systemRole);
            if (await _systemManagementService.SaveAll())
            {
                return Ok(new {resultAdd = "true"});
            }
            else 
            {
                return Ok(new {resultAdd = "false"});
            }
        }

        [HttpDelete("[action]/{sid}")]
        public async Task<bool> DeleteSystemRole(long sid)
        {
            var systemRole = await _systemManagementService.GetSystemRole(sid);
            if(systemRole == null) {
                return false;
            }
            _systemManagementService.DeleteSystemRole(systemRole);
            if (await _systemManagementService.SaveAll())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllFactory()
        {
            var data = await _systemManagementService.GetAllFactory();
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNameAndDetpByAccount(string account)
        {
            var data = await _systemManagementService.GetNameAndDetpByAccount(account);
            return Ok(data);
        }
    }
}