using CafeManagement.Application.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Models.Common;
public class ApiResponse<T> : Response, IDataResponse<T>
{
    public T Data { get; set; }

    public List<string> Messages { get; set; } = new List<string>();
    public IDictionary<string, object>? Metadata { get; set; } = new Dictionary<string, object>();
}