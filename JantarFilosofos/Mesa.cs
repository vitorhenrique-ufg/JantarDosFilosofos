namespace JantarFilosofos;

public class Mesa
{
    public List<Filosofo> Filosofos { get; private set; } = new();

    public Mesa(List<Filosofo> filosofos)
    {
        Filosofos = filosofos;
    }

    public void PegueGarfos(int posicaoFilosoAtual)
    {
        lock (this)
        {
            int esquerda = posicaoFilosoAtual - 1 < 0 ? 4 : posicaoFilosoAtual - 1;
            int direita = posicaoFilosoAtual + 1 == 5 ? 0 : posicaoFilosoAtual + 1;

            Filosofo filosofoDireita = Filosofos.ElementAt(direita);
            Filosofo filosofoEsquerda = Filosofos.ElementAt(esquerda);

            Filosofo filosofoAtual = Filosofos.ElementAt(posicaoFilosoAtual);
            filosofoAtual.Status = StatusFilosofo.ComFome;
            while (filosofoDireita.Status == StatusFilosofo.Comendo || filosofoEsquerda.Status == StatusFilosofo.Comendo)
            {
                Monitor.Wait(this); //Espera    
            }

            filosofoAtual.Status = StatusFilosofo.Comendo;
            Console.WriteLine($"Id: {Filosofos[posicaoFilosoAtual].Id} - [ {string.Join(" ", Filosofos.Select(f => f.Status))} ]");
        }
    }

    public void LibereGarfos(int posicaoFilosoAtual)
    {
        lock(this)
        {
            Monitor.PulseAll(this); //Libera

            Filosofo filosofoAtual = Filosofos.ElementAt(posicaoFilosoAtual);
            filosofoAtual.Status = StatusFilosofo.Pensando;
            Console.WriteLine($"Id: {filosofoAtual.Id} - {{ {string.Join(" ", Filosofos.Select(f => f.Status))} }}");
        }
    }
}

