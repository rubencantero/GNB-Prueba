using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Bussiness.Application.DTOs.DTO
{
    public class TransactionsDTO
    {
        public string sku { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
    }
}
