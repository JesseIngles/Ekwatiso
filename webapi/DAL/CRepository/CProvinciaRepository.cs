using Microsoft.EntityFrameworkCore;
using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.Database.Entities;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;

namespace webapi.DAL.CRepository
{
    public class CProvinciaRepository : IProvinciaRepository
    {
        private readonly EkwatisoDbContext _dbContext;
        public CProvinciaRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dto_Resposta> ApagarProvincia(int id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {
                TbProvincia? provinciaExistente = await _dbContext.TbProvincias.FirstOrDefaultAsync(p => p.Id == id);
                if (provinciaExistente != null)
                {
                    _dbContext.TbProvincias.Remove(provinciaExistente);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Provincia apagada com sucesso";
                    resposta.sucess = true;
                }
                else
                {
                    resposta.mensagem = "Falha: Provincia não encontrada";
                    resposta.sucess = true;
                }
            }
            catch (Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro durante a atualização. Detalhes: {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> AtualizarProvincia(int id, Dto_Provincia provincia)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            if (provincia == null)
            {
                resposta.mensagem = "Falha: Objecto de provincia nulo";
                resposta.sucess = false;
            }

            try
            {
                TbProvincia? provinciaExistente = await _dbContext.TbProvincias.FirstOrDefaultAsync(p => p.Id == id);
                if (provinciaExistente != null)
                {
                    provinciaExistente.Nome = provincia.Nome;
                    provinciaExistente.Pais = await _dbContext.TbPaises.FirstOrDefaultAsync(x => x.Id == provincia.PaisId);
                    _dbContext.TbProvincias.Update(provinciaExistente);
                    await _dbContext.SaveChangesAsync();


                    resposta.mensagem = "Sucesso: Provincia atualizado com sucesso";
                    resposta.sucess = true;
                }
                else
                {
                    resposta.mensagem = "Falha: Provincia não encontrada";
                    resposta.sucess = false;
                }
            }
            catch (Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro durante a atualização. Detalhes: {ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> CadastrarProvincia(Dto_Provincia provincia)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            if (provincia == null)
            {
                resposta.mensagem = "Falha: Objecto de pais nulo";
                resposta.sucess = false;
                return resposta;
            }

            try
            {
                bool provinciaExistente = await _dbContext.TbProvincias.AnyAsync(x => x.Nome == provincia.Nome);
                TbPais? paisExistente = await _dbContext.TbPaises.FirstOrDefaultAsync(x => x.Id == provincia.PaisId);
                if (!provinciaExistente && paisExistente != null)
                {
                    TbProvincia tbProvincia = new TbProvincia
                    {
                        Nome = provincia.Nome,
                        Pais = paisExistente
                    };

                    await _dbContext.TbProvincias.AddAsync(tbProvincia);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Provincia cadastrada com sucesso";
                    resposta.sucess = true;
                }
                else
                {
                    resposta.mensagem = "Falha: Já existe uma provincia com esse nome";
                    resposta.sucess = false;
                }
            }
            catch (Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro durante o cadastramento. Detalhes:{ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }

        public async Task<Dto_Resposta> TodosProvincias(int id)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            try
            {

                ICollection<TbProvincia> provinciasExistentes = await _dbContext.TbProvincias.Where(x => x.Pais.Id == id).ToListAsync();
                resposta.resposta = provinciasExistentes.Select(p => new {p.Id, p.Nome});
                resposta.mensagem = "Sucesso: Consultado todas as provincias com sucesso";
                resposta.sucess = true;
            }
            catch (Exception ex)
            {
                resposta.mensagem = $"Falha: Houve um erro durante a consulta de todos as provincias. Detalhes:{ex.Message}";
                resposta.sucess = false;
            }
            return resposta;
        }
    }
}
