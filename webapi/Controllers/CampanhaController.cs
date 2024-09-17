using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/v1/[controller]")]
    public class CampanhaController : Controller
    {
        private readonly ICampanhaRepository _campanhaRepository;
        public CampanhaController(ICampanhaRepository campanhaRepository)
        {
            _campanhaRepository = campanhaRepository;
        }
        
        [AllowAnonymous]
        [HttpGet("TodasCampanhas")]
        public async Task<ActionResult> TodasCampanhas()
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _campanhaRepository.TodasCampanhas();
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        } 

        [AllowAnonymous]
        [HttpPost("CriarCampanha")]
        public async Task<ActionResult> CriarCampanha([FromBody] Dto_Campanha campanha)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _campanhaRepository.CriarCampanha(campanha);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPost("AtualizarCampanha")]
        public async Task<ActionResult> AtualizarCampanha(long id, [FromBody] Dto_Campanha campanha)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _campanhaRepository.AtualizarCampanha(id, campanha);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPost("ApagarCampanha")]
        public async Task<ActionResult> ApagarCampanha(long id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _campanhaRepository.ApagarCampanha(id);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpGet("TodasCampanhasProvincia")]
        public async Task<ActionResult> TodasCampanhasProvincia(long id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _campanhaRepository.TodasCampanhasProvincia(id);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        

    }
}
