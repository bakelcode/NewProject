using NewsProject.Server.Repositories.Intefaces;
using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class BarenchesController : ControllerBase
    {
        private readonly MainInteface<Barench> _barench;

        public BarenchesController(MainInteface<Barench> barench)
        {
            _barench = barench;
        }

        // GET: api/<BarenchController>
        [HttpGet]
        public IActionResult GetAllBarenchs()
        {
            return Ok(_barench.GetAllDate());
        }
        //Handling Http request
        [HttpGet]
        public IActionResult GetBarenchsError()
        {
            return StatusCode(500, "SomeThing Wrong");
        }
        [HttpGet]
        public IActionResult GetunAuthorizedError()
        {
            return Unauthorized("Not Allowed");
        }
        // GET api/<BarenchsController>/5
        [HttpGet("{id}")]
        public IActionResult GetBarench(int id)
        {
            var barench = _barench.GetRowById(id);
            if (_barench == null)
            {
                return NotFound();
            }
            return Ok(barench);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult AddBarench([FromBody] Barench model)
        {
            //is not error
            if (ModelState.IsValid)
            {  // لتاكد انه اول خطا
                ModelState.Clear();
               
                var NewProduct = _barench.GetAllDate().Where(c => c.BarenchName == model.BarenchName).FirstOrDefault();
                if (NewProduct != null)
                {
                    ModelState.AddModelError("Error", "Barench Name Already Exists");
                    //return BadRequest(ModelState);
                    return BadRequest(ModelState.First().Value.Errors.First().ErrorMessage);
                }
                model.CreatDate = DateTime.Now;
                _barench.AddRow(model);
                return Ok(model);

            }
            return BadRequest(ModelState);
        }

        // PUT api/<BaraesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBarenches( int id, [FromBody] Barench model)
        {

            if (id == model.BarenchID)
            {
                _barench.UpdateRow(model);
                return Ok(model);
            }
            return NotFound();
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void DeleteBarenches(int id)
        {
            _barench.DeleteRow(id);
        }


    }
}
