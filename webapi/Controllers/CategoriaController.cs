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
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;   
        }
        
        [AllowAnonymous]
        [HttpPost("CriarCategoria")]
        public async Task<ActionResult> CriarCategoria(Dto_Categoria categoria)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _categoriaRepository.CriarCategoria(categoria);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPost("AtualizarCategoria")]
        public async Task<ActionResult> AtualizarCategoria(long id, Dto_Categoria categoria)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _categoriaRepository.AtualizarCategoria(id, categoria);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPost("RemoverCategoria")]
        public async Task<ActionResult> RemoverCategoria(long id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _categoriaRepository.RemoverCategoria(id);
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

        [AllowAnonymous]
        [HttpPost("TodasCategorias")]
        public async Task<ActionResult> TodasCategorias()
        {
            Dto_Resposta resposta = new Dto_Resposta();
            resposta = await _categoriaRepository.TodasCategorias();
            return (resposta.sucess) ? Ok(resposta) : NotFound(resposta);
        }

    }
}
