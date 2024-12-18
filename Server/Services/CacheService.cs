using Server.DTO;

namespace Server.Services;

public interface ICacheService
{
  List<PokemonDto>? Get(string key);
  void Set(string key, List<PokemonDto> pokemons);
}

public class CacheService : ICacheService
{
  Dictionary<string, List<PokemonDto>> cache;

  public CacheService()
  {
    cache = new Dictionary<string, List<PokemonDto>>();
  }

  public List<PokemonDto>? Get(string key)
  {
    cache.TryGetValue(key, out List<PokemonDto>? result);

    return result;
  }

  public void Set(string key, List<PokemonDto> pokemons)
  {
    cache.Add(key, pokemons);
  }
}