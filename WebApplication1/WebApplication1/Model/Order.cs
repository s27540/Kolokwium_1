using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Order
{
    public int IdOrder { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; }

    [Required]
    public DateTime CreationDate { get; set; }

    [Required]
    public int IdClient { get; set; }
}