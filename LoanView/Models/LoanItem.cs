using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanView.Models
{
    public class LoanItem
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string LoanStatus { get; set; }
        public int currentStage { get; set; }

    }
}
