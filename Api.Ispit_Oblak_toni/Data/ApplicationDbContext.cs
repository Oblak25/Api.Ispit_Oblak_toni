using Api.Ispit_Oblak_toni.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Ispit_Oblak_toni.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
