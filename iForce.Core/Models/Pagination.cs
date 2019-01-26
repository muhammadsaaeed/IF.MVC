using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iForce.Core.Models
{
    public class Pagination
    {
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public int TotalRecords { get; set; }
    }
}