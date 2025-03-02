namespace DesafioBenner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElementManager manager = new(8);

            manager.Connect(1, 2);
            Console.WriteLine($"Validando a conexão entre 1 e 2: {manager.Query(1, 2)}");

            manager.Connect(2, 4);
            manager.Connect(1, 6);
            manager.Connect(2, 6);
            manager.Connect(5, 8);

            manager.Connect(4, 7);

            manager.Connect(4, 7);
            Console.WriteLine($"Validando a conexão entre 4 e 7: {manager.Query(4, 7)}");

            manager.Disconnect(4, 7);
            Console.WriteLine($"Validando a conexão entre 4 e 7: {manager.Query(4, 7)}");

            Console.WriteLine($"Validando o nível de conexão entre {manager.LevelConnetion(1, 4)}");
        }
    }
}
