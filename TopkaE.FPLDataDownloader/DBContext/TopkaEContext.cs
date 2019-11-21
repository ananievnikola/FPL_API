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
        public DbSet<GeneralLeagueModel> Leagues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.Use
        }
    }
}
