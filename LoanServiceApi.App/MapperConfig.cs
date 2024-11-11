using AutoMapper;
using LoanServiceApi.Application.Models.Dtos;
using LoanServiceApi.Domain.Models;
using System;

namespace LoanServiceApi.Application
{
    public class MapperConfig : Profile
    {
        public static IMapper LoanMapper()
        {
            //Provide all the Mapping Configuration
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Loan, LoanDto>().ReverseMap();
                cfg.CreateMap<Loan, CreateLoanDto>().ReverseMap();
                cfg.CreateMap<LoanRepayment, LoanRepaymentDto>().ReverseMap();
                cfg.CreateMap<LoanRepayment, AddRepaymentDto>().ReverseMap();
            }).CreateMapper();
           
            return mapper;
        }
    }
}
