using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionWeb.Entities;

namespace TransactionWeb.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transactions> GetAllTransactionsInfo(string currency, string status);
        
    }
}
