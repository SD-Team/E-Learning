using System;

namespace E_Learning_API.Application.Utility
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }

        public int PageCount
        {
            get
            {
                double pageCount = RowCount / (double)PageSize;
                return (int)Math.Ceiling(pageCount);
            }
            set
            {
                PageCount = value;
            }
        }

        public int PageSize { get; set; }

        public int RowCount { get; set; }

        public int FirstRowOnPage
        {
            get
            {
                return (CurrentPage - 1) * PageSize + 1;
            }
        }

        public int LastRowOnPage
        {
            get
            {
                return Math.Min(CurrentPage * PageSize, RowCount);
            }
        }
    }
}