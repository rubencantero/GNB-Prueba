using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Bussiness.BD.Domain
{
    public class Transactions
    {        
    

        #region Atributos
        private int _id;
        private string _sku;
        private string _currency;
        private decimal _amount;
        #endregion

        #region Propiedades

        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual string Sku
        {
            get { return _sku; }
            set { _sku = value; }
        }
        public virtual string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        public virtual decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        #endregion
    }
}
