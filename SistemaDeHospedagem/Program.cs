using System.Text;
using DesafioProjetoHospedagem.Models;

internal class Program
{
    
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Cria os modelos de hóspedes e cadastra na lista de hóspedes
        List<Pessoa> listaHospedes = new List<Pessoa>();
        List<Reserva> listaReservas = new List<Reserva>();
        Reserva reserva1= new Reserva(diasReservados:5);
        Pessoa pessoa1= new Pessoa("guilherme","almeida");
        listaHospedes.Add(pessoa1);
        Suite suite1= new Suite(tipoSuite:"Premiu",capacidade:4,valorDiaria:20);
        reserva1.CadastrarSuite(suite1);
        reserva1.CadastrarHospedes(listaHospedes);
        listaReservas.Add(reserva1);

        string LerTexto(string str)
        {
            Console.WriteLine(str);
            return Console.ReadLine().Trim();
        }
        void ListarResevas()
        {
            int cont = 0;
            listaReservas.ForEach(a => { Console.WriteLine("------------------");Console.WriteLine($"Id:{cont} {a.ToString()}");Console.WriteLine("------------------"); cont++; });
        }
        void VerificarReserva()
        {
            int cont = 0;
            int select = 0;
            Reserva reserva = new Reserva();
            foreach (var item in listaReservas)
            {
                Console.WriteLine("------------------");
                Console.WriteLine(item.ToStringSimples(cont));
                Console.WriteLine("------------------");
                cont++;
            }
            Console.WriteLine("==========================");
            select = int.Parse(LerTexto("Selecione a reserva: "));
            Console.Clear();
            reserva = listaReservas[select];
            Console.WriteLine(reserva.ToString());
            Console.WriteLine("O total a se pagar é: " + reserva.CalcularValorDiaria());
        }
        void RemoverReserva()
        {
            ListarResevas();
            Reserva reserva = new Reserva();
            int select = 0;
            select = int.Parse(LerTexto("Selecione a reserva: "));
            reserva = listaReservas[select];
            listaReservas.Remove(reserva);
            Console.WriteLine("Reserva removida!");
        }
        string continuar;
        Reserva reserva = new Reserva();
        Suite suite= new Suite();
        while (true)
        {
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1-Fazer uma rezerva ");
            Console.WriteLine("2-Calcular valor da reserva");
            Console.WriteLine("3-Listar reservas");
            Console.WriteLine("4-Remove reserva");

            int escolha = int.Parse(Console.ReadLine());
            
            switch (escolha)
            {
                case 1:
                    Console.WriteLine("Cadastrando Suite");
                    string tipoSuite = LerTexto("Informe o tipo da Suite:");
                    int capacidade = int.Parse(LerTexto("Informe a capacidade Suite:"));
                    decimal valorDiariaSuite = decimal.Parse(LerTexto("Informe o valor da diaria da Suite:"));
                    int numeroDias = int.Parse(LerTexto("Quantos dias irão passar na suite Suite:"));
                    reserva.DiasReservados=numeroDias;
                    suite = new Suite(tipoSuite: tipoSuite, capacidade: capacidade, valorDiaria: valorDiariaSuite);
                    //Cadastro do usuário
                    string nome;
                    string sobreNome;
                    do
                    {
                        Console.WriteLine("Cadastrando Hospede:");
                        nome = LerTexto("Informe o nome:");
                        sobreNome = LerTexto("Informe o sobrenome:");
                        Pessoa newPessoa = new Pessoa(nome:nome,sobrenome:sobreNome);
                        listaHospedes.Add(newPessoa);
                        continuar = LerTexto("Continuar?s/n");
                    } while (continuar.ToLower() == "s");                    
                    reserva.CadastrarSuite(suite);
                    reserva.CadastrarHospedes(listaHospedes);
                    listaReservas.Add(reserva);
                    Console.WriteLine("Reserva concluida com sucesso!");
                    LerTexto("");
                    break;
                case 2:
                    VerificarReserva();
                    LerTexto("");
                    break;
                case 3:
                    ListarResevas();
                    LerTexto("");
                    break;
                case 4:
                    RemoverReserva();
                    LerTexto("");
                    break;
            }
            Console.Clear();
        }
    }
}