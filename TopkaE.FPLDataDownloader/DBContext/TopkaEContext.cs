using Microsoft.EntityFrameworkCore;
using TopkaE.FPLDataDownloader.Models.InputModels;
using TopkaE.FPLDataDownloader.Models.InputModels.LeagueDataModel;

namespace TopkaE.FPLDataDownloader.DBContext
{
    public class TopkaEContext : DbContext
    {
        public TopkaEContext(DbContextOptions<TopkaEContext> options)
            : base(options)
        {
        }
        public DbSet<Element> Elements { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        //public DbSet<PlayerSummary> PlayersSummary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.Use
        }
    }
}
