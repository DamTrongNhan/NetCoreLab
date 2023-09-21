using System.ComponentModel.DataAnnotations;
namespace NetCore5Api.Models;

public class BookModel
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [Range(0, double.MaxValue)]
    public double Price { get; set; }

    [Range(0, 100)]
    public int Quantity { get; set; }

    public string Description { get; set; }

}