using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("[controller]")]
    public class SimpleController : Controller
    {
        public SimpleController() { }

        //[HttpGet("")]
        //public ActionResult<IEnumerable<string>> Get() {
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet(Name = "")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" }.ToArray(); 
        }
    }
}
