using System;
using System.Collections.Generic;
using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

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

            Console.WriteLine("Digite a quantidade de dias reservados:");
            int diasReservados = int.Parse(Console.ReadLine());

            Pessoa novoHospede = new Pessoa(nomeHospede);
            hospedes.Add(novoHospede);

            if (reserva != null)
            {
                reserva.DiasReservados = diasReservados;
            }

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

            suite = new Suite(tipoSuite, capacidade, valorDiaria);
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
                Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
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
                Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria().ToString("F2")}");
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































// using System.Text;
// using DesafioProjetoHospedagem.Models;

// Console.OutputEncoding = Encoding.UTF8;


// // Cria os modelos de hóspedes e cadastra na lista de hóspedes
// List<Pessoa> hospedes = new List<Pessoa>();

// Pessoa p1 = new Pessoa(nome: "Hóspede 1");
// Pessoa p2 = new Pessoa(nome: "Hóspede 2");

// hospedes.Add(p1);
// hospedes.Add(p2);

// // Cria a suíte
// Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// // Cria uma nova reserva, passando a suíte e os hóspedes
// Reserva reserva = new Reserva(diasReservados: 10);
// reserva.CadastrarSuite(suite);
// reserva.CadastrarHospedes(hospedes);

// // Exibe a quantidade de hóspedes e o valor da diária
// Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
// Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");