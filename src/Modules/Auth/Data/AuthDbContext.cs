using Microsoft.EntityFrameworkCore;
using Mono.Modules.Auth.Entities;

namespace Mono.Modules.Auth.Data;

internal sealed class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {

    }

    public DbSet<User> Users => Set<User>();
}
