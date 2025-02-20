﻿namespace CafeManagement.Application.Features.CafeMenu.Dto;
public class CafeMenuDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
}