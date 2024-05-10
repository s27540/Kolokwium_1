using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Client
{
    public int IdClient { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
}