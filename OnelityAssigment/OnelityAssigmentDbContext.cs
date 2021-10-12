using Microsoft.EntityFrameworkCore;
using OnelityAssigment.Models;

namespace OnelityAssigment
{
    public class OnelityAssigmentDbContext : DbContext
    {
        public OnelityAssigmentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Conference> Conference { get; set; }
        public DbSet<Participant> Participant { get; set; }
    }
}
