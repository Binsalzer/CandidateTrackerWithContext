using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.Data
{
    public class CandidateRepository
    {
        private readonly string _connection;

        public CandidateRepository(string connection)
        {
            _connection = connection;
        }

        public int GetPendingCount()
        {
            return GetAllPending().Count();
        }

        public List<Candidate> GetAllPending()
        {
            var context = new CandidateTrackerDataContext(_connection);
            return context.Candidates.Where(c => c.Status == Status.Pending).ToList();
        }

        public int GetAcceptedCount()
        {
            return GetAllAccepted().Count();
        }

        public List<Candidate> GetAllAccepted()
        {
            var context = new CandidateTrackerDataContext(_connection);
            return context.Candidates.Where(c => c.Status == Status.Accepted).ToList();
        }

        public int GetDeclinedCount()
        {
            return GetAllDeclined().Count();
        }

        public List<Candidate> GetAllDeclined()
        {
            var context = new CandidateTrackerDataContext(_connection);
            return context.Candidates.Where(c => c.Status == Status.Declined).ToList();
        }

        public void AddPending(Candidate candidate)
        {
            var context = new CandidateTrackerDataContext(_connection);
            context.Candidates.Add(candidate);
            context.SaveChanges();
        }

        public void UpdateAccepted(int id)
        {
            var context = new CandidateTrackerDataContext(_connection);
            var candidate = context.Candidates.FirstOrDefault(c => c.Id == id);
            candidate.Status = Status.Accepted;
            context.SaveChanges();
        }

        public void UpdateDeclined(int id)
        {
            var context = new CandidateTrackerDataContext(_connection);
            var candidate = context.Candidates.FirstOrDefault(c => c.Id == id);
            candidate.Status = Status.Declined;
            context.SaveChanges();
        }
    }
}
