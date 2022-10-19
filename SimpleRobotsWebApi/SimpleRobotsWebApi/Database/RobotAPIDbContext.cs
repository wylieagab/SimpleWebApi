using Microsoft.EntityFrameworkCore;
using SimpleRobotsWebApi.Models;

namespace SimpleRobotsWebApi.Database
{
    public class RobotAPIDbContext : DbContext
    {
        public RobotAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RobotInfo> RobotInfo { get; set; }
    }
}
