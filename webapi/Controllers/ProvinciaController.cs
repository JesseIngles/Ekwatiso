using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/[controller]")]
    public class ProvinciaController : Controller
    {
        private readonly IProvinciaRepository _provinciaRepository;
        public ProvinciaController(IProvinciaRepository provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
        }

        [AllowAnonymous]
        [HttpPost("CadastrarProvincia")]
        public async Task<ActionResult> CadastrarPais(Dto_Provincia provincia)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _provinciaRepository.CadastrarProvincia(provincia);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPut("AtualizarProvincia")]
        public async Task<ActionResult> AtualizarPais(int id, Dto_Provincia provincia)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _provinciaRepository.AtualizarProvincia(id, provincia);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpGet("TodosProvincias")]
        public async Task<ActionResult> TodosProvincias(int id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _provinciaRepository.TodosProvincias(id);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpDelete("ApagarProvincia")]
        public async Task<ActionResult> ApagarPais(int id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _provinciaRepository.ApagarProvincia(id);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }
    }
}
