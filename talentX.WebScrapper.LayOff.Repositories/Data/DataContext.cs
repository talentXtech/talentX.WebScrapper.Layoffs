using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal;
using System.Xml;
using talentX.WebScrapper.LayOff.Entities;

namespace talentX.WebScrapper.LayOff.Repositories.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ScrapOutputData> ScrapOutputDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("layoff");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(x => x.MigrationsHistoryTable("__EFMigrationsHistory", "layoff"));

    }
}



