using Microsoft.EntityFrameworkCore;
using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.Database.Entities;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;
using webapi.Services;

namespace webapi.DAL.CRepository
{
    public class CCampanhaRepository : ICampanhaRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        public CCampanhaRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dto_Resposta> ApagarCampanha(long id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {
                TbCampanha? campanhaExistente = await _dbContext.TbCampanhas.FirstOrDefaultAsync(c => c.Id == id);
                if(campanhaExistente!=null)
                {
                    _dbContext.TbCampanhas.Remove(campanhaExistente);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Campanha apagada com sucesso";
                    resposta.sucess = true;
                }else 
                {
                    resposta.mensagem = "Falha: Campanha não foi encontrada";
                    resposta.sucess = true;
                }
            }
            catch (System.Exception ex)
            {
                resposta.mensagem = "Falha: Houve um erro durante a remoção. Detalhes: {ex.Message}";
                resposta.sucess = true;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> AtualizarCampanha(long id, Dto_Campanha campanha)
        {
            Dto_Resposta resposta = new Dto_Resposta();

            if (campanha == null)
            {
                resposta.mensagem = "Falha: Objecto de campanha nulo";
                resposta.sucess = false;
            }

            try 
            {
                TbCampanha? campanhaExistente = await _dbContext.TbCampanhas.FirstOrDefaultAsync(c => c.Id == id);  
                if(campanhaExistente != null)
                {
                    campanhaExistente.meta = campanha.meta;
                    campanhaExistente.Data = DateTime.Now;
                    campanhaExistente.Fotografias = campanha.Fotografias;

                    _dbContext.TbCampanhas.Update(campanhaExistente);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Campanha atualizada com sucesso";
                    resposta.sucess = true;

                }else 
                {
                    resposta.mensagem = "Falha: Campanha não encontrada";
                    resposta.sucess = false;
                }
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro ao realizar esta operação. Detalhes {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> CriarCampanha(Dto_Campanha campanha)
        {
            Dto_Resposta resposta = new Dto_Resposta();

            if (campanha == null)
            {
                resposta.mensagem = "Falha: Objecto de campanha nulo";
                resposta.sucess = false;
            }

            try 
            {
                TbUser usuarioExistente = await _dbContext.TbUsers.FirstOrDefaultAsync(u => u.Id == campanha.AutorId);
                bool campanhaExistente = await _dbContext.TbCampanhas.AnyAsync(c => c.Titulo == campanha.Titulo);  
                if(!campanhaExistente && usuarioExistente != null)
                {
                    int ultimoId = _dbContext.TbCampanhas.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                    TbCampanha novaCampanha = new TbCampanha
                    {
                        Autor = usuarioExistente,
                        Categoria = await _dbContext.TbCategorias.FirstAsync(c => c.Id == campanha.CategoriaId),
                        Data = campanha.Data,
                        meta = campanha.meta,
                        Titulo = campanha.Titulo,
                        Fotografias = campanha.Fotografias.Select(imagem => ImageService.UploaImageCampanhas(ultimoId + 1, imagem).Result).ToList(),
                        Provincia = await _dbContext.TbProvincias.FirstAsync(p => p.Id == campanha.ProvinciaId)
                    };


                    await _dbContext.TbCampanhas.AddAsync(novaCampanha);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Campanha criada com sucesso";
                    resposta.sucess = true;
                }else
                {
                    resposta.mensagem = "Falha: Campanha não encontrada";
                    resposta.sucess = false;
                }
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro ao realizar esta operação. Detalhes {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> TodasCampanhas()
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {
                ICollection<TbCampanha> todasCampanhas = await _dbContext.TbCampanhas.ToListAsync();
                resposta.resposta = todasCampanhas.Select(c => new {
                    c.Id,
                    c.Data,
                    c.meta,
                    c.Fotografias,
                    c.Provincia,
                    c.Autor.NomeCompleto,
                    c.Categoria.Nome
                });
                resposta.sucess = true;
                resposta.mensagem = "Sucesso: Todas as campanhas recolhidas";
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro ao realizar esta operação. Detalhes {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> TodasCampanhasProvincia(long id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {
                ICollection<TbCampanha> todasCampanhas = await _dbContext.TbCampanhas.Where(t => t.Provincia.Id == id).ToListAsync();
                resposta.resposta = todasCampanhas.Select(c => new {
                    c.Id,
                    c.Data,
                    c.meta,
                    c.Fotografias,
                    c.Provincia,
                    c.Autor.NomeCompleto,
                    c.Categoria.Nome
                });
                resposta.sucess = true;
                resposta.mensagem = "Sucesso: Todas as campanhas recolhidas";
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro ao realizar esta operação. Detalhes {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }
    }
}
