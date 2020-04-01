using System.Threading.Tasks;
using E_Learning_API.Application.ViewModels;
using E_Learning_API.Models;

namespace E_Learning_API.Application.Interfaces
{
    public interface IAuthService
    {
         Task<UserForLoggedViewModel> Login(string userName, string password);

         Task<bool> IsAdministrator(string account);

         Task<UserForLoggedViewModel> GetUser(string account);
    }
}