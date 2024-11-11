using FluentValidation;
using LoanServiceApi.Application.Models.Dtos;
using LoanServiceApi.Domain.Models;

namespace LoanServiceApi.Application.Validators
{
    public class LoanValidator : AbstractValidator<CreateLoanDto>
    {
        public LoanValidator()
        {
            RuleFor(x => x.CustomerNo).NotEmpty();
            RuleFor(x => x.LoanName).NotEmpty();
            RuleFor(x => x.LoanAmount).GreaterThan(0);
            RuleFor(x => x.MonthlyRepaymentAmount).GreaterThan(0);
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
          //  RuleFor(x => x.BalanceDue).GreaterThanOrEqualTo(0);
        }
    }

    public class LoanRepaymentValidator : AbstractValidator<AddRepaymentDto>
    {
        public LoanRepaymentValidator()
        {
           // RuleFor(x => x.LoanId).NotEmpty();
            RuleFor(x => x.AmountPaid).GreaterThan(0);
           // RuleFor(x => x.DatePaid).NotEmpty();
        }
    }

    public class GetCustomerLoansValidator : AbstractValidator<string>
    {
        public GetCustomerLoansValidator()
        {
            // RuleFor(x => x.LoanId).NotEmpty();
            RuleFor(x => x).NotEmpty();
            // RuleFor(x => x.DatePaid).NotEmpty();
        }
    }
}
