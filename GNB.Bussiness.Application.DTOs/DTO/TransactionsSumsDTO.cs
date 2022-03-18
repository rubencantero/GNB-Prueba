using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Bussiness.Application.DTOs.DTO
{
    public class TransactionsSumsDTO
    {
        public TransactionsSumsDTO() {
            ListTransactions = new List<TransactionsDTO>();
        }
        public List<TransactionsDTO> ListTransactions { get; set; }
        public double SumAmount { get { return Math.Round(ListTransactions.Sum(t => t.amount), 2); } }
    }
}
