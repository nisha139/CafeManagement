using CafeManagement.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Identity;
public class CafeManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public CafeManagementIdentityDbContext(DbContextOptions<CafeManagementIdentityDbContext> options) : base(options)
    {
    }
}