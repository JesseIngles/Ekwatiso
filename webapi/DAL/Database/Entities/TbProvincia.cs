namespace webapi.DAL.Database.Entities
{
    public class TbProvincia
    {
       public int Id { get; set; }
       public string Nome { get; set; }
       public virtual TbPais Pais { get; set; }
    }
}
