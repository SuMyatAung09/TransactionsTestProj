using TransactionWeb.Entities;
using TransactionWeb.Repos;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Syncfusion.Blazor.Inputs;
using Syncfusion.Blazor.Inputs.Internal;
using System;
using System.Globalization;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading.Tasks;
using TransactionWeb.Interfaces;

namespace TransactionWeb.Services
{
    public class TransactionService : ITransactionService
    {
        public Transactions Me { get; private set; }
        IConfiguration Configuration { get; }

        private readonly ITransactionRepository _transactionRepository;

        TransactionRepo TransactionRepo { get; }
        public TransactionService(IMemoryCache cache, IConfiguration configuration, DBContext context)
        {
            Configuration = configuration;
            TransactionRepo = new TransactionRepo(context);
        }
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public TransactionService(Transactions transactions)
        {
            Me = transactions;
        }

        public void Set(Transactions adbanner)
        {
            throw new NotImplementedException();
        }
        async Task<Transactions> ITransactionService.GetAllTransactionsInfo(string currency,string status)
        {
            Transactions transactionsInfo = await _transactionRepository.GetAllTransactionsInfo(currency, status);
            return transactionsInfo;
        }       
    }

    internal class TransactionRepo
    {
        public TransactionRepo(DBContext context)
        {
            Context = context;
        }

        public DBContext Context { get; }
    }
}

