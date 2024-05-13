﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTracker.Data
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public Status Status { get; set; }
    }


    public enum Status
    {
        Pending,
        Declined,
        Accepted
    }
}