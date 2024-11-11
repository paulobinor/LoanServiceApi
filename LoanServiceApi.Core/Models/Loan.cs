using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanServiceApi.Domain.Models
{
    public class Loan
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LoanId { get; set; } = Guid.NewGuid().ToString();
        public string CustomerNo { get; set; }
        public string LoanName { get; set; }
        public double LoanAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MonthlyRepaymentAmount { get; set; }
        public double AmountPaid { get; set; }
        public double BalanceDue { get; set; }
        public List<LoanRepayment> LoanRepayments { get; set; } = new List<LoanRepayment>();
    }
}
