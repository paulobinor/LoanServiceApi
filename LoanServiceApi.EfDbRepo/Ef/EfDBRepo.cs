using LoanServiceApi.Application.Interfaces;
using LoanServiceApi.Domain.Models;
using LoanServiceApi.Infrastructure.Ef.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanServiceApi.Infrastructure.Ef
{
    public class EfDBRepo : IdbRepoService
    {
        private readonly LoanDbContext _loanDbContext;

        public EfDBRepo(LoanDbContext loanDbContext)
        {
            _loanDbContext = loanDbContext;
        }
        public async Task<LoanRepayment> AddRepayment(LoanRepayment loanRepayment)
        {
            try
            {
                var loan = _loanDbContext.Loans.Find(loanRepayment.LoanId);
                if (loan == null) return null;
                loanRepayment.LoanId = loan.LoanId;
                loanRepayment.DatePaid = DateTime.Now;
                loan.LoanRepayments.Add(loanRepayment);
                loan.AmountPaid += loanRepayment.AmountPaid;
                loan.BalanceDue = loan.LoanAmount - loan.AmountPaid;

                _loanDbContext.SaveChanges();

                //var lr = await _loanDbContext.LoanRepayments.FirstOrDefaultAsync(x => x.LoanId == loan.LoanId && x.LoanRepaymentId = );
               // var lr = _loanDbContext.LoanRepayments.Where(x => x.LoanId.Equals(loan.LoanId)).Max();
                return loanRepayment;
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
                loan.BalanceDue = loan.LoanAmount;
                _loanDbContext.Loans.Add(loan);
                 _loanDbContext.SaveChanges();

                var res = _loanDbContext.Loans.FirstOrDefault(x => x.LoanId.Equals(loan.LoanId));
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Loan>> GetLoanDetails(string CustomerNo)
        {
            try
            {
                var loans = await _loanDbContext.Loans
                .Where(l => l.CustomerNo == CustomerNo)
                .Include(l => l.LoanRepayments)
                .ToListAsync();

                if (loans == null || loans.Count == 0)
                {
                    return null;
                }
                return loans;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
