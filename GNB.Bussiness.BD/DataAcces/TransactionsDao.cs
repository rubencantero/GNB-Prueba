using GNB.Bussiness.BD.Core;
using GNB.Bussiness.BD.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Bussiness.BD.DataAcces
{
    public class TransactionsDao
    {
        public const string FilePathConversions = @"C:\Storage\Conversions.dat";
        public const string FilePathTransactions = @"C:\Storage\Transactions.dat";
        public TransactionsDao()
        {

        }


        #region Methods

        public List<Conversions> GetConversions()
        {
            try
            {                
                return (List<Conversions>)NHSession.GetCurrentSession().CreateCriteria(typeof(Conversions)).List<Conversions>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Transactions> GetTransactions()
        {
            try
            {

                return (List<Transactions>)NHSession.GetCurrentSession().CreateCriteria(typeof(Transactions)).List<Transactions>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Transactions> GetTransactionsBySku(string sku)
        {
            try
            {
                return (List<Transactions>)NHSession.GetCurrentSession().CreateCriteria(typeof(Transactions)).Add(Expression.Eq("Sku", sku)).List<Transactions>();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static bool getIsconection() {
            return NHSession.isConection;
        }
        #endregion
    }
}
