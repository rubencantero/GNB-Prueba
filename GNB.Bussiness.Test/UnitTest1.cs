using GNB.Bussiness.Application.DTOs.DTO;
using GNB.BussinessAplication.TransactionService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GNB.Bussiness.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestgetConversions()
        {
            TransactionService trasactionService = new TransactionService();
            List<ConversionsDTO> result = trasactionService.GetConversions();
            bool resultGood = true;
            if (result == null)
                resultGood = false;
            Assert.AreEqual(true, resultGood);
        }
        [TestMethod]
        public void TestgetTransactions()
        {
            TransactionService trasactionService = new TransactionService();
            List<TransactionsDTO> result = trasactionService.GetTransactions();
            bool resultGood = true;
            if (result == null)
                resultGood = false;
            Assert.AreEqual(true, resultGood);
        }
        [TestMethod]
        public void TestgetConversions(string sku)
        {
            TransactionService trasactionService = new TransactionService();
            TransactionsSumsDTO result = trasactionService.GetTransactionsBySku(sku);
            bool resultGood = true;
            if (result == null)
                resultGood = false;
            Assert.AreEqual(true, resultGood);
        }
    }
}
