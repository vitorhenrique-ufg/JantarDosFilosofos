using JantarFilosofos;

List<Filosofo> filosofos = new();
Mesa mesa = new(filosofos);

Filosofo filosofo1 = new(1, "Filosofo 1", mesa);
Filosofo filosofo2 = new(2, "Filosofo 2", mesa);
Filosofo filosofo3 = new(3, "Filosofo 3", mesa);
Filosofo filosofo4 = new(4, "Filosofo 4", mesa);
Filosofo filosofo5 = new(5, "Filosofo 5", mesa);

filosofos.AddRange(new Filosofo[]{ filosofo1, filosofo2, filosofo3, filosofo4, filosofo5});


new Thread(filosofo1.InicieJantar).Start();
new Thread(filosofo2.InicieJantar).Start();
new Thread(filosofo3.InicieJantar).Start();
new Thread(filosofo4.InicieJantar).Start();
new Thread(filosofo5.InicieJantar).Start();