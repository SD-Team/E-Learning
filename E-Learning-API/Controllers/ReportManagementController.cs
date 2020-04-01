using System;
using System.Diagnostics;
using System.Threading.Tasks;
using E_Learning_API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    public class ReportManagementController : ApiController
    {
        private readonly IReportManagementService _reportManagementService;
        public ReportManagementController(IReportManagementService reportManagementService)
        {
            _reportManagementService = reportManagementService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllViewRecord()
        {
            var data = await _reportManagementService.GetAllViewRecord();
            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllViewRecordPaging(int page, int pageSize, string startDate, string endDate, bool detailOrSummary)
        {
            if (detailOrSummary == true) 
            {
                var data = await _reportManagementService.GetAllViewRecordPaging(page, pageSize, startDate, endDate);
                return Ok(data);
            }
            else 
            {
                var data = await _reportManagementService.GetAllViewRecordSummaryPaging(page, pageSize, startDate, endDate);
                return Ok(data);
            }
            
        }
    }
}