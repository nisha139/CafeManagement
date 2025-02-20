using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Models.Specification.Filters;
public class Search
{
    public List<string> Fields { get; set; } = new();
    public string? Keyword { get; set; }
}
