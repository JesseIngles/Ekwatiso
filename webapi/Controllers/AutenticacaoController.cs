using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
  [Authorize]
  [Controller]
  [Route("api/v1/[controller]")]
  public class AutenticacaoController : Controller
  {
    public AutenticacaoController()
    {
      
    }
  }
}