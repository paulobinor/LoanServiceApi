using LoanServiceApi.Application.Validators;
using LoanServiceApi.Infrastructure.Ef.Data;
using LoanServiceApi.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using LoanServiceApi.Domain.Interfaces;
using AutoMapper;
using LoanServiceApi.Application;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using LoanServiceApi.Models;
using LoanServiceApi.Application.Models.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LoanServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LoanDbContext _context;
        private readonly LoanValidator _loanValidator;
        private readonly LoanRepaymentValidator _repaymentValidator;
        private readonly ILoanService _loanService;
        private readonly IMapper mapper;
        public LoanController(LoanDbContext context, ILoanService loanService)
        {
            _context = context;
            _loanValidator = new LoanValidator();
            _repaymentValidator = new LoanRepaymentValidator();
            _loanService = loanService;
            mapper = MapperConfig.LoanMapper();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoan([FromBody] CreateLoanDto createLoan)
        {
            ApiRequest apiRequest = new ApiRequest();
            try
            {
                var validationResult = _loanValidator.Validate(createLoan);
                if (!validationResult.IsValid)
                {
                    apiRequest.Data = validationResult.Errors;
                    apiRequest.ResponseDescription = $"Bad data";
                    apiRequest.ResponseCode = "01";
                    return BadRequest(apiRequest);
                }
                var loan = mapper.Map<Loan>(createLoan);
                var res = await _loanService.CreateLoan(loan);
                if (res != null)
                {
                    var resdto = mapper.Map<LoanDto>(res);
                    apiRequest.Data = resdto;
                    apiRequest.ResponseCode = "00";
                    apiRequest.ResponseDescription = "Success";
                    return StatusCode(201, apiRequest);
                }
                apiRequest.ResponseCode = "01";
                apiRequest.ResponseDescription = "Failed";
                return StatusCode(204, apiRequest);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("repayment")]
        public async Task<IActionResult> AddRepayment([FromBody] AddRepaymentDto loanRepayment)
        {
            var apiRequest = new ApiRequest();
            var validationResult = _repaymentValidator.Validate(loanRepayment);
            if (!validationResult.IsValid)
            {
                apiRequest.Data = validationResult.Errors;
                apiRequest.ResponseDescription = $"Bad data";
                apiRequest.ResponseCode = "01";
                return BadRequest(apiRequest);
            }


            var repayment = mapper.Map<LoanRepayment>(loanRepayment);
            var resp = await _loanService.AddRepayment(repayment);
            if (resp == null)
            {
                apiRequest.ResponseDescription = $"We encountered an error. Please contact support or try again in a short while";
                apiRequest.ResponseCode = "09";
                return StatusCode(204, apiRequest);
            }

            apiRequest.Data = resp;
            apiRequest.ResponseDescription = "Success";
            apiRequest.ResponseCode = "00";
            return StatusCode(201, apiRequest);
        }

        [HttpGet("Customer/{CustomerNo}")]
        public async Task<IActionResult> GetLoanByCustomerNo([FromRoute]string CustomerNo)
        {
            var apiRequest = new ApiRequest();
            try
            {
                var validationResult = new GetCustomerLoansValidator().Validate(CustomerNo);
                if (!validationResult.IsValid)
                {
                    apiRequest.Data = validationResult.Errors;
                    apiRequest.ResponseDescription = $"Bad data";
                    apiRequest.ResponseCode = "01";
                    return BadRequest(apiRequest);
                }

                var res = await _loanService.GetCustomerLoans(CustomerNo);

                if (res == null || res.Count == 0)
                {
                    apiRequest.ResponseDescription = $"No loans found for customer with ID {CustomerNo}";
                    apiRequest.ResponseCode = "25";
                    return NotFound(apiRequest);
                }
                var customerloans = mapper.Map<List<LoanDto>>(res);
                apiRequest.Data = customerloans;
                apiRequest.ResponseDescription = "Success";
                apiRequest.ResponseCode = "00";

                return Ok(apiRequest);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
