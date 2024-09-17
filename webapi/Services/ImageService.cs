namespace webapi.Services {
  public class ImageService
  {
    public async static Task<string> UploaImageCampanhas(int id, string imagemBase64)
    {
      string directorio = $"webapi/Resources/Campanhas/{id}";
      
      if(imagemBase64.Contains(","))
      {
        imagemBase64 = imagemBase64.Split(",")[1];
      }

      byte[] bytes = Convert.FromBase64String(imagemBase64);

      if(!Directory.Exists(directorio))
      {
        Directory.CreateDirectory(directorio);
      }

      string filename = Guid.NewGuid().ToString() + ".png";
      string filepath = Path.Combine(directorio, filename);
      
      await File.WriteAllBytesAsync(filepath, bytes); 
      return "";
    }
  }
}