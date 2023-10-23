﻿using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Repository;
using System;
using System.Collections.Generic;

namespace JobPortal_JobConnect.Services
{
    public interface ICandidateService
    {
        IEnumerable<Candidate> GetCandidates();
        Candidate GetCandidate(int candidateId);
        void CreateCandidate(Candidate candidate);
        Candidate UpdateCandidate(Candidate candidate);
        bool DeleteCandidate(int candidateId);
    }

    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return _candidateRepository.GetCandidates();
        }

        public Candidate GetCandidate(int candidateId)
        {
            return _candidateRepository.GetCandidate(candidateId);
        }

        public void CreateCandidate(Candidate candidate)
        {
            _candidateRepository.CreateCandidate(candidate);
        }

        public Candidate UpdateCandidate(Candidate candidate)
        {
            return _candidateRepository.UpdateCandidate(candidate);
        }

        public bool DeleteCandidate(int candidateId)
        {
            return _candidateRepository.DeleteCandidate(candidateId);
        }
    }
}
