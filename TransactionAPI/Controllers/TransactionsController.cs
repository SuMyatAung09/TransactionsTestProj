using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionWeb.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TransactionWeb.Services;
using TransactionWeb.Interfaces;

namespace TransactionAPI.Controllers
{
    /// <summary>
    /// API within Company services
    /// </summary>
    [ApiController]
    //[Route("api/v1/[controller]")]
    public class TransactionsController : ControllerBase
    {
        #region Private Variables
        private readonly ITransactionService _transactionService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region GetAllTransactionsInfo
        /// <summary>
        /// This API is to Get the Transactions Information
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="date"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/v1/GetAllTransactions")]
        public TransactionsModel GetAllTransactionsInfo(string currency,string status)
        {
            var transactionsInfo = _transactionService.GetAllTransactionsInfo(currency, status);
            TransactionsModel tinfo = null;
            //if (transactionsInfo != null)
            //{
            //    tinfo = new TransactionsModel();
            //    tinfo.Id = transactionsInfo.Id;
            //    tinfo.Amount = transactionsInfo.Amount;
            //    tinfo.PaymentCurrencyCode = transactionsInfo.PaymentCurrencyCode;
            //    tinfo.Status = transactionsInfo.Status;

            //}
            return tinfo;

        }
        #endregion
    }
}