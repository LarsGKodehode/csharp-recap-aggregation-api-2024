using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonController : ControllerBase
{
  [HttpGet]
  public string Get()
  {
    return "Hello World";
  }
}