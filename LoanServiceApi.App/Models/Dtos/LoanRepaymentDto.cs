namespace LoanServiceApi.Application.Models.Dtos
{
    public class LoanRepaymentDto
    {
       // public string LoanId { get; set; }
      //  public string LoanRepaymentId { get; set; }
        public double AmountPaid { get; set; }
       // public string LoanAmount { get; set; }
        public DateTime DatePaid { get; set; }
    }

    public class AddRepaymentDto
    {
        public string LoanId { get; set; }
        public double AmountPaid { get; set; }
       // public string LoanAmount { get; set; }
      //  public DateTime DatePaid { get; set; }
    }
}
