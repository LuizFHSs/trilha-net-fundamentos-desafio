using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            string placa;

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();
            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa);
            }
            else
            {
                Console.WriteLine("\n***Placa Inválida***" + "\n" + $"{placa} Não Corresponde ao Padrão Mercosul.\n");
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = "";
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                int horas = 0;
                decimal valorTotal = 0;

                horas = Convert.ToInt32(Console.ReadLine());
                valorTotal = precoInicial + precoPorHora * horas;

                // TODO: Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Count != 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private static bool ValidarPlaca(string placa)
        {
            // a nova placa Mercosul conta com 3 letras, 1 número, mais 1 letra e 2 números: AAAXAXX
            string padraoPlacaNova = "^[^0-9a-z]{3}[^A-Za-z]{1}[^0-9a-z]{1}[^A-Za-z]{2}";
            string padraoPlacaAntiga = "^[^0-9a-z]{3}\\-[^A-Za-z]{4}";

            bool placaValida = false;

            if (Regex.IsMatch(placa, padraoPlacaNova))
            {
                placaValida = true;
            }
            else if (Regex.IsMatch(placa, padraoPlacaAntiga))
            {
                placaValida = true;
            }

            return placaValida;
        }
    }
}
