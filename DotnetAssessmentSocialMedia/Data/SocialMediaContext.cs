using DotnetAssessmentSocialMedia.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssessmentSocialMedia.Data
{
    public class SocialMediaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        
        public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
            : base(options) 
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>()
                .HasAlternateKey(c => c.Username);
        }
    }
}