using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Repository;
using System;
using System.Collections.Generic;

namespace JobPortal_JobConnect.Services
{
    public interface IApplicationService
    {
        IEnumerable<Application> GetApplications();
        Application GetApplication(int applicationId);
        void ApplyForJob(Application application);
    }

    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public IEnumerable<Application> GetApplications()
        {
            return _applicationRepository.GetApplications();
        }

        public Application GetApplication(int applicationId)
        {
            return _applicationRepository.GetApplication(applicationId);
        }

        public void ApplyForJob(Application application)
        {
            // You can add business logic for application processing, if needed.
            _applicationRepository.ApplyForJob(application);
        }
    }


}
