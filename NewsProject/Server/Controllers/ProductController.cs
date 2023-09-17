using NewsProject.Server.Repositories.Intefaces;
using NewsProject.Shared.Dtos;
using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly MainInteface<Product> _product;
        private readonly IWebHostEnvironment _webHostEnvironment;
        //  private readonly ILogger _logger;  
        //private readonly RollsDto _ollsDto; 
        ///Product Product1 = null;   

        public ProductController(MainInteface<Product> Product, IWebHostEnvironment webHostEnvironment)
        {
            this._product = Product;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAllProduct()
        {
          // return Ok(_product.GetAllDate());


            return Ok(_product.GetAllDate(new[] { "Category" , "Barench" }).OrderByDescending(n => n.ProductName));
        }
        public IActionResult GetAllProductByCategory(int id)
        {
            return Ok(_product.GetAllDate(new[] { "Category", "Barench" }).Where(nl => nl.CategoryId == id));
        }
        [HttpGet]
        public IActionResult GetAllProductByTitle(string Title)
        {
            return Ok(_product.GetAllDate(new[] { "Category", "Barench" }).Where(nl => nl.Category.CategoryName.Contains(Title)));
        }
        [HttpGet("{CatID}")]
        public IActionResult GetAllProductListByCategory(int id)
        {
            return Ok(_product.GetAllDate(new[] { "Category", "Barench" }).Where(nl => nl.ProductID == id));
        }
        //Handling Http request
        [HttpGet]
        public IActionResult GetProductError()
        {
            return StatusCode(500, "SomeThing Wrong");
        }
        [HttpGet]
        public IActionResult GetunAuthorizedError()
        {
              
            return Unauthorized("Not Allowed");
        }
        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public  IActionResult GetProduct(int id)
        {
           
          
            
                return Ok(_product.GetAllDate(new[] { "Category", "Barench" }).Where(p=> p.ProductID==id).FirstOrDefault() ); 
           
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async  Task<IActionResult> AddProduct([FromBody] ProductDto modelDto)
        {
            string FileName = "";
            if (modelDto.NewImg != null)
            {
                string FullPath = Path.Combine(_webHostEnvironment.WebRootPath, "NewsImages");
                if (!Directory.Exists(FullPath))
                {
                    Directory.CreateDirectory(FullPath);
                }
                FileName = Guid.NewGuid() + "_" + modelDto.Img;
                string ImagePath = Path.Combine(FullPath, FileName);
                await using var stream = new FileStream(ImagePath, FileMode.Create);
                stream.Write(modelDto.NewImg, 0, modelDto.NewImg.Length);
            }
            Product model = new Product()
            {
                ProductName = modelDto.ProductName,
                Quntity = modelDto.Quntity,
                Price = modelDto.Price,
                CategoryId = modelDto.CategoryId,
                BarenchID = (int)modelDto.BarenchId,
                Img = FileName,
                CreatDate=DateTime.Now
            };
            _product.AddRow(model);
            return Ok(model);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product model)
        {
            if (id != model.ProductID)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var product = _product.GetRowById(model.ProductID);
                if (product == null)
                    return NotFound();
                else
                {
                    model.UpdateDate = DateTime.Now;
                    var bak = _product.UpdateRow(model);
                    return Ok(bak);

                }

            }
            catch
            {
                return NotFound();
            }

            return NoContent();


        
        
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public  void  DeleteProduct(int id)
        {

           _product.DeleteRow(id);
            
                
        }

    }
}

