using CafeManagement.Application.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Models.Common;
public class PagedApiResponse<T>(int count, int page, int pageSize) : ApiResponse<List<T>>, IPagedDataResponse<T>
{
    public int CurrentPage { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
    public int TotalPages { get; set; } = (int)Math.Ceiling(count / (double)pageSize);
    public int TotalCount { get; set; } = count;
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;

    // Additional properties from ApiResponse class
}

