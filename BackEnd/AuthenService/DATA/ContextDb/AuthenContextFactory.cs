using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DATA.ContextDb
{
     public class AuthenContextFactory : IDesignTimeDbContextFactory<AuthenContext>
    {
        public AuthenContext CreateDbContext(string[] args)
        {
            // Build config to read appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Make sure this points to the folder with appsettings.json
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AuthenContext>();

            var connectionString = configuration.GetConnectionString("AuthenContext");


            builder.UseSqlServer(connectionString);

            return new AuthenContext(builder.Options);
        }
    }
}
