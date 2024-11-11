using LoanServiceApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanServiceApi.Application.Interfaces
{
    public interface IdbRepoService
    {
        Task<Loan> CreateLoan(Loan loan);
        Task<LoanRepayment> AddRepayment(LoanRepayment loanRepayment);
        Task<List<Loan>> GetLoanDetails(string CustomerNo);
    }
}
