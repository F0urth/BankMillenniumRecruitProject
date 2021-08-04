using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BankMillenniumRecruitProject.Data
{
    public class MillenniumDbContext : DbContext
    {
        public MillenniumDbContext(DbContextOptions options) : base(options) { }

        public DbSet<SampleItem> SampleItems { get; set; }
    }
}
