namespace JantarFilosofos;

public class Filosofo
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public Mesa Mesa { get; private set; }
    public StatusFilosofo Status { get; set; } = StatusFilosofo.Pensando;

    public Filosofo(int id, string nome, Mesa mesa)
    {
        Id = id;
        Nome = nome;
        Mesa = mesa;
    }

    public void InicieJantar()
    {
        //while (true)
        //{
        Pense();
        PegueGarfo();
        Coma();
        DevolvaGarfo();
        //}
    }

    public void Pense()
    {
        Status = StatusFilosofo.Pensando;
        Thread.Sleep(2000);
    }

    public void PegueGarfo()
    {
        int posicaoFilosoAtual = Id - 1;
        Mesa.PegueGarfo(posicaoFilosoAtual);
    }

    public void Coma()
    {
        Status = StatusFilosofo.Comendo;
        Thread.Sleep(2000);
    }

    public void DevolvaGarfo()
    {
        int posicaoFilosoAtual = Id - 1;
        Mesa.LibereGarfos(posicaoFilosoAtual);
    }
}

public enum StatusFilosofo
{
    Pensando,
    ComFome,
    Comendo,
}
