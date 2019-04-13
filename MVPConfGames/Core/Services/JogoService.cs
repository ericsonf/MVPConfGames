using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using MVPConfGames.Core.Entities;
using MVPConfGames.Core.Interfaces;
using MVPConfGames.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVPConfGames.Core.Services
{
    public class JogoService : IJogo
    {
        private readonly MVPConfGamesContext _context;

        public JogoService(MVPConfGamesContext context)
        {
            _context = context;
        }

        public async Task<List<Jogo>> Get(int id)
        {
            return await _context.Jogo.Where(j => j.ConsoleId == id).Include(c => c.Console).OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<string> UploadBlobFileAsync(IFormFile file)
        {
            var storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("MVPConfGamesStorageConn"));
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("images");
            await container.CreateIfNotExistsAsync();
            var blockBlob = container.GetBlockBlobReference(file.FileName);

            using (var fileStream = file.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(fileStream);
            }

            return blockBlob.Uri.ToString();
        }

        public async Task Save(Jogo jogo, IFormFile imagem)
        {
            var url = await UploadBlobFileAsync(imagem);
            jogo.Imagem = url.Replace("images", "thumbnails");
            await _context.AddAsync(jogo);
            await _context.SaveChangesAsync();
        }
    }
}
