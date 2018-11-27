using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Common
{
    public class ClientCollection : List<Customer>
    {
        public decimal TotalYTDSales() => this.Sum(x => x.YTDSales);

        public int CreditHoldCount() => this.Count(x => x.CreditHold);
    }
}
