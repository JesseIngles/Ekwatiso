namespace webapi.DAL.Database.Entities
{
    public class TbPais
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<TbProvincia> Provincias { get; set; }
    }
}
