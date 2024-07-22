namespace webapi.DAL.Database.Entities
{
  public class TbCampanha
  {
    public long Id {get;set;}
    public string Titulo {get;set;}   
    public List<string> Fotografias { get; set; } = new List<string>();
    public decimal meta {get;set;}
    public DateTime Data {get;set;}
    public virtual TbUser Autor { get; set; }
    public virtual TbCategoria Categoria { get; set; }
    public virtual TbProvincia Provincia { get; set; }
    public virtual ICollection<TbDoacao> Doacoes {get;set;}
  }
}