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
        Candidate UpdateCandidate(Candidate candidate);
        bool DeleteCandidate(int candidateId);
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

        public Candidate UpdateCandidate(Candidate candidate)
        {
            var existingCandidate = _context.Candidates.SingleOrDefault(c => c.CandidateId == candidate.CandidateId);
            if (existingCandidate != null)
            {
                // Update properties individually
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.Email = candidate.Email;
                existingCandidate.ResumeFile = candidate.ResumeFile;
                existingCandidate.ApplicationDate = candidate.ApplicationDate;

                _context.SaveChanges();
            }
            return existingCandidate;
        }

        public bool DeleteCandidate(int candidateId)
        {
            var candidate = _context.Candidates.Find(candidateId);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
