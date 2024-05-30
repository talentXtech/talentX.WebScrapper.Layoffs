using Microsoft.EntityFrameworkCore;
using talentX.WebScrapper.LayOff.Entities;

namespace talentX.WebScrapper.LayOff.Repositories.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ScrapOutputData> ScrapOutputDatas { get; set; }

    }

    }
