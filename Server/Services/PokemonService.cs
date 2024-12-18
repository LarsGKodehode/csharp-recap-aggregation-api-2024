using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server.Services;

public class PokemonLink
{
  public string? name { get; set; }
  public string? url { get; set; }
}

public class PokemonListResponse
{
  public int count { get; set; }
  public string? next { get; set; }
  public string? previous { get; set; }
  public List<PokemonLink> results { get; set; } = new List<PokemonLink>();
}


public class Pokemon
{
  public required string Name;
}

public class PokemonService
{
  public async void GetPokemons()
  {
    string url = "https://pokeapi.co/api/v2/pokemon";

    var client = new System.Net.Http.HttpClient();
    var response = await client.GetAsync(url);
    var jsonString = await response.Content.ReadAsStringAsync();

    var pokemonList = JsonSerializer.Deserialize<PokemonListResponse>(jsonString);

    foreach (var pokemon in pokemonList.results)
    {
      Console.WriteLine($"Pokemon: {pokemon.name}, url: {pokemon.url}");
    }
  }
}
