using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.Database.Entities;
using webapi.DAL.IRepository;
using webapi.DTO.Inbound;
using webapi.DTO.Outbound;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace webapi.DAL.CRepository
{
    public class CUserRepository : IUserRepository
    {
        private readonly EkwatisoDbContext _dbContext;

        public CUserRepository(EkwatisoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Dto_Resposta> AtualizarContaUsuario(int v, Dto_UpdateUsuario usuario)
        {
            Dto_Resposta resposta = new Dto_Resposta();
            if(usuario == null)
            {
                resposta.mensagem = "Falha: Objeto de usuário nulo.";
                resposta.sucess = false;
                return resposta;
            }

            try
            {
                TbUser? usuarioExistente = await _dbContext.TbUsers.FirstOrDefaultAsync(u => u.Id == v);
                if(usuarioExistente != null)
                {
                    usuarioExistente.NomeCompleto = usuario.NomeCompleto;
                    usuario.Email = usuario.Email;
                    usuario.NumeroIdentificacao = usuario.NumeroIdentificacao;
                    usuarioExistente.Senha = usuario.Senha;

                    //Atualizar o banco de dados
                    _dbContext.TbUsers.Update(usuarioExistente);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Conta de usuário atualizada com sucesso.";
                    resposta.sucess = true;
                }else
                {
                    resposta.mensagem = "Falha: Conta de usuário não encontrada";
                    resposta.sucess = false;
                }
            }catch(Exception ex)
            {
                resposta.mensagem = $"Falha: Ocorreu um erro ao atualizar a conta de usuário. Detalhes: {ex.Message}";
                resposta.sucess = false;
            }

            return resposta;
        }

        public async Task<Dto_Resposta> CriarContaUsuario(Dto_Usuario usuario)
        {
            Dto_Resposta resposta = new Dto_Resposta();

            if (usuario == null)
            {
                resposta.mensagem = "Falha: Objeto de usuário nulo.";
                resposta.sucess = false;
                return resposta;
            }

            try
            {
                bool usuarioExistente = await _dbContext.TbUsers.AnyAsync(u => u.NumeroIdentificacao == usuario.NumeroIdentificacao);
                if (!usuarioExistente)
                {
                    TbUser tbUser = new TbUser
                    {
                        Email = usuario.Email,
                        NomeCompleto = usuario.NomeCompleto,
                        NumeroIdentificacao = usuario.NumeroIdentificacao,
                        Telefone = usuario.Telefone,
                        Senha = usuario.Senha
                    };

                    await _dbContext.TbUsers.AddAsync(tbUser);
                    await _dbContext.SaveChangesAsync();

                    resposta.mensagem = "Sucesso: Conta de usuário criada com sucesso.";
                    resposta.sucess = true;
                }
                else
                {
                    resposta.mensagem = "Falha: Já existe um usuário com este número de identificação.";
                    resposta.sucess = false;
                }
            }
            catch (Exception ex)
            {
                resposta.mensagem = $"Falha: Ocorreu um erro ao criar a conta do usuário. Detalhes: {ex.Message}";
                resposta.sucess = false;
                
            }

            return resposta;
        }
    }
}
