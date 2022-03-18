using AutoMapper;
using GNB.Bussiness.Application.DTOs.DTO;
using GNB.Bussiness.BD.Core;
using GNB.Bussiness.BD.DataAcces;
using GNB.Bussiness.BD.Domain;
using GNB.Bussinsess.Utils.Utils;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.BussinessAplication.TransactionService
{
    public class TransactionService : ItransactionService
    {
        TransactionsDao transactionsDao;
        FilesOffline FilesOffline;
        public TransactionService() { 
        transactionsDao= new TransactionsDao();
            FilesOffline = new FilesOffline();
        }
        public List<ConversionsDTO> GetConversions()
        {
            try
            {
                LogManager.Write("TransactionService.GetConversions() START:");
                if (!TransactionsDao.getIsconection())
                    return FilesOffline.getFileConversions();
                return Mapper.Map<List<ConversionsDTO>>(transactionsDao.GetConversions());
            }
            catch (Exception ex)
            {
                LogManager.Write("TransactionService.GetConversions() ERROR:" + ex.Message);
                return new List<ConversionsDTO>();
            }
        }

        public List<TransactionsDTO> GetTransactions()
        {
            try
            {
                LogManager.Write("TransactionService.GetTransactions() START:");
                if (!TransactionsDao.getIsconection())
                    return FilesOffline.getFileTransactions();
                return Mapper.Map<List<TransactionsDTO>>(transactionsDao.GetTransactions());
            }
            catch (Exception ex)
            {
                LogManager.Write("TransactionService.GetTransactions() ERROR:" + ex.Message);
                return new List<TransactionsDTO>();
            }
        }

        public TransactionsSumsDTO GetTransactionsBySku(string sku)
        {
            try
            {
                string DefaultCurrency = ConfigurationManager.AppSettings["DefaultCurrency"];
                LogManager.Write("TransactionService.GetTransactionsBySku() START:");

                TransactionsSumsDTO result = new TransactionsSumsDTO();
                List<TransactionsDTO> listTransactions = new List<TransactionsDTO>();
                List<ConversionsDTO> listConversions = GetConversions();

                listTransactions = Mapper.Map<List<TransactionsDTO>>(transactionsDao.GetTransactionsBySku(sku));
                result.ListTransactions.AddRange(listTransactions.Where(t => t.currency.ToLower().Trim().Equals(DefaultCurrency.ToLower().Trim())));

                var directConversion = listConversions.Where(c => c.to.ToLower().Trim().Equals(DefaultCurrency.ToLower().Trim())).Select(c => c.from).ToList();
                List<TransactionsDTO> listDirectConversion = listTransactions.Where(t => !t.currency.ToLower().Trim().Equals(DefaultCurrency.ToLower().Trim()) && directConversion.Contains(t.currency)).ToList();
                if (listDirectConversion != null && listDirectConversion.Count > 0)
                {
                    foreach (TransactionsDTO tdto in listDirectConversion)
                    {
                        double amount = listConversions.Where(c => c.from.ToLower().Trim().Equals(tdto.currency.ToLower().Trim()) && c.to.ToLower().Trim().Equals(DefaultCurrency.ToLower().Trim())).Select(c => c.amount).FirstOrDefault();
                        TransactionsDTO transaction = new TransactionsDTO();
                        transaction.currency = DefaultCurrency;
                        transaction.amount = Math.Round(tdto.amount * amount, 2);
                        transaction.sku = sku;
                        result.ListTransactions.Add(transaction);
                    }
                }

                List<TransactionsDTO> listInDirectConversion= listTransactions.Where(t => !t.currency.ToLower().Trim().Equals(DefaultCurrency.ToLower().Trim()) && !directConversion.Contains(t.currency)).ToList();
                if (listInDirectConversion != null && listInDirectConversion.Count > 0) {
                    foreach (TransactionsDTO tdto in listInDirectConversion.ToList())
                    {                        
                        while (!tdto.currency.ToLower().Trim().Equals(DefaultCurrency.ToLower().Trim()))
                        {
                            List<ConversionsDTO> conversion = listConversions.Where(c => c.from.ToLower().Trim().Equals(tdto.currency.ToLower().Trim())).ToList();
                            if (conversion != null && conversion.Count>0)
                            {
                                bool isDefaultCurrency = conversion.Exists(c => c.to.ToLower().Trim().Equals(DefaultCurrency.ToLower().Trim()));
                                ConversionsDTO conversionData = isDefaultCurrency ? conversion.FirstOrDefault(c => c.to.ToLower().Trim().Equals(DefaultCurrency.ToLower().Trim())) : conversion.FirstOrDefault();
                                tdto.currency = conversionData.to;
                                tdto.amount = Math.Round(tdto.amount*conversionData.amount,2 );
                            }
                            else {
                                break;
                            }

                        }                       
                        result.ListTransactions.Add(tdto);

                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                LogManager.Write("TransactionService.GetTransactionsBySku() ERROR:" + ex.Message);
                return new TransactionsSumsDTO();
            }

        }
 }
}
