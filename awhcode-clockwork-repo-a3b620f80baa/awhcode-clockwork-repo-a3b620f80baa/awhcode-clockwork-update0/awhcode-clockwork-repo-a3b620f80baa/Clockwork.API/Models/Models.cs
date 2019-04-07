using System;
using Microsoft.EntityFrameworkCore;

namespace Clockwork.API.Models
{
    public class ClockworkContext : DbContext
    {
        public DbSet<CurrentTimeQuery> CurrentTimeQueries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clockwork.db");
        }
    }

    public class TimeVariety
    {
        public DateTime Time { get; set; }
        public DateTime UTCTime { get; set; }
    }

    public class CurrentTimeQuery : TimeVariety
    {
        public int CurrentTimeQueryId { get; set; }
        public string ClientIp { get; set; }
    }

    public class ClientInfoList{
        public List<CurrentTimeQuery> ClientInfo { get; set; }
    }
}
