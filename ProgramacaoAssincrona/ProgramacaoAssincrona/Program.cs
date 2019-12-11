using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramacaoAssincrona
{
    class Program
    {
        static void Main(string[] args)
        {          
            Mostrar().Wait();
            Console.ReadKey();
        }
      
        static async Task Mostrar()
        {
            await Aguardar();
            Console.WriteLine($"Hora Atual : { DateTime.Now.TimeOfDay:t}"); 
        }
        static async Task Aguardar()
        {
            Console.WriteLine("Aguardando...");
            await Task.Delay(5000);
        }
    }
}
