using System;
using System.Threading.Tasks;

namespace dynamodb
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cliente = new Cliente();
            cliente.Id = Guid.NewGuid().ToString();
            cliente.Nome = "Danilo";
            cliente.Email = "danilo@torneseumprogramador.com.br";
            cliente.Idade = 37;
            cliente.Telefone = "(11) 97614-4154";
            await cliente.SalvarAsync();

            // Console.WriteLine("Cliente salvo no DynamoDB");

            var cli = await ClienteDto.Find("7e5f7e68-b4ae-477b-a45f-79d7fc4cc211");
            Console.WriteLine($"===============[individual]==================");
            Console.WriteLine($"Id: {cli.Id}");
            Console.WriteLine($"Nome: {cli.Nome}");
            Console.WriteLine($"=================================");

            var lista = await ClienteDto.Todos();
            foreach(var c in lista)
            {
                Console.WriteLine($"Id: {c.Id}");
                Console.WriteLine($"Nome: {c.Nome}");
                Console.WriteLine($"Telefone: {c.Telefone}");
                Console.WriteLine($"Email: {c.Email}");
                Console.WriteLine($"Idade: {c.Idade}");
                Console.WriteLine($"=================================");
            }
        }
    }
}
