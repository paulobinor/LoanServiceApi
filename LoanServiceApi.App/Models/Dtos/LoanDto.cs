namespace LoanServiceApi.Application.Models.Dtos
{
    public class LoanDto
    {
        public string LoanId { get; set; } 
        public string CustomerNo { get; set; }
        public string LoanName { get; set; }
        public double LoanAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyRepaymentAmount { get; set; }
        public double AmountPaid { get; set; }
        public double BalanceDue { get; set; }
        public List<LoanRepaymentDto> LoanRepayments { get; set; } = new List<LoanRepaymentDto>();
    }

    public class CreateLoanDto
    {
        public string CustomerNo { get; set; }
        public string LoanName { get; set; }
        public double LoanAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyRepaymentAmount { get; set; }
    }
}
