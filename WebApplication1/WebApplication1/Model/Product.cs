using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class Product
{
    public int IdProduct { get; set; }
    public string Name { get; set; }
    public decimal IdClient { get; set; }
}