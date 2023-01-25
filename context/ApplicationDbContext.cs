using Microsoft.EntityFrameworkCore;

namespace ShippeeAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users  { get; set; }
        public DbSet<Company> Companies  { get; set; } 
        public DbSet<Naf_Section> Naf_Sections  { get; set; } 
        public DbSet<Naf_Division> Naf_Divisions  { get; set; } 
        public DbSet<Skill> Skills  { get; set; } 
        public DbSet<Student_skill> Student_skills { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_skill>()
                .HasKey(cs => new { cs.Userid, cs.Skillid });
        }
    }
}