using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.DBContext;
using System.Collections.Generic;
namespace JobPortal_JobConnect.Repository
{
    
    public interface IJobRepository
    {
        IEnumerable<JobModel> GetJobListings();
        JobModel GetJobDetails(int jobId);
        void CreateJob(JobModel job);
    }

    public class JobRepository : IJobRepository
    {
        private readonly JobPortalDbContext _context;

        public JobRepository(JobPortalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<JobModel> GetJobListings()
        {
            return _context.Jobs;
        }

        public JobModel GetJobDetails(int jobId)
        {
            return _context.Jobs.Find(jobId);
        }

        public void CreateJob(JobModel job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }
    }


}
