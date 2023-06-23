using System;
using System.Collections.Generic;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = null;
Reserva reserva = null;

bool sair = false;

while (!sair)
{
    Console.WriteLine("----- MENU -----");
    Console.WriteLine("1. Cadastrar Hóspede");
    Console.WriteLine("2. Cadastrar Suíte");
    Console.WriteLine("3. Obter Quantidade de Hóspedes");
    Console.WriteLine("4. Calcular Valor da Diária");
    Console.WriteLine("0. Sair");

    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine("Digite o nome do hóspede: ");
            string nomeHospede = Console.ReadLine();

            Console.WriteLine("Digite o sobrenome do hóspede:");
            string sobrenomeHospede = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de dias reservados:");
            int diasReservados = int.Parse(Console.ReadLine());

            Pessoa novoHospede = new Pessoa(nomeHospede, sobrenomeHospede, diasReservados);
            hospedes.Add(novoHospede);

            Console.WriteLine("Hóspede cadastrado com sucesso!");
            Console.WriteLine();
            break;

        case "2":
            Console.WriteLine("Digite o tipo da suíte: ");
            string tipoSuite = Console.ReadLine();
            Console.WriteLine("Digite a capacidade da suíte: ");
            int capacidade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da diária da suíte: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            // Passa os dados cadastrados pelo usuário da nova 'suite'
            suite = new Suite(tipoSuite, capacidade, valorDiaria);

            // Cria uma nova reserva, passando a suíte e os hóspedes
            reserva = new Reserva();
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);


            Console.WriteLine("Suíte cadastrada com sucesso!");
            Console.WriteLine();
            break;

        case "3":
            if (reserva == null)
            {
                Console.WriteLine("Nenhuma reserva foi feita.");
            }
            else
            {
                hospedes = reserva.ObterHospedes();
                Console.WriteLine("Hóspedes cadastrados:");
                foreach (Pessoa hospede in reserva.Hospedes)
                {
                    Console.WriteLine(hospede.NomeCompleto);
                }
            }
            Console.WriteLine();
            break;

        case "4":
            if (reserva == null)
            {
                Console.WriteLine("Nenhuma reserva foi feita.");
            }
            else
            {
                reserva.CadastrarHospedes(hospedes); // Certifica-se de que a lista de hóspedes está atualizada
                
                foreach (Pessoa hospede in reserva.Hospedes)
                {
                    decimal valorDiariaHospede = hospede.CalcularValorDiaria(suite.ValorDiaria);
                    Console.WriteLine($"Valor total para {hospede.NomeCompleto}: {valorDiariaHospede.ToString("F2")}");
                }
            }
            Console.WriteLine();
            break;

        case "0":
            sair = true;
            break;

        default:
            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
            Console.WriteLine();
            break;
    }
}