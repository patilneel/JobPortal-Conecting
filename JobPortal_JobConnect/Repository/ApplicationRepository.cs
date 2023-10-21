
using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Models;

namespace JobPortal_JobConnect.Repository
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> GetApplications();
        Application GetApplication(int applicationId);
        void ApplyForJob(Application application);
    }

    public class ApplicationRepository : IApplicationRepository
    {
        private readonly JobPortalDbContext _context;

        public ApplicationRepository(JobPortalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Application> GetApplications()
        {
            return _context.Applications.ToList();
        }

        public Application GetApplication(int applicationId)
        {
            return _context.Applications.SingleOrDefault(app => app.ApplicationId == applicationId);
        }

        public void ApplyForJob(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();
        }
    }


}
