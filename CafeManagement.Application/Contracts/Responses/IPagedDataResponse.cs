using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Contracts.Responses;
public interface IPagedDataResponse<T> : IResponse
{
    List<T> Data { get; }
    List<string> Messages { get; }
    int CurrentPage { get; }
    int PageSize { get; }
    int TotalPages { get; }
    int TotalCount { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
}