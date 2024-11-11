using LoanServiceApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanServiceApi.Infrastructure.Ef.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options) { }

        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanRepayment> LoanRepayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .HasKey(l => l.LoanId);

            modelBuilder.Entity<LoanRepayment>()
                .HasKey(lr => lr.LoanRepaymentId);

            modelBuilder.Entity<Loan>()
                .HasMany(l => l.LoanRepayments)
                .WithOne();
              //  .HasForeignKey(lr => lr.LoanId);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            //Dummy Loan data
            var loanId1 = Guid.NewGuid().ToString();
            var loanId2 = Guid.NewGuid().ToString();
           // var repaymentId1 = Guid.NewGuid().ToString();
           // var repaymentId2 = Guid.NewGuid().ToString();

            modelBuilder.Entity<Loan>().HasData(
                new Loan
                {
                    LoanId = loanId1,
                    CustomerNo = "C001",
                    LoanName = "Personal Loan",
                    LoanAmount = Convert.ToDouble("10000"),
                    StartDate = DateTime.Now.AddMonths(-3),
                    EndDate = DateTime.Now.AddMonths(9),
                    MonthlyRepaymentAmount = 500,
                    AmountPaid = 1500,
                    BalanceDue = 8500
                },
                new Loan
                {
                    LoanId = loanId2,
                    CustomerNo = "C002",
                    LoanName = "Car Loan",
                    LoanAmount = Convert.ToDouble("20000"),
                    StartDate = DateTime.Now.AddMonths(-6),
                    EndDate = DateTime.Now.AddMonths(18),
                    MonthlyRepaymentAmount = 1000,
                    AmountPaid = 6000,
                    BalanceDue = 14000
                }
            );

            modelBuilder.Entity<LoanRepayment>().HasData(
                new LoanRepayment
                {
                    LoanRepaymentId = Guid.NewGuid().ToString(),
                    LoanId = loanId1,
                    AmountPaid = 500,
                    DatePaid = DateTime.Now.AddMonths(-2)
                },
                new LoanRepayment
                {
                    LoanRepaymentId = Guid.NewGuid().ToString(),
                    LoanId = loanId2,
                    AmountPaid = 1000,
                    DatePaid = DateTime.Now.AddMonths(-1)
                }
            );
        }
    }
}
