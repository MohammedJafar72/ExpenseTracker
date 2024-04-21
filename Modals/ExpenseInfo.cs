using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Modals
{
    internal class ExpenseInfo
    {
        public Guid ExpId { get; set; } = new Guid();
        public string? ExpName { get; set; }
        public int ExpCost { get; set; }
    }
}
