using CandidateTracker.Data;
using CandidateTracker.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CandidateTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly string _connection;

        public CandidatesController(IConfiguration config)
        {
            _connection = config.GetConnectionString("ConStr");
        }

        [HttpGet("getpendingcount")]
        public int GetPendingCount()
        {
            var repo = new CandidateRepository(_connection);
            return repo.GetPendingCount();
        }

        [HttpGet("getacceptedcount")]
        public int GetAcceptedCount()
        {
            var repo = new CandidateRepository(_connection);
            return repo.GetAcceptedCount();
        }

        [HttpGet("getdeclinedcount")]
        public int GetDeclinedCount()
        {
            var repo = new CandidateRepository(_connection);
            return repo.GetDeclinedCount();
        }

        [HttpPost("addpending")]
        public void AddPending(Candidate candidate)
        {
            var repo = new CandidateRepository(_connection);
            repo.AddPending(candidate);
        }

        [HttpPost("updateaccepted")]
        public void UpdateAccepted(UpdateVM vm)
        {
            var repo = new CandidateRepository(_connection);
            repo.UpdateAccepted(vm.Id);
        }

        [HttpPost("updatediclined")]
        public void Updatedeclined(UpdateVM vm)
        {
            var repo = new CandidateRepository(_connection);
            repo.UpdateDeclined(vm.Id);
        }
    }
}
