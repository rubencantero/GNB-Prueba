using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Bussiness.BD.Domain
{
     public class Conversions
    {     
        #region Atributos
        private int _id;
        private string _from;
        private string _to;
        private decimal _amount;
        #endregion

        #region Propiedades

        public virtual int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual string From {
            get { return _from; }
            set { _from = value; }
        }
        public virtual string To
        {
            get { return _to; }
            set { _to = value; }
        }
        public virtual decimal Amount
        {
            get { return _amount; }
            set { _amount= value; }
        }
        #endregion
    }
}
