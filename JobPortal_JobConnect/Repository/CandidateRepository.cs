using System;
using System.Collections.Generic;
using System.Linq;
using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace JobPortal_JobConnect.Repository
{
    

    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetCandidates();
        Candidate GetCandidate(int candidateId);
        void CreateCandidate(Candidate candidate);
    }

    public class CandidateRepository : ICandidateRepository
    {
        private readonly JobPortalDbContext _context;

        public CandidateRepository(JobPortalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return _context.Candidates.ToList();
        }

        public Candidate GetCandidate(int candidateId)
        {
            return _context.Candidates.SingleOrDefault(candidate => candidate.CandidateId == candidateId);
        }

        public void CreateCandidate(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }
    }

}
