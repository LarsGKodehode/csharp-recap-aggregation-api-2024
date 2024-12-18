using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
  PokemonService pokemonService;

  public PokemonController(PokemonService pokemonService)
  {
    this.pokemonService = pokemonService;
  }

  [HttpGet]
  public string Get()
  {
    pokemonService.GetPokemons();

    return "Hello World";
  }
}