namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa() { }
    public Pessoa(string nome)
    {
        Nome = nome;
    }
    public Pessoa(string nome, string sobrenome, int diasReservados)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        DiasReservados = diasReservados;
    }
    public decimal CalcularValorDiaria(decimal valorDiaria)
    {
        return DiasReservados * valorDiaria;
    }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public int DiasReservados { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
}