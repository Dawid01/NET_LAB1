﻿namespace Lab;
using System.Text.Json.Serialization;

public class Game
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }

    [JsonPropertyName("short_description")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("game_url")]
    public string GameUrl { get; set; }

    [JsonPropertyName("genre")]
    public string Genre { get; set; }

    [JsonPropertyName("platform")]
    public string Platform { get; set; }

    [JsonPropertyName("publisher")]
    public string Publisher { get; set; }

    [JsonPropertyName("developer")]
    public string Developer { get; set; }

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, " +
               $"Title: {Title}, " +
               $"Thumbnail: {Thumbnail}, " +
               $"ShortDescription: {ShortDescription}, " +
               $"GameUrl: {GameUrl}, " +
               $"Genre: {Genre}, " +
               $"Platform: {Platform}, " +
               $"Publisher: {Publisher}, " +
               $"Developer: {Developer}, " +
               $"ReleaseDate: {ReleaseDate}";
    }
}