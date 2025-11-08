using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using School_ErP.Models;

namespace School_ErP.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Master_School> Master_SchoolInfo { get; set; }

        public DbSet<Master_Classes> Tbl_MasterClass { get; set; }   

        public DbSet<Master_Section>Tbl_MasterSection { get; set; } 

        public DbSet<Master_House>Tbl_MasterHouse { get; set; }

        public DbSet<Master_Streams> Tbl_MasterStream { get; set; }

        public DbSet <Master_FeeCategory>Tbl_MasterFeeCategory { get; set; }
        public DbSet<Tbl_StRegistration> Tbl_StudentRegistration { get; set; }

        public DbSet<OldBalance> Tbl_OldBalance { get; set; }   

        public DbSet<Master_MonthFee> Tbl_MasterMonthFee { get; set; }

        public DbSet<FeeDeposite> Tbl_FeeDeposite { get; set; } 

    }
}
