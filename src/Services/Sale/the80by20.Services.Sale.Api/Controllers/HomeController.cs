using Microsoft.AspNetCore.Mvc;

namespace the80by20.Services.Sale.Api.Controllers
{
    [Route("")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult<string> Get() => "Sale API";
    }
}
