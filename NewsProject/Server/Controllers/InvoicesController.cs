using NewsProject.Server.Repositories.Intefaces;
using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class InvoicesController : ControllerBase
    {

        private readonly MainInteface<Invoice> _invoicet;
        private readonly MainInteface<InvoiceTemp> _temp;
       // private readonly MainInteface<Invoicelist> _inlst;

        public InvoicesController(MainInteface<Invoice> invoicet ,MainInteface<InvoiceTemp> intamp)
        {
            _invoicet = invoicet;
            _temp = intamp;
        }


        // GET: api/<InvesController>
        [HttpGet]
        public IActionResult GetAllInvoices()
        {
            return Ok(_invoicet.GetAllDate(new[] {"Supplier", "Barench" }));
        }
        
        //public IActionResult GetInvoicesError()
        //{
        //    return StatusCode(500, "SomeThing Wrong");
        //}
        [HttpGet]
        public IActionResult GetunAuthorizedError()
        {
            return Unauthorized("Not Allowed");
        }
        // GET api/<InvoicesTempController>/5
        [HttpGet("{id}")]
        public IActionResult GetInvoices(int id)
        {
            var invoicetemp = _invoicet.GetAllDate(new[] { "Supplier", "Barench" }).Where(c => c.InvoiceId == id ).FirstOrDefault();
            if (invoicetemp == null)
            {
                return NotFound();
            }
            return Ok(invoicetemp);
        }

        // POST api/<InvesController>
        [HttpPost]
        public async Task<IActionResult> AddInvvv([FromBody] Invoice model)
        {
           
                if (model == null)
                return BadRequest();
            else
            {
              //  var bakel = model.InvoiceItemlist;
                decimal bak = 0;

                // List<InvoiceTemp> temps = new List<InvoiceTemp>(); 
               var temps = _temp.GetAllDate(new[] { "Category", "Product", "Barench" }).ToList();
                if (temps != null)
                {
                    var bakel11 = model.InvoiceItemlist;
                    foreach (var r in temps)
                    {
                        bakel11.Add(new Invoicelist()
                        

                        {
                            CategoryId = r.CategoryId,
                            ProductID = r.ProductID,
                            Quntity = r.Quntity,
                            BarenchID = r.BarenchID,
                            Price = r.Price,
                            Total = r.Total,
                            InvID = model.InvoiceId




                        });
                        bak += r.Total;
                        // ras1.Remove(r);
                        _temp.DeleteRow(r.InvoiceTempID);
                        // bakel.Clear();
                    }
                    
                   
                        model.BarenchID = 1;
                        model.Qountte = 1;
                        
                        model.Date = DateTime.Now;
                        model.Total = bak;
                        model.Discontafter = model.Total - model.Discont;
                        _invoicet.AddRow(model);
                    return Ok(200);

                }
                return Ok(20);
            }

         



            // ras.Remove(r);



        }


        

        // PUT api/<InvesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateInv(int id, [FromBody] Invoice model)
        {

            if (id != model.InvoiceId)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var Inves = _invoicet.GetRowById(model.InvoiceId);
                if (Inves == null)
                    return NotFound();
                else
                {
                    model.UpdateDate = DateTime.Now;
                    var bak = _invoicet.UpdateRow(model);
                    return Ok(bak);

                }

            }
            catch
            {
                return NotFound();
            }

            return NoContent();


        }

        // DELETE api/<InvesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {


            try
            {

                var Inves = _invoicet.GetRowById(id);
                if (Inves != null)
                {

                    _invoicet.DeleteRow(id);

                }


            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }
        }
    }
}
