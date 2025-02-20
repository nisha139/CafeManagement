using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Contracts.Responses;
public interface IResponse
{
    bool Success { get; }
    int StatusCode { get; }
    string Message { get; }
}
