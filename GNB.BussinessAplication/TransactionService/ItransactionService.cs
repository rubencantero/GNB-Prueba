using GNB.Bussiness.Application.DTOs.DTO;
using GNB.Bussiness.BD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.BussinessAplication.TransactionService
{
    public interface ItransactionService
    {
        List<ConversionsDTO> GetConversions();
    }
}
