using GNB.Bussiness.Application.DTOs.DTO;
using GNB.BussinessAplication.TransactionService;
using GNB.Bussinsess.Utils.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GNB.Bussiness.Controllers
{
    
    public class TransactionController : ApiController
    {
        [HttpGet]
        [Route("api/GetConvertions")]
        public List<ConversionsDTO> GetConversions() {
            try
            {
                LogManager.Write("TransactionController.GetConversions() START:");
                TransactionService trasactionService = new TransactionService();
                return trasactionService.GetConversions();
               // return new List<ConversionsDTO>();
            }
            catch (Exception ex)
            {
                LogManager.Write("TransactionController.GetConversions() ERROR:" + ex.Message);
                return new List<ConversionsDTO>();
            }
        }

        [HttpGet]
        [Route("api/GetTransactions")]
        public List<TransactionsDTO> GetTransactions()
        {
            try
            {
                LogManager.Write("TransactionController.GetTransactions() START:" );
                TransactionService trasactionService = new TransactionService();
                return trasactionService.GetTransactions();
            }
            catch (Exception ex)
            {
                LogManager.Write("TransactionController.GetTransactions() ERROR:" + ex.Message);
                return new List<TransactionsDTO>();
            }
        }

        [HttpGet]
        [Route("api/GetTransactionsBySku")]
        public TransactionsSumsDTO GetTransactionsBySku(string sku)
        {
            try
            {
                LogManager.Write("TransactionController.GetTransactionsBySku() START:");
                TransactionService trasactionService = new TransactionService();
                return trasactionService.GetTransactionsBySku(sku);
            }
            catch (Exception ex)
            {
                LogManager.Write("TransactionController.GetTransactionsBySku() ERROR:" + ex.Message);
                return new TransactionsSumsDTO();
            }
        }
    }
}
