using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionWeb.Entities;

namespace TransactionWeb.Interfaces
{
    public interface ITransactionServices
    {
        Transactions GetAllTransactionsInfo(string currency,string status);

    }
}
