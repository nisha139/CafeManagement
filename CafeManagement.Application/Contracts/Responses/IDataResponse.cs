using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Contracts.Responses;
public interface IDataResponse<T> : IResponse
{
    T Data { get; }
    List<string> Messages { get; }
}
