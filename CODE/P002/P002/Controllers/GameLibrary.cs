using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P002.DTOs;
using P002.Models;

namespace P002.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameLibrary : ControllerBase
    {
        private static readonly List<VideoGame> _games = new List<VideoGame>()
            {
                new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Developer = "Nintendo EPD", Publisher = "Nintendo", ReleaseYear = 2017 },
                new VideoGame { Id = 2, Title = "God of War", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment", ReleaseYear = 2018 },
                new VideoGame { Id = 3, Title = "Red Dead Redemption 2", Developer = "Rockstar Studios", Publisher = "Rockstar Games", ReleaseYear = 2018 },
                new VideoGame { Id = 4, Title = "Cyberpunk 2077", Developer = "CD Projekt Red", Publisher = "CD Projekt", ReleaseYear = 2020 },
                new VideoGame { Id = 5, Title = "Minecraft", Developer = "Mojang Studios", Publisher = "Microsoft Studios", ReleaseYear = 2011 },
                new VideoGame { Id = 6, Title = "Fortnite", Developer = "Epic Games", Publisher = "Epic Games", ReleaseYear = 2017 },
                new VideoGame { Id = 7, Title = "The Witcher 3: Wild Hunt", Developer = "CD Projekt Red", Publisher = "CD Projekt", ReleaseYear = 2015 },
                new VideoGame { Id = 8, Title = "Halo: Infinite", Developer = "343 Industries", Publisher = "Xbox Game Studios", ReleaseYear = 2021 },
                new VideoGame { Id = 9, Title = "Grand Theft Auto V", Developer = "Rockstar North", Publisher = "Rockstar Games", ReleaseYear = 2013 },
                new VideoGame { Id = 10, Title = "Elden Ring", Developer = "FromSoftware", Publisher = "Bandai Namco Entertainment", ReleaseYear = 2022 }
            };
        public GameLibrary()
        {
        }
        [HttpGet]
        public List<VideoGame> GetAllGames()
        {
            return _games;
        }
        [HttpGet("{id}")]
        public VideoGame? GetGameById(int id)
        {
            return _games.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public void CreateVideoGame([FromBody] CreateVideoGameDTO gameDTO)
        {
            VideoGame game = new VideoGame();
            game.Id = _games.Last().Id + 1;
            game.Title = gameDTO.Title;
            game.Developer = gameDTO.Developer;
            game.Publisher = gameDTO.Publisher;
            game.ReleaseYear = gameDTO.ReleaseYear;

            _games.Add(game);

        }
        [HttpPut("{id}")]
        public void UpdateVideoGame(int id, [FromBody] CreateVideoGameDTO videoGameDTO)
        {
            VideoGame game = _games.FirstOrDefault(x => x.Id == id);
            game.Title = videoGameDTO.Title;
            game.Developer = videoGameDTO.Developer;
            game.Publisher = videoGameDTO.Publisher;
            game.ReleaseYear = videoGameDTO.ReleaseYear;
        }
        [HttpDelete("{id}")]
        public void DeleteVideoGame(int id)
        {
            VideoGame videoGame = _games.FirstOrDefault(x => x.Id == id);
            _games.Remove(videoGame);
        }
    }
}
