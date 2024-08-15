namespace webapi.DAL.Database.Entities
{  public class TbCategoria 
  {
    public int Id {get;set;}
    public string Nome {get;set;}
    public virtual ICollection<TbCampanha> Campanhas {get;set;}
  }
}