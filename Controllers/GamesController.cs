using Microsoft.AspNetCore.Mvc;

namespace testapi.Controllers;

[ApiController]
[Route("[controller]")]

public class GamesController : ControllerBase
{
    private static List<Game> games;

// demo has this below methods  I cant imagine why the order would matter though keep it in mind
   public class Game{
        public int id { get; set; }
        public string? teamOneName { get; set; }
        public string? teamTwoName { get; set; }
        public int winner { get; set; } 

   } 
    List<Game> PopulateGames(){
        return new List<Game>
        {
            new Game{
               id = 1,
               teamOneName="London",
               teamTwoName="Cardif",
               winner =1  
            },
             new Game{
               id = 2,
               teamOneName="Leeds",
               teamTwoName="London",
               winner =2  
            },
             new Game{
               id = 3,
               teamOneName="London",
               teamTwoName="Manchester",
               winner =1  
            },
        };
    }

    private readonly ILogger<GamesController> _logger;

    public GamesController(ILogger<GamesController> logger)
    {
        games = PopulateGames();
        _logger = logger;
    }

    [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAll()
            {
                return Ok(games);
            }
    [HttpGet("{id}")]
         public ActionResult<Game> Get(int id)
            {
                var pickedGame = games.FirstOrDefault(g => g.id == id);
                if (pickedGame == null)
                {
                    return NotFound();
                }
                return Ok(pickedGame);
            }
    
    [HttpDelete]
        public ActionResult<IEnumerable<Game>> Delete( int id)
            {
                var game = games.FirstOrDefault(g => g.id == id);
                if (game == null)
                {
                    return NotFound();
                }
                games.Remove(game);
                return Ok(games);
            }

    [HttpPost]
        public IEnumerable<Game>  AddGame( Game game)
            {
                games.Add(game);
                return games;
            }
}