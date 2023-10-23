using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobPortal_JobConnect.Repository
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> GetApplications();
        Application GetApplication(int applicationId);
        void ApplyForJob(Application application);
        void UpdateApplication(Application application);
        void DeleteApplication(int applicationId);
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

        public void UpdateApplication(Application application)
        {
            _context.Update(application);
            _context.SaveChanges();
        }

        public void DeleteApplication(int applicationId)
        {
            var application = _context.Applications.Find(applicationId);
            if (application != null)
            {
                _context.Applications.Remove(application);
                _context.SaveChanges();
            }
        }
    }
}
