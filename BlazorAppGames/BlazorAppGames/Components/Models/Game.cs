using System.ComponentModel.DataAnnotations;

namespace BlazorAppGames.Components.Models;

public class Game
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    [DataType(DataType.Date)]
    public DateTime? RelaseDate { get; set; }
    public string? Developer {  get; set; }
    public string? Image { get; set; }
    public string? YTUrl { get; set; }
    public int? NumberOfRates { get; set; }

    public float? Rate { get; set; }
}