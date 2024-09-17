namespace webapi.DTO.Inbound 
{
  public class Dto_Campanha 
  {
    public string Titulo {get;set;}   
    public List<string>? Fotografias { get; set; }
    public decimal meta {get;set;}
    public DateTime Data {get;set;}
    public long AutorId { get; set; }
    public long CategoriaId { get; set; }
    public long ProvinciaId { get; set; }
  }
}