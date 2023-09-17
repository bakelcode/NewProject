using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsProject.Server.Models;
using NewsProject.Server.Repositories;
using NewsProject.Server.Repositories.Intefaces;
using NewsProject.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class InvoicesTempController : ControllerBase
    {
        private readonly MainInteface<InvoiceTemp> _invoicetemp;
        public InvoicesTempController(MainInteface<InvoiceTemp> invoicetemp)
        {
            _invoicetemp = invoicetemp;
        }

        // GET: api/<InvoicesTempController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllInvoicesTemp()
        {
            return Ok(_invoicetemp.GetAllDate(new[] { "Category", "Product", "Barench" }));
        }
        [HttpGet]
        public IActionResult GetInvoicesTempError()
        {
            return StatusCode(500, "SomeThing Wrong");
        }
        [HttpGet]
        public IActionResult GetunAuthorizedError()
        {
            return Unauthorized("Not Allowed");
        }
        // GET api/<InvoicesTempController>/5
        [HttpGet("{id}")]
        public IActionResult GetInvoiceTemp(int id)
        {
            var invoicetemp = _invoicetemp.GetAllDate(new[] { "Category", "Product", "Barench" }).Where(c => c.InvoiceTempID == id).FirstOrDefault();
            if (invoicetemp == null)
            {
                return NotFound();
            }
            return Ok(invoicetemp);
        }
        [HttpGet]
        public IActionResult GetTotalInvoicesTemp()
        {
            return Ok(_invoicetemp.GetAllDate(new[] { "Category", "Product", "Barench" }).Sum(x => x.Total));
        }
        // POST api/<InvoicesTempController>
        [HttpPost]
        public IActionResult AddInvoiceTemp([FromBody] InvoiceTemp model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                  //  model.Total = model.Quntity * model.Price;
                  //  ModelState.Clear();
                    var NewInvoiceTemp = _invoicetemp.GetAllDate(new[] { "Category", "Product" , "Barench" }).Where(c => c.CategoryId == model.CategoryId
                && c.ProductID == model.ProductID && c.BarenchID == model.BarenchID).FirstOrDefault();
                    if (NewInvoiceTemp == null && model.Quntity > 0 )
                    {
                        model.Total = model.Price * model.Quntity;
                        _invoicetemp.AddRow(model);
                        return Ok(model);
                    }
                    else
                    {
                      
                        
                        NewInvoiceTemp.Quntity += model.Quntity;
                        NewInvoiceTemp.Total += model.Price * model.Quntity;
                        if (NewInvoiceTemp.Price != model.Price)
                            NewInvoiceTemp.Price = NewInvoiceTemp.Total / NewInvoiceTemp.Quntity;   
                            _invoicetemp.UpdateRow(NewInvoiceTemp);
                        return Ok(NewInvoiceTemp);
                    }
                    
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<InvoicesTempController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateInvoiceTemp(int id, [FromBody] InvoiceTemp model)
        {
            model.Total = model.Price * model.Quntity;

            _invoicetemp.UpdateRow(model);
            return Ok(model);
        }

        // DELETE api/<InvoicesTempController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteInvoiceTemp(int id)
        {
            _invoicetemp.DeleteRow(id);
        }
    }
}
