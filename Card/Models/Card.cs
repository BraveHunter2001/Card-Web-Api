using System.ComponentModel.DataAnnotations;

namespace Models;

public class Card
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public Guid SerialNumber { get; set; }
    [Required]
    public string Date { get; set; }
    [Required]
    public int Cvv { get; set; }
}
