using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Improvement> Improvements { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
    }
}
