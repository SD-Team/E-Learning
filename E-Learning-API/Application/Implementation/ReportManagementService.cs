using System;
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
    public class ReportManagementService : IReportManagementService
    {
        private readonly IRepositoryVideo<TB_EL_View_Record, long> _repositoryTB_EL_View_Record;
        public ReportManagementService(IRepositoryVideo<TB_EL_View_Record, long>  repositoryTB_EL_View_Record)
        {
            _repositoryTB_EL_View_Record = repositoryTB_EL_View_Record;
        }
        public async Task<List<TB_EL_View_Record>> GetAllViewRecord()
        {
            var data = await _repositoryTB_EL_View_Record.FindAll().ToListAsync();

            return data;
        }

        public async Task<PagedResult<TB_EL_View_Record>> GetAllViewRecordPaging(int page, int pageSize, string startDate, string endDate)
        {
            var query = _repositoryTB_EL_View_Record.FindAll();
            DateTime t1 = Convert.ToDateTime(startDate + " 00:00:00");
            DateTime t2 = Convert.ToDateTime(endDate + " 23:59:59");

            if (startDate != null && endDate != null)
            {
                query = query.Where(x => x.Start_time >= t1 && x.End_time <= t2);
            }

            int totalRow = await query.CountAsync();

            query = query.OrderByDescending(x => x.Start_time).Skip((page - 1) * pageSize).Take(pageSize);

            var data = await query.ToListAsync();

            var paginationSet = new PagedResult<TB_EL_View_Record>()
            {
                Result = data,
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = totalRow
            };
            
            return paginationSet;
        }

        public async Task<PagedResult<ViewRecordSummayViewModel>> GetAllViewRecordSummaryPaging(int page, int pageSize, string startDate, string endDate)
        {
            var query = _repositoryTB_EL_View_Record.FindAll();
            DateTime t1 = Convert.ToDateTime(startDate + " 00:00:00");
            DateTime t2 = Convert.ToDateTime(endDate + " 23:59:59");

            if (startDate != null && endDate != null)
            {
                query = query.Where(x => x.Start_time >= t1 && x.End_time <= t2);
            }

            // var tmp = query.OrderByDescending(x => x.Start_time).GroupBy(x => new {x.Work_Id, x.Subject, x.Name, x.Account, x.Factory, x.Dept})
            //     .Select(y => new ViewRecordSummayViewModel {
            //         Work_Id = y.Key.Work_Id,
            //         Account = y.Key.Account,
            //         Name = y.Key.Name,
            //         Subject = y.Key.Subject,
            //         TotalCount = y.Count(),
            //         TotalTime = y.Sum(z => z.Total_time),
            //         Factory = y.Key.Factory,
            //         Dept = y.Key.Dept,
            //     });
            // int totalRow = tmp.Count();

            // tmp = tmp.Skip((page - 1) * pageSize).Take(pageSize);

            // var data = await tmp.ToListAsync();

            var dataQuery = await query.OrderByDescending(x => x.Start_time).ToListAsync();
            
            var tmp = dataQuery.GroupBy(x => new {x.Work_Id, x.Subject, x.Name, x.Account, x.Factory, x.Dept})
                .Select(y => new ViewRecordSummayViewModel {
                    Work_Id = y.Key.Work_Id,
                    Account = y.Key.Account,
                    Name = y.Key.Name,
                    Subject = y.Key.Subject,
                    TotalCount = y.Count(),
                    TotalTime = y.Sum(z => z.Total_time),
                    Factory = y.Key.Factory,
                    Dept = y.Key.Dept,
                });
            int totalRow = tmp.Count();

            var data = tmp.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var paginationSet = new PagedResult<ViewRecordSummayViewModel>()
            {
                Result = data,
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = totalRow
            };
            
            return paginationSet;
        }
    }
}