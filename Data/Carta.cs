using Color = Microsoft.Maui.Graphics.Color;

namespace BurroCartas.Data
{
    public class Carta
    {
        public int Id { get; set; }
        public string Simbolo { get; set; }
        public string Tipo { get; set; }
        public string Cor { get; set; }
    }
}