using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JW.POS.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ApplicationBaseController : ControllerBase
    {
       
    }
}