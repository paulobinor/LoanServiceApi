using LoanServiceApi.Application.Interfaces;
using LoanServiceApi.Domain.Interfaces;
using LoanServiceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanServiceApi.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly IdbRepoService _dbRepoService;
        public LoanService(IdbRepoService dbRepoService)
        {
            _dbRepoService = dbRepoService;
        }
        public async Task<LoanRepayment> AddRepayment(LoanRepayment loanRepayment)
        {
            try
            {

                return await _dbRepoService.AddRepayment(loanRepayment);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Loan> CreateLoan(Loan loan)
        {
            try
            {
               return await _dbRepoService.CreateLoan(loan);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Loan>> GetCustomerLoans(string CustomerNo)
        {
            try
            {
                return await _dbRepoService.GetLoanDetails(CustomerNo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
