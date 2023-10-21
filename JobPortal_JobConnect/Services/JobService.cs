using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Repository;

namespace JobPortal_JobConnect.Services
{
    public interface IJobService
    {
        IEnumerable<JobModel> GetJobListings();
        JobModel GetJobDetails(int jobId);
        void CreateJob(JobModel job);
    }

    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public IEnumerable<JobModel> GetJobListings()
        {
            return _jobRepository.GetJobListings();
        }

        public JobModel GetJobDetails(int jobId)
        {
            return _jobRepository.GetJobDetails(jobId);
        }

        public void CreateJob(JobModel job)
        {
            // Additional business logic can be added here.
            _jobRepository.CreateJob(job);
        }
    }


}
