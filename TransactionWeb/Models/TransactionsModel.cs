using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionWeb.Models
{
    public class TransactionsModel
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentCurrencyCode { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Status { get; set; }
    }

}
