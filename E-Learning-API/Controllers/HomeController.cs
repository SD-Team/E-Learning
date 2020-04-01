using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using E_Learning_API.Application.Interfaces;
using E_Learning_API.Application.ViewModels;
using E_Learning_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning_API.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService  homeService)
        {
            _homeService = homeService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllVideoByDept(string groupName)
        {
            string[] groupNames = groupName.Split('-');
            List<TB_EL_Video> initialList = new List<TB_EL_Video>();
            for (int i = 0; i < groupNames.Count(); i++)
            {
                List<TB_EL_Video> videos = await _homeService.GetAllVideoByDept(groupNames[i].Trim());
                initialList.AddRange(videos);
            }

            var data = initialList.Distinct();

            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllVideo()
        {
            var data = await _homeService.GetAllVideo();

            return Ok(data);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVideo(long sid)
        {
            var data = await _homeService.GetVideo(sid);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<bool> SaveViewRecord([FromBody]ViewRecordViewModel viewRecord)
        {
            TimeSpan TotalTimeViewVideo = Convert.ToDateTime(viewRecord.End_time) - Convert.ToDateTime(viewRecord.Start_time);
            TB_EL_View_Record view_Record = new TB_EL_View_Record{
                Account = viewRecord.Account,
                End_time = Convert.ToDateTime(viewRecord.End_time),
                Name = viewRecord.Name,
                Path = viewRecord.Path,
                SID = viewRecord.SID,
                Start_time = Convert.ToDateTime(viewRecord.Start_time),
                Subject = viewRecord.Subject,
                Work_Id = viewRecord.Work_Id,
                Total_time = Convert.ToInt32(TotalTimeViewVideo.TotalSeconds),
                Factory = viewRecord.Factory,
                Dept = viewRecord.Dept
            };
            return await _homeService.SaveViewRecord(view_Record);
        }

        [HttpGet("OpenIE")]
        public IActionResult OpenIE(string url)
        {
            ProcessStartInfo infor = new ProcessStartInfo();
            infor.FileName = @"C:\Program Files (x86)\Internet Explorer\iexplore.exe";
            infor.Arguments = url;
            Process.Start(infor);
            return Ok();
        }
    }
}