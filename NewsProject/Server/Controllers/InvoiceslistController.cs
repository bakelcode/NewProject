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
    // [Authorize(Roles = "Admin")]
    public class InvoiceslistController : ControllerBase
    {
        private readonly MainInteface<Invoicelist> _invoicetemp;
        public InvoiceslistController(MainInteface<Invoicelist> invoicetemp)
        {
            _invoicetemp = invoicetemp;
        }

        // GET: api/<InvoicesTempController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllInvoicesTemp()
        {
            return Ok(_invoicetemp.GetAllDate(new[] { "Category", "Product", "Barench"  }));
        }
        [HttpGet]
        public IActionResult GetTotalInvoicesTemp()
        {
            return Ok(_invoicetemp.GetAllDate(new[] { "Category", "Product", "Barench", "Invoice" }).Sum(x => x.Total));
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
            var invoicetemp = _invoicetemp.GetAllDate(new[] { "Category", "Product", "Barench", "Invoice" }).Where(c => c.InvoicelistID == id).FirstOrDefault();
            if (invoicetemp == null)
            {
                return NotFound();
            }
            return Ok(invoicetemp);
        }

        // POST api/<InvoicesTempController>
        [HttpPost]
        public IActionResult AddInvoiceTemp([FromBody] Invoicelist model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //  ModelState.Clear();
                    var NewInvoiceTemp = _invoicetemp.GetAllDate(new[] { "Category", "Product", "Barench", "Invoice" }).Where(c => c.CategoryId == model.CategoryId
               && c.ProductID == model.ProductID && c.BarenchID == model.BarenchID).FirstOrDefault();
                    if (NewInvoiceTemp == null)
                    {
                        model.Total = model.Price * model.Quntity;
                        _invoicetemp.AddRow(model);
                        return Ok(model);
                    }
                    else
                    {


                        NewInvoiceTemp.Quntity += model.Quntity;
                        NewInvoiceTemp.Total += model.Price * model.Quntity;
                        _invoicetemp.UpdateRow(NewInvoiceTemp);
                        return Ok(NewInvoiceTemp);
                    }
                    return Ok(ModelState);
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
        public IActionResult UpdateInvoice(int id, [FromBody] Invoicelist model)
        {



            //var   UpInvoiceTemps = _invoicetemp.GetAllDate(new[] { "Category", "Product", "Barench" }).
            //       Where(c => c.Price == model.Price && c.Quntity == model.Quntity).FirstOrDefault();
            //   if (UpInvoiceTemps != null)
            //   {
            //       UpInvoiceTemps.Quntity += model.Quntity;
            //       UpInvoiceTemps.Total += model.Price * model.Quntity;
            //       _invoicetemp.UpdateRow(UpInvoiceTemps);
            //   }
            model.Total = model.Price * model.Quntity;

            _invoicetemp.UpdateRow(model);
            return Ok(model);
        }

        // DELETE api/<InvoicesTempController>/5
        [HttpDelete("{id}")]
        public void DeleteInvoiceTemp(int id)
        {
            _invoicetemp.DeleteRow(id);
        }
    }
}
