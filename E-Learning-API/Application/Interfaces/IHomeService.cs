using System.Collections.Generic;
using System.Threading.Tasks;
using E_Learning_API.Models;

namespace E_Learning_API.Application.Interfaces
{
    public interface IHomeService
    {
         Task<TB_EL_Video> GetVideo(long sid);
         Task<List<TB_EL_Video>> GetAllVideoByDept(string type);
         Task<List<TB_EL_Video>> GetAllVideo();
         Task<bool> SaveViewRecord(TB_EL_View_Record viewRecord);
    }
}