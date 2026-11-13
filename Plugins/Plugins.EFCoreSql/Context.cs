using Microsoft.EntityFrameworkCore;



namespace FPYDashboard.Plugins.EFCoreSqlServer;


public class FpyDbContext : DbContext
{
    public FpyDbContext(DbContextOptions<FpyDbContext> options)
                : base(options)
    {

    }
}