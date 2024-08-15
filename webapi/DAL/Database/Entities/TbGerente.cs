namespace webapi.DAL.Database.Entities
{
    public class TbGerente
    {
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string NomeCompleto { get; set; }
        public bool Admin { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<TbCampanha> Campanhas { get; set; }
    }
}
