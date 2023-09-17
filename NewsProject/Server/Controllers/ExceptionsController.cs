using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsProject.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExceptionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetException()
        {
            //try
            //{
            //    throw new Exception("User Error");
            //}
            //catch
            //{
            //    throw;
            //}
            //finally
            //{
            //    throw new Exception("New User Error");
            //}
            try
            {
                throw new Exception("User Error");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetOutOfRangeException()
        {
            try
            {
                int[] MyNumber = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    MyNumber[i] = i;
                }
                //MyNumber[3] = int.Parse("Hi");
                return Ok(MyNumber);
            }
            catch(IndexOutOfRangeException ex)
            {
                return BadRequest("Number of inputs must be less than 6");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult DividedByZeroException()
        {
            try
            {
                double MyNumber = 0;
                int SNumber = 0;
                MyNumber = 100 / SNumber;
                return Ok(MyNumber);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult NestedException()
        {
            try
            {
                int MyNumber = 0;
                int SNumber = 100;
                MyNumber = 100 / SNumber;
                try
                {
                    int[] NewNumber = new int[10];
                    for (int i = 0; i < NewNumber.Count(); i++)
                    {
                        NewNumber[i] = i;
                    }
                    return Ok(NewNumber[MyNumber]);
                }
                catch (IndexOutOfRangeException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
