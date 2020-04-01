using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_Learning_API.Application.Utility;
using E_Learning_API.Application.ViewModels;
using E_Learning_API.Models;

namespace E_Learning_API.Application.Interfaces
{
    public interface IReportManagementService
    {
        Task<List<TB_EL_View_Record>> GetAllViewRecord();

        Task<PagedResult<TB_EL_View_Record>> GetAllViewRecordPaging(int page, int pageSize, string startDate, string endDate);

        Task<PagedResult<ViewRecordSummayViewModel>> GetAllViewRecordSummaryPaging(int page, int pageSize, string startDate, string endDate);
    }
}