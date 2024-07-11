namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> lista)
        {
            Console.WriteLine($"{Suite.Capacidade} {lista.Count}");

            if (Suite == null)
            {
                throw new NullReferenceException("A propriedade Suite não foi inicializada.");
            }
            if (lista == null)
            {
                throw new NullReferenceException("A propriedade Hospedes é nula");
            }

            //Console.WriteLine($"{Suite.Capacidade} {Hospedes.Count}");
            if (Suite.Capacidade >= lista.Count)
            {
                Hospedes = lista;
            }
            else
            {
                throw new Exception("Capacidade não suporta o número de hóspedes.");
            }
        }
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }
        public string GetAllHospedesToString()
        {
            string listaHospedes = "";
            foreach (var item in Hospedes)
            {
                listaHospedes += item.ToString()+"\n" ;
            }
            return listaHospedes;
        }

        public int ObterQuantidadeHospedes()
        {

            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor *= 0.9m; // Aplica 10% de desconto
            }

            return valor;
        }
        public override string ToString()
        {
            return $"\nDias reservados: {DiasReservados}\nSuite: {Suite.ToString()}\nHospedes: {GetAllHospedesToString()}\nTotal a pagar: {CalcularValorDiaria()}";
        }
        public string ToStringSimples(int number)
        {
            return $"Id:{number}\nDias reservaos: {DiasReservados}\nValor Total: {CalcularValorDiaria()}\nSuite: tipo={Suite.TipoSuite} | capacidade={Suite.Capacidade}\nHospedes: {ObterQuantidadeHospedes()}";
        }
    }
}