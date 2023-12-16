namespace BurroCartas.Data;

public class Estado
{
    public List<string> Conhecimento { get; set; } = new();

    public void Inserir(string tipo)
    {
        var result = Conhecimento.Find(s => s == tipo);
        if (result == null)
        {
            Conhecimento.Add(tipo);
        }
    }
    public void Remover(string tipo)
    {
        Conhecimento.RemoveAll(s => s == tipo);
    }

    public Carta JogarComCarta(List<Carta> CartasTuas, List<Carta> CartasIA, Carta cartaJogada)
    {
        CartasIA = CartasIA.OrderBy(x => x.Id).ToList();
        var CartaIA = CartasIA;

        var aux = CartaIA.FindAll(c => c.Tipo == cartaJogada.Tipo);
        aux = aux.OrderBy(x => x.Id).ToList();

        if (CartasTuas.Count < 3)
        {
            if (aux.Count > 0)
            {
                var c = aux.FindAll(crt => crt.Id > cartaJogada.Id).ToList();
                if (c.Count > 0)
                {
                    c = c.OrderBy(x => x.Id).ToList();
                    return c.ElementAt(0);
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        else if (CartasTuas.Count < 5)
        {
            if(aux.Count > 0)
            {
                var c = aux.FindAll(crt => crt.Id > cartaJogada.Id).ToList();
                if (c.Count > 0)
                {
                    c = c.OrderBy(x => x.Id).ToList();
                    return c.ElementAt(0);
                }
                else
                {
                    return aux.ElementAt(0);
                }
            }
            return null;
        }
        else
        {
            return (aux.Count > 0 ? aux.ElementAt(0) : null);
        }
    }

    /// <summary>
    ///     -> Para verificar se tem menor de quatro;
    ///     -> Organizar
    /// </summary>
    /// <param name="Cartas"></param>
    /// <returns></returns>
    public Carta JogarSemCarta(List<Carta> CartasTuas, List<Carta> CartasIA)
    {
        CartasIA = CartasIA.OrderBy(x => x.Id).ToList();

        List<Carta> cartas = new List<Carta>();

        foreach (var tipo in Conhecimento)
        {
            var aux = CartasIA.FindAll(c => c.Tipo == tipo);
            cartas = (cartas.Count < aux.Count ? aux : cartas);
        }
        cartas = (cartas.Count == 0 ? CartasIA : cartas);

        if (CartasTuas.Count < 4)
        {
            if (CartasIA.Count == 3) { return CartasIA.ElementAt(1); }
            else if (CartasIA.Count == 2) { return CartasIA.ElementAt(1); }
            else
            {
                return cartas.ElementAt(0);
            }
        }
        else if (CartasTuas.Count < 5)
        {
            if (CartasIA.Count == 3) { return CartasIA.ElementAt(1); }
            else if (CartasIA.Count == 2) { return CartasIA.ElementAt(1); }
            else
            {
                return cartas.ElementAt(0);
            }
        }
        else
        {
            if (CartasIA.Count == 3) { return CartasIA.ElementAt(1); }
            else if (CartasIA.Count == 2) { return CartasIA.ElementAt(1); }
            else
            {
                return cartas.ElementAt(0);
            }
        }
    }
}