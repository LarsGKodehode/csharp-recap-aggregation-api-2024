using System.Text.Json;
using Server.DTO;

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
  private ICacheService cache;
  public PokemonService(ICacheService cache)
  {
    this.cache = cache;
  }

  public async Task<List<PokemonDto>> GetPokemons()
  {
    string url = "https://pokeapi.co/api/v2/pokemon";
    List<PokemonDto>? pokemons = cache.Get(url);

    if (pokemons == null)
    {
      Console.WriteLine("Fetching data from 3rd party");

      var client = new System.Net.Http.HttpClient();
      var response = await client.GetAsync(url);
      var jsonString = await response.Content.ReadAsStringAsync();

      var pokemonList = JsonSerializer.Deserialize<PokemonListResponse>(jsonString);

      // Transform data from 3rd party source
      var result = pokemonList.results
        .Select(entry => new PokemonDto { name = entry.name ?? "unknown", url = entry.url ?? "NA" })
        .ToList();

      cache.Set(url, result);
      pokemons = result;
    }
    else
    {
      Console.WriteLine("Usign Cache");
    }

    return pokemons;
  }
}
