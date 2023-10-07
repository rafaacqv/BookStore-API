using System.ComponentModel.DataAnnotations;

namespace PUC.PosGraduacao.BookStore.Domain.DTO
{
  public class RegisterDTO
  {
    [Required]
    public string DisplayName { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$",
     ErrorMessage = @"Password must have at least 6 characters, 1 number, 1 UpperCase, 1 LowerCase and 1 non alphanumeric")]
    public string Password { get; set; }
  }
}
