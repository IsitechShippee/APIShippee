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
        public DbSet<Student_Skill> Student_skills { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Annoucement_Student> Annoucement_Students { get; set; }
        public DbSet<Annoucement_Company> Annoucement_Companies { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Skill>()
                .HasKey(cs => new { cs.Userid, cs.Skillid });

            modelBuilder.Entity<Qualification>()
                .HasKey(cs => new { cs.Annoucement_Companyid, cs.Skillid });
        }
    }
}