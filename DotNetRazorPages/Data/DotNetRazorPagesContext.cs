using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotNetRazorPages.Models
{
    public class DotNetRazorPagesContext : DbContext
    {
        public DotNetRazorPagesContext (DbContextOptions<DotNetRazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetRazorPages.Models.Movie> Movie { get; set; }
    }
}
