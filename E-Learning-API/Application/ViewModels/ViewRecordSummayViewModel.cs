using System;

namespace E_Learning_API.Application.ViewModels
{
    public class ViewRecordSummayViewModel
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public string Work_Id { get; set; }
        public string Subject { get; set; }
        public int TotalCount { get; set; }
        public int? TotalTime { get; set; }
        public string Factory { get; set; }
        public string Dept { get; set; }
    }
}