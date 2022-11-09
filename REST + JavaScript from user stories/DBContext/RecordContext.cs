using Microsoft.EntityFrameworkCore;
using REST___JavaScript_from_user_stories.Models;
using System.Security.Claims;

namespace REST___JavaScript_from_user_stories.DBContext
{
    public class RecordContext : DbContext
    { 
        public RecordContext(DbContextOptions<RecordContext> options) : base(options) { }

        public DbSet<Record> Records { get; set; }

    }
}
