using Microsoft.AspNetCore.Http;

namespace MVPConfGames.Core.Entities
{
    public class Jogo : BaseEntity
    {
        public string Nome { get; set; }
        public int Lancamento { get; set; }
        public string Imagem { get; set; }
        public int ConsoleId { get; set; }
        public Console Console { get; set; }
    }
}
