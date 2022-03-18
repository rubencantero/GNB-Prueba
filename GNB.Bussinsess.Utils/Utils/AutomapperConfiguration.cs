using AutoMapper;
using GNB.Bussiness.Application.DTOs.DTO;
using GNB.Bussiness.BD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB.Bussinsess.Utils.Utils
{
    public class AutomapperConfiguration
    {
        private static IProfileExpression _MapperApp;
        public static void Configure() {
            Mapper.Reset();
            _MapperApp = Mapper.CreateProfile("GNB.Bussiness");
            _MapperApp.AllowNullDestinationValues = true;
            RegisterTransactions();
            RegisterConversions();
        }

        private static void RegisterConversions()
        {
            _MapperApp.CreateMap<Conversions, ConversionsDTO>()
                .ForMember(dst => dst.from, src => src.MapFrom<string>(conv => conv.From))
                .ForMember(dst => dst.to, src => src.MapFrom<string>(conv => conv.To))
                .ForMember(dst => dst.amount, src => src.MapFrom<decimal>(conv => conv.Amount));
        }

        private static void RegisterTransactions()
        {
            _MapperApp.CreateMap<Transactions, TransactionsDTO>()
                .ForMember(dst => dst.sku, src => src.MapFrom<string>(conv => conv.Sku))
                .ForMember(dst => dst.currency, src => src.MapFrom<string>(conv => conv.Currency))
                .ForMember(dst => dst.amount, src => src.MapFrom<decimal>(conv => conv.Amount));
        }
    }
}
