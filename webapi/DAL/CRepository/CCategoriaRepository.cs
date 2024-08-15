using Microsoft.EntityFrameworkCore;
using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.Database.Entities;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.CRepository
{
    public class CCategoriaRepository : ICategoriaRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        public CCategoriaRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dto_Resposta> AtualizarCategoria(long id, Dto_Categoria categoria)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            if(categoria == null)
            {
                resposta.mensagem = "Falha: Objecto categoria vazio";
                resposta.sucess = false;
            }

            try
            {
                TbCategoria? categoriaExistente = await _dbContext.TbCategorias.FirstOrDefaultAsync(c => c.Id == id);
                if(categoriaExistente != null)
                {
                    
                    categoriaExistente.Nome = categoria.Nome;
                    
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Categoria atualizada com sucesso";
                    resposta.sucess = true;
                }else
                {
                    resposta.mensagem = "Falha: Categoria existente";
                    resposta.sucess = false;
                }
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro ao realizar esta operação. Detalhes {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> CriarCategoria(Dto_Categoria categoria)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            if(categoria == null)
            {
                resposta.mensagem = "Falha: Objecto categoria vazio";
                resposta.sucess = false;
            }

            try
            {
                bool categoriaExistente = await _dbContext.TbCategorias.AnyAsync(c => c.Nome == categoria.Nome);
                if(!categoriaExistente)
                {
                    TbCategoria novaCategoria = new TbCategoria
                    {
                        Nome = categoria.Nome
                    };

                    await _dbContext.TbCategorias.AddAsync(novaCategoria);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Categoria cadastrada com sucesso";
                    resposta.sucess = true;
                }else
                {
                    resposta.mensagem = "Falha: Categoria existente";
                    resposta.sucess = false;
                }
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro ao realizar esta operação. Detalhes {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> RemoverCategoria(long id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {
                TbCategoria? categoriaExistente = await _dbContext.TbCategorias.FirstOrDefaultAsync(c => c.Id == id);
                if(categoriaExistente != null)
                {
                    _dbContext.TbCategorias.Remove(categoriaExistente);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Categoria apagada com sucesso";
                    resposta.sucess = true;
                }else
                {
                    resposta.mensagem = "Falha: Categoria não encontrada";
                    resposta.sucess = false;
                }
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro ao realizar esta operação. Detalhes {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> TodasCategorias()
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {
                ICollection<TbCategoria> TodasCategorias = await _dbContext.TbCategorias.ToListAsync();
                resposta.resposta = TodasCategorias.Select(t => new {t.Id, t.Nome});
                resposta.mensagem = "Sucesso: Todas as categorias com sucesso";
                resposta.sucess = true;
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro ao realizar esta operação. Detalhes {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }
    }
}
