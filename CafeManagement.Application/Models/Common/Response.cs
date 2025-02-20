using CafeManagement.Application.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Models.Common;
public class Response : IResponse
{
    public bool Success { get; set; }

    public int StatusCode { get; set; }

    public string Message { get; set; } = string.Empty;
}

