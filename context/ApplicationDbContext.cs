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
        public DbSet<Student_Skill> Student_Skills  { get; set; } 
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Annoucement_Student> Annoucement_Students { get; set; }
        public DbSet<Annoucement_Company> Annoucement_Companies { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_Skill>()
                .HasKey(x => new { x.user_id, x.skill_id });

            modelBuilder.Entity<Student_Skill>()
                .HasOne(x => x.User)
                .WithMany(x => x.skills)
                .HasForeignKey(x => x.user_id);

            modelBuilder.Entity<Student_Skill>()
                .HasOne(x => x.Skill)
                .WithMany(x => x.students)
                .HasForeignKey(x => x.skill_id);
        }
    }
}