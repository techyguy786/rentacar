using Microsoft.EntityFrameworkCore;

namespace vega.Persistence
{
    public class VegaDbContext : DbContext
    {
        // public VegaDbContext(string connectionString)
        //     : base(connectionString)
        // {
        //     // We're passing connection string to DbContext and DbContext use
        //     // System.Configuration.ConfigurationManager
        //     // to look into web.config (appsettings.json) to connectionStrings
        //     // element. And if it doesn't find any element of name connectionString
        //     // there. it will assume itself a connection string.
        // }

        public VegaDbContext(DbContextOptions<VegaDbContext> options)
            : base(options)
        {
            
        }
    }
}