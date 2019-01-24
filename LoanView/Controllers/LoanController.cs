using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoanView.Models;
using Microsoft.EntityFrameworkCore;
using LoanView.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoanView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly LoanService _loanService;
        public LoanController(LoanService loanService)
        {
            _loanService = loanService;
                           
        }
        // GET: api/loan
        [HttpGet]
        public ActionResult<List<LoanItem>> GetLoanItems()
        {
            return _loanService.Get();
        }

        // GET: api/Todo/5
        [HttpGet("{id:length(24)}",Name ="GetLoan")]
        public ActionResult<LoanItem> GetLoanItem(String id)
        {
            var loanItem = _loanService.Get(id); 

            if (loanItem == null)
            {
                return NotFound();
            }

            return loanItem;
        }

        // POST: api/loan
        [HttpPost]
        public ActionResult<LoanItem> PostLoanItem(LoanItem loanItem)
        {
            _loanService.Create(loanItem);

            return CreatedAtRoute("GetLoanItem", new { id = loanItem.Id.ToString() }, loanItem);
        }
        // PUT: api/loan/5
        [HttpPut("{id:length(24)}")]
        public IActionResult PutLoanItem(String id, LoanItem loanItem)
        {
            var loan = _loanService.Get(id);
            if (loan == null)
            {
                return NotFound();            
            }
            _loanService.Update(id, loan);
            return NoContent();
        }
        // DELETE: api/loan/5
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteLoanItem(String id)
        {
            var loan = _loanService.Get(id);
            if (loan == null)
            {
                return NotFound();
            }
            _loanService.Remove(loan.Id);
            return NoContent();
        }

    }
}
