using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DAL.IRepository;
using webapi.DTO.Outbound;

namespace webapi.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/v1/[controller]")]
    public class DoacaoController : Controller
    {
        private readonly IDoacaoRepository _doacaoRepository;
        public DoacaoController(IDoacaoRepository doacaoRepository)
        {
            _doacaoRepository = doacaoRepository;
        }
        [Authorize()]
        [HttpPost("FazerDoação")]
        public async Task<ActionResult> FazerDoacao()
        {
            Dto_Resposta resposta = new Dto_Resposta();
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        
    }
}
