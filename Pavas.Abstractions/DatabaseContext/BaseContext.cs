using Microsoft.EntityFrameworkCore;
using Pavas.Abstractions.DatabaseContext.Models;

namespace Pavas.Abstractions.DatabaseContext;

public abstract class BaseContext : DbContext
{
    protected BaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Sequence> Sequences { get; set; }
}