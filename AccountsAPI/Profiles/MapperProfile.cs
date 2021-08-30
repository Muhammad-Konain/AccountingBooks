using AccountsAPI.Dtos;
using AccountsAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsAPI.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserLoginDto, User>();
            CreateMap<FinancialYearDto, FinancialYear>();
            CreateMap<FinancialYear, FinancialYearDto>();
            CreateMap<TAccountDto, TAccount>();
            CreateMap<TAccount, TAccountDto>();

            CreateMap<CreateTAccountDTO, TAccount>();
            CreateMap<TAccount, ReadTAccountDto>();

            CreateMap<Voucher, VoucherDto>();
            CreateMap<VoucherDto, Voucher>();

            CreateMap<AccountTransaction, AccountTransactionDto>();
            CreateMap<AccountTransactionDto, AccountTransaction>();

            CreateMap<ReadVoucherDto, Voucher>();
            CreateMap<Voucher, ReadVoucherDto>();
        }
    }
}
