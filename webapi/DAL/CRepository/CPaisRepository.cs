using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.Database.Entities;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.CRepository
{
    public class CPaisRepository : IPaisRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        private readonly IMemoryCache _memoryCache; 
        private const string Paises_Key = "Paises";
        public CPaisRepository(EkwatisoDbContext dbContext, IMemoryCache memoryCache )
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }

        public async Task<Dto_Resposta> ApagarPais(int id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {
                TbPais? paisExistente = await _dbContext.TbPaises.FirstOrDefaultAsync(p => p.Id == id);
                if(paisExistente != null)
                {
                    _dbContext.TbPaises.Remove(paisExistente);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Pais apagado com sucesso";
                    resposta.sucess = true;
                }
                else
                {
                    resposta.mensagem = "Falha: Pais não foi encontrado";
                    resposta.sucess = true;
                }
            }
            catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro durante a atualização. Detalhes: {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> AtualizarPais(int id, Dto_Pais pais)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            if(pais == null)
            {
                resposta.mensagem = "Falha: Objecto de pais nulo";
                resposta.sucess = false;
            }

            try
            {
                TbPais paisExistente = await _dbContext.TbPaises.FirstOrDefaultAsync(p => p.Id == id);
                if(paisExistente != null)
                {
                    paisExistente.Nome = pais.Nome;

                    _dbContext.TbPaises.Update(paisExistente);
                    await _dbContext.SaveChangesAsync();


                    resposta.mensagem = "Sucesso: Pais atualizado com sucesso";
                    resposta.sucess = true;
                }
                else
                {
                    resposta.mensagem = "Falha: Pais não encontrado";
                    resposta.sucess = false;
                }
            }
            catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro durante a atualização. Detalhes: {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> CadastrarPais(Dto_Pais pais)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            if(pais == null)
            {
                resposta.mensagem = "Falha: Objecto de pais nulo";
                resposta.sucess = false;
                return resposta;
            }

            try
            {
                bool paisExistente = await _dbContext.TbPaises.AnyAsync(x => x.Nome == pais.Nome); 
                if(!paisExistente)
                {
                    TbPais tbPais = new TbPais
                    {
                        Nome = pais.Nome
                    };

                    await _dbContext.TbPaises.AddAsync(tbPais);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Pais cadastrado com sucesso";
                    resposta.sucess = true;
                }else
                {
                    resposta.mensagem = "Falha: Já existe um pais com esse nome";
                    resposta.sucess = false;
                }
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro durante o cadastramento. Detalhes:{ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> TodosPaises()
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {
                if(_memoryCache.TryGetValue(Paises_Key, out ICollection<TbPais> paises))
                {
                    resposta.resposta = paises!.Select(p => p.Nome);
                    resposta.mensagem = "Sucesso: Consultado todos o paises com sucesso";
                    resposta.sucess = true;
                    return resposta;
                }
                ICollection<TbPais> paisesExistentes = await _dbContext.TbPaises.ToListAsync();
                if(paisesExistentes!=null)
                {
                    _memoryCache.Set(Paises_Key, paisesExistentes, TimeSpan.FromHours(1));
                }
                resposta.resposta = paisesExistentes!.Select(p => p.Nome);
                resposta.mensagem = "Sucesso: Consultado todos o paises com sucesso";
                resposta.sucess = true;
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro durante a consulta de todos os paises. Detalhes:{ex.Message}";
                resposta.sucess = false;
            }   
            return resposta;
        }
    }
}
