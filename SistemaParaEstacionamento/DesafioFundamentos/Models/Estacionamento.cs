using System;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        //Adicina um novo veiculo a lista
        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            Veiculo veiculo=new Veiculo(placa);
            veiculos.Add(veiculo);
        }
        //Metodo para remover veiculo
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

        
            string placa = Console.ReadLine();
            

            Veiculo veiculo = veiculos.FirstOrDefault(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            if (veiculo != null)
            {
                
                decimal valorTotal = precoInicial + precoPorHora * veiculo.Horas;

                
                veiculos.Remove(veiculo);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int count = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{count} Placa: {veiculo.Placa} Horas: {veiculo.Horas}");
                    count++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
