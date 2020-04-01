using System.Collections.Generic;
using System.Threading.Tasks;
using E_Learning_API.Application.Interfaces;
using E_Learning_API.Data.Interfaces;
using E_Learning_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_API.Application.Implementation
{
    public class HomeService : IHomeService
    {
        DbContext db;
        private readonly IRepositoryVideo<TB_EL_Video, long> _repositoryTB_EL_Video;
        private readonly IRepositoryVideo<TB_EL_View_Record, long> _reporitoryTB_EL_View_Record;
        public HomeService(IRepositoryVideo<TB_EL_Video, long> repositoryTB_EL_Video,
            IRepositoryVideo<TB_EL_View_Record, long> reporitoryTB_EL_View_Record)
        {
            _repositoryTB_EL_Video = repositoryTB_EL_Video;
            _reporitoryTB_EL_View_Record = reporitoryTB_EL_View_Record;
        }

        public async Task<List<TB_EL_Video>> GetAllVideoByDept(string type)
        {
            var a = type.ToLower();
            var data = await _repositoryTB_EL_Video.FindAll(x => x.Type.Trim().ToUpper() == type.Trim().ToUpper()).ToListAsync();
            return data;
        }

        public async Task<List<TB_EL_Video>> GetAllVideo()
        {
            var data = await _repositoryTB_EL_Video.FindAll().ToListAsync();
            return data;
        }

        public async Task<TB_EL_Video> GetVideo(long sid)
        {
            var data = await _repositoryTB_EL_Video.FindSingle(x => x.SID == sid);
            return data;
        }

        public async Task<bool> SaveViewRecord(TB_EL_View_Record viewRecord)
        {
            _reporitoryTB_EL_View_Record.Add(viewRecord);
            return await _reporitoryTB_EL_View_Record.SaveAll();
        }
    }
}