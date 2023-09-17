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
    [AllowAnonymous]
    public class CategoriesController : ControllerBase
    {
        private readonly MainInteface<Category> _category;
        public CategoriesController(MainInteface<Category> category)
        {
            _category = category;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAllCategories()
        {
            return Ok(_category.GetAllDate());
        }
        [HttpGet]
        public IActionResult GetCategoriesError()
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
        public IActionResult GetCategory(int id)
        {
            var category = _category.GetRowById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                var NewCategory = _category.GetAllDate().Where(c=> c.CategoryName == model.CategoryName).FirstOrDefault();
                if (NewCategory != null)
                {
                    ModelState.AddModelError("Error", "Category Name Already Exists");
                    //return BadRequest(ModelState);
                    return BadRequest(ModelState.First().Value.Errors.First().ErrorMessage);
                }
                _category.AddRow(model);
                return Ok(model);
                
            }
            return BadRequest(ModelState);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category model)
        {
           _category.UpdateRow(model);
            return Ok(model);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _category.DeleteRow(id);
        }
    }
}
