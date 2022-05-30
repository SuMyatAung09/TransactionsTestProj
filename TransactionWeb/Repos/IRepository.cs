using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionWeb.Entities;

namespace TransactionWeb.Repos
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(string index);
        Task<RepoResult> UploadAsync();
        Transactions GetAllTransactionsInfo(string currency,string status);

    }
    public record RepoResult
    {
        public int Affected { get; set; }
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
        public string Message { get; set; }
        public object Item { get; set; }

        public RepoResult(int statusCode, int affected = 0, string message = "")
        {
            StatusCode = statusCode;
            Message = message;
            Affected = affected;
        }

        public RepoResult()
        {
        }
    }

}
