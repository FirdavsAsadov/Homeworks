﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Application.Common.Models.Filtering
{
    public class FilterPagination : FilterModelBase
    {
        public int PageSize { get; set; } = 10;

        public int PageToken { get; set; } = 1;
    }
}
