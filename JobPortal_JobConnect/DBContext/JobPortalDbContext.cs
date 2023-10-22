namespace JobPortal_JobConnect.DBContext
{
    using JobPortal_JobConnect.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class JobPortalDbContext : DbContext
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobModel>().HasKey(j => j.JobId);
            modelBuilder.Entity<UserAuthModel>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasKey(j => j.UserId);
            modelBuilder.Entity<Candidate>().HasKey(j=>j.CandidateId);
            modelBuilder.Entity<Application>().HasKey(j=>j.ApplicationId);

            
        }

        public DbSet<UserAuthModel> UserAuthModels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

       
    }

}
