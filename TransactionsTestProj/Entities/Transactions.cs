using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TransactionsTestProj.Entities
{
    [Table("Transaction", Schema = "dbo")]
    public class Transactions
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string PaymentCurrencyCode { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
