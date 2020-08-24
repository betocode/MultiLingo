using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Infra.Persistence
{
    public class ContextFactory : IDesignTimeDbContextFactory<MultiLingoContext>
    {
        public MultiLingoContext CreateDbContext(string[] args)
        {

            // MIGRATIONS
            var connectionString = "Server=localhost;Database=MultiLingo;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<MultiLingoContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new MultiLingoContext(optionsBuilder.Options);
        }
    }
}
