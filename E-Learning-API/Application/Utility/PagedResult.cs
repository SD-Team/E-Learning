using System.Collections.Generic;

namespace E_Learning_API.Application.Utility
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public PagedResult()
        {
            Result = new List<T>();
        }
        public IList<T> Result { get; set; }
    }
}