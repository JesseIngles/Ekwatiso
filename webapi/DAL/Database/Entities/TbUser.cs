namespace webapi.DAL.Database.Entities
{
    public class TbUser
    {
        public long Id { get; set; }
        public string NumeroIdentificacao { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public virtual TbProvincia Provincia { get; set; }
        public virtual ICollection<TbDoacao> Doacoes { get; set; }
        public virtual ICollection<TbCampanha> Campanhas { get; set; }r
    }
}