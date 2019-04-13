using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVPConfGames.Core.Entities;
using MVPConfGames.Core.Interfaces;

namespace MVPConfGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IJogo _service;

        public GamesController(IJogo service)
        {
            _service = service;
        }

        // GET api/games/1
        [HttpGet("{id}")]
        public async Task<List<Jogo>> Get(int id)
        {
            var jogos = await _service.Get(id);
            return jogos;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Jogo jogo, IFormFile imagem)
        {
            await _service.Save(jogo, imagem);
            return Ok();
        }
    }
}