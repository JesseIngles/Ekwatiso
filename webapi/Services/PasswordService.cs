namespace webapi.Services
{
  public class PasswordService 
  {
    public static string HashPassword(string password)
    {
      var hashedPassword = BC.EnhancedHashPassword(password, 13);
      return hashedPassword;
    }

    public static bool VerifyPassword(string inputPassword, string password)
    {
      return BC.Verify(inputPassword, password) ? true : false;
    }
  }
}