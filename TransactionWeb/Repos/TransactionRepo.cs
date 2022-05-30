using TransactionWeb.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionWeb.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using CsvHelper;
using System.Globalization;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using TransactionWeb.Services;

namespace TransactionWeb.Repos
{
    public class TransactionWeb : IRepository<Transactions>
    {
        #region Constructor
        DBContext Context { get; }
        ITransactionService TransactionService { get; }
        //public TransactionRepo(DBContext context)
        //{
        //    Context = context;
        //    InitializeAutoMapper();
        //}
        //public TransactionRepo(DBContext context, ITransactionService transactionService)
        //{
        //    Context = context;
        //    TransactionService = transactionService;
        //    InitializeAutoMapper();
        //}
        #endregion


        #region AutoMapper
        IMapper dtoMapper, entityMapper;
        MapperConfiguration dtoMap, entityMap;

        void InitializeAutoMapper()
        {
            entityMap = new MapperConfiguration(cfg => cfg.CreateMap<Transactions, TransactionsModel>());
            entityMapper = entityMap.CreateMapper();

            dtoMap = new MapperConfiguration(cfg => cfg.CreateMap<TransactionsModel, Transactions>());
            dtoMapper = dtoMap.CreateMapper();
        }

        public Task<Transactions> GetAsync(string index)
        {
            throw new NotImplementedException();
        }

        public Task<Transactions> GetAsync(Transactions dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Transactions dto)
        {
            throw new NotImplementedException();
        }
        #endregion



        /// <summary>
        /// GetAllTransactionsInfo
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="date"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public Transactions GetAllTransactionsInfo(string currency, string status)
        {
            string _sqlQuery = string.Empty;
                   
            _sqlQuery = @"select a.Id,a.Amount,a.PaymentCurrencyCode,
                        CASE WHEN a.Status = 'Approved' THEN 'A'
                        WHEN a.Status = 'Failed' THEN 'R'
                        WHEN a.Status = 'Finished ' THEN 'D'
                        WHEN a.Status = 'Rejected ' THEN 'R'
                        WHEN a.Status = 'Done ' THEN 'D'
                        ELSE NULL END AS Status
                        from [dbo].[Transactions] a
                        Where a.PaymentCurrencyCode=@currency and a.Status=@status";
                        
                
            using (IDbConnection dbConnection = new SqlConnection(Environment.GetEnvironmentVariable($"CONN_TransactionTestDB")))
            {
                dbConnection.Open();
                var results = dbConnection.QueryMultiple(_sqlQuery, new
                {
                    @currency = currency,
                    @status = status
                });
                var transaction = results.ReadSingle<Transactions>();
                return transaction;
            }
        }

        public Task<RepoResult> UploadAsync()
        {
            throw new NotImplementedException();
        }

        public Transactions GetAllTransactionsInfo(string currency, string date, string status)
        {
            throw new NotImplementedException();
        }
    }
}
