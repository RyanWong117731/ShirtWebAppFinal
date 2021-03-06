using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShirtWebAppFinal.Models;

namespace ShirtWebAppFinal.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ShirtWebAppFinal.Models.ShirtModel> ShirtModel { get; set; }
    }
}
