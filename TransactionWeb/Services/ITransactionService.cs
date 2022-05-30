using System.Threading.Tasks;
using TransactionWeb.Entities;

namespace TransactionWeb.Services
{
    public interface ITransactionService
    {
        Task<Transactions> GetAllTransactionsInfo(string currency, string status);
    }
}