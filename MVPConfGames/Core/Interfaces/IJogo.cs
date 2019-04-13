using Microsoft.AspNetCore.Http;
using MVPConfGames.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVPConfGames.Core.Interfaces
{
    public interface IJogo
    {
        Task<List<Jogo>> Get(int id);
        Task<string> UploadBlobFileAsync(IFormFile file);
        Task Save(Jogo jogo, IFormFile file);
    }
}
