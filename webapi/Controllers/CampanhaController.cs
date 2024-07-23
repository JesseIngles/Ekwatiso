using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/v1/[controller]")]
    public class CampanhaController : Controller
    {
        public CampanhaController()
        {
            
        }
    }
}
