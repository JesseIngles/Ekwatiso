namespace webapi.DAL.Database.Entities
{
  public class TbCampanha
  {
    public int Id {get;set;}
    public string Titulo {get;set;}   
    public virtual List<string>? Fotografias { get; set; } 
    public decimal meta {get;set;}
    public DateTime Data {get;set;}
    public virtual TbUser Autor { get; set; }
    public virtual TbCategoria Categoria { get; set; }
    public virtual TbProvincia Provincia { get; set; }
    public virtual ICollection<TbDoacao> Doacoes {get;set;}
  }
}