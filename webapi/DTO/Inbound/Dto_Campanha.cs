namespace webapi.DTO.Inbound 
{
  public class Dto_Campanha 
  {
    public long Id {get;set;}
    public string Titulo {get;set;}   
    public List<string> Fotografias { get; set; } = new List<string>();
    public decimal meta {get;set;}
    public DateTime Data {get;set;}
    public long AutorId { get; set; }
    public long CategoriaId { get; set; }
    public long ProvinciaId { get; set; }
  }
}