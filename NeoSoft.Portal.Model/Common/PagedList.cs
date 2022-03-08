using System.Collections.Generic;

namespace NeoSoft.Portal.Model
{
    public class PagedList<T>
    {
        public PagedList()
        {
            DataList = new List<T>();
            CurrentPageIndex = 1;
            PageSize = 10;
        }

        /// <summary>
        /// Gets or sets the data list.
        /// </summary>
        /// <value>
        /// The data list.
        /// </value>
        public IList<T> DataList { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the index of the current page.
        /// </summary>
        /// <value>
        /// The index of the current page.
        /// </value>
        public int CurrentPageIndex { get; set; }

        /// <summary>
        /// Gets or sets the total records.
        /// </summary>
        /// <value>
        /// The total records.
        /// </value>
        public int? TotalRecords { get; set; }

        /// <summary>
        /// Gets or sets the sort dir.
        /// </summary>
        /// <value>
        /// The sort dir.
        /// </value>
        public string SortDir { get; set; }

        /// <summary>
        /// Gets or sets the sort by.
        /// </summary>
        /// <value>
        /// The sort by.
        /// </value>
        public string SortBy { get; set; }

    }
}
