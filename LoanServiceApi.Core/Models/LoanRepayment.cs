using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanServiceApi.Domain.Models
{
    public class LoanRepayment
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LoanRepaymentId { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("Loan")]
        public string LoanId { get; set; }
        public double AmountPaid { get; set; }
        public DateTime DatePaid { get; set; }
    }
}
