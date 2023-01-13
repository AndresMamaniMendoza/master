using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Model
{
    public class Debt
    {
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public bool Status { get; set; }
    }
}
