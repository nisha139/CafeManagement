﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Models.Specification.Filters;
public class BaseFilter
{
    /// <summary>
    /// Column Wise Search is Supported.
    /// </summary>
    public Search? AdvancedSearch { get; set; }

    /// <summary>
    /// Keyword to Search in All the available columns of the Resource.
    /// </summary>
    public string? Keyword { get; set; }

    /// <summary>
    /// Advanced column filtering with logical operators and query operators is supported.
    /// </summary>
    public Filter? AdvancedFilter { get; set; }
}

