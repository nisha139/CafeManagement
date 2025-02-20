using CafeManagement.Application.Features.CafeMenu.Dto;
using CafeManagement.Application.Models.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Application.Features.CafeMenu.Queries.GetCafeMenuByIdQuery;
public sealed record GetCafeMenuByIdQueryRequest(Guid Id) : IRequest<ApiResponse<CafeMenuDto>>;
