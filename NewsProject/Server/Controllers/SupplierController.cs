using NewsProject.Server.Repositories.Intefaces;
using NewsProject.Server.Repositories;
using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NewsProject.Server.Controllers
    {
        [Route("api/Supplier/[action]")]
        [ApiController]
        [Authorize]
    public class SupplierController : ControllerBase
        {
            private readonly MainInteface<Supplier> _supplier;
            public SupplierController(MainInteface<Supplier> supplier)
            {
                _supplier = supplier;
            }

            // GET: api/<CategoriesController>
            [HttpGet]
            public IActionResult GetAllSupplieres()
            {
                return Ok(_supplier.GetAllDate());
            }
            //Handling Http request
            [HttpGet]
            public IActionResult GetSupplieresError()
            {
                return StatusCode(500, "SomeThing Wrong");
            }
            [HttpGet]
            public IActionResult GetunAuthorizedError()
            {
                return Unauthorized("Not Allowed");
            }
            // GET api/<CategoriesController>/5
            [HttpGet("{id}")]
            public IActionResult GetSupplier(int id)
            {
                var supplier = _supplier.GetRowById(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                return Ok(supplier);
            }

            // POST api/<CategoriesController>
            [HttpPost]

            public IActionResult AddSupplier([FromBody] Supplier model)
            {
                //is not error
                if (ModelState.IsValid)
                {  // لتاكد انه اول خطا
                    ModelState.Clear();
                    var NewSupplier = _supplier.GetAllDate().Where(c => c.SupplierName == model.SupplierName).FirstOrDefault();
                    if (NewSupplier != null)
                    {
                        ModelState.AddModelError("Error", "Supplier Name Already Exists");
                        //return BadRequest(ModelState);
                        return BadRequest(ModelState.First().Value.Errors.First().ErrorMessage);
                    }
                model.CreatDate = DateTime.Now;
                    _supplier.AddRow(model);
                    return Ok(model);

                }
                return BadRequest(ModelState);
            }

            // PUT api/<CategoriesController>/5
            [HttpPut("{id}")]
            public IActionResult UpdateSupplier(int id, [FromBody] Supplier model)
            {

                if (id != model.SupplierID)
                {
                    return BadRequest(ModelState);
                }
                try
                {
              
                
                    model.UpdateDate = DateTime.Now;
                    var bak = _supplier.UpdateRow(model);
                    return Ok(bak);

                
                
                }
                catch
                {
                    return NotFound();
                }

              
            }

            //private bool TodoItemExists(int id)
            //{
            //    return _supplier.TodoItems.Any(e => e.Id == id);
            //}

            //private static CategoyrDTO ItemToDTO(Supplier todoItem) => new Supplier
            //   new SupplierDTO
            //   {
            //       Id = todoItem.SupplierID,
            //       Name = todoItem.SupplierName,
            //       IsComplete = todoItem.IsComplete
            //   };



            // DELETE api/<CategoriesController>/5
            [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteSupplier(int id)
            {
                _supplier.DeleteRow(id);
            }


        }
    }






