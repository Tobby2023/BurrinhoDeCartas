using Microsoft.AspNetCore.Components;

namespace BurroCartas.Data;

//dianganaf12@gmail.com
//Diangana12
public class JogadorIA : Carta
{
    public Carta[] Carta { get; set; } = new Carta[2];
    public List<Carta> Cartas { get; set; }
    private bool Estado { get; set; } = false;
    public bool SuaVez { get; set; }

    public JogadorIA()
    {
        Cartas = new List<Carta>();
    }

    public bool Chupar(List<Carta> Chupilingo)
    {
        if (Chupilingo.Count > 0)
        {
            Carta crt;
            do
            {
                crt = Chupilingo.ElementAt(0);
                Cartas.Add(crt);
                Chupilingo.Remove(crt);
            } while ((Chupilingo.Count > 0) && (crt.Tipo != Carta[0].Tipo));

            if (crt.Tipo != Carta[0].Tipo)
            {
                Cartas.Add(Carta[0]);
                SuaVez = !SuaVez;
                Carta[0] = null;
                Carta[1] = null;
            }
            else
            {
                Carta[1] = crt;
                Cartas.Remove(crt);
            }
        }
        else
        {
            Cartas.Add(Carta[0]);
            SuaVez = !SuaVez;
            Carta[0] = null;
            Carta[1] = null;
        }
        return SuaVez;
    }

    public async Task<bool> Jogar(List<Carta> Chupilingo)
    {
        Carta carta;
        if (Carta[0] is not null)
        {
            var cart = Cartas.FindAll(c => c.Tipo == Carta[0].Tipo);
            carta = (cart.Count == 0 ? null : cart[(int)(cart.Count / 2)]);
            if (carta is null)
            {
                var resul = Chupar(Chupilingo);
            }
            else if (carta.Tipo == Carta[0].Tipo)
            {
                Carta[1] = carta;
                Cartas.Remove(carta);
            }
            //await Avaliar();
        }
        else
        {
            carta = Cartas.ElementAt(0);
            Carta[1] = carta;
            Cartas.Remove(carta);
            SuaVez = !SuaVez;
        }
        return SuaVez;
    }
    private async Task Avaliar(List<Carta> Chupilingo, List<Carta> CartasTuas)
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        if (CartasTuas.Count == 0)
        {
            await App.Current.MainPage.DisplayAlert("Fim Do Jogo", "Você Ganhou!!!", "OK");
            Carta[0] = null;
            Carta[1] = null;
        }
        else if (Cartas.Count == 0)
        {
            await App.Current.MainPage.DisplayAlert("Fim Do Jogo", "Você Perdeu!!!", "OK");
            Carta[0] = null;
            Carta[1] = null;
        }
        else
        {
            if ((Carta[0] is null) || (Carta[1] is null))
            {
                if (!SuaVez)
                    await Jogar(Chupilingo);
            }
            else if (Carta[0].Id > Carta[1].Id)
            {
                SuaVez = true;
                Carta[0] = null;
                Carta[1] = null;
            }
            else
            {
                SuaVez = false;
                Carta[0] = null;
                Carta[1] = null;
                await Jogar(Chupilingo);
            }
        }
    }
}
