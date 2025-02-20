using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Models.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.CafeMenu.Queries.GetAllCafeMenusQuery;
public sealed record GetAllCafeMenusQueryRequest() : IRequest<ApiResponse<List<CafeMenuDto>>>;

