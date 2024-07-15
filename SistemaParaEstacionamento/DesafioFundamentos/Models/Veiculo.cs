class Veiculo
{
    public string Placa { get; set; }
    public int Minutos { get; set; }
    public decimal Horas => (Minutos / 60)-1; 
    private bool emEstacionamento = true; 
    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    
    public Veiculo(string placa)
    {
        Placa = placa;
        CalcularTempoDecorridoAsync();
    }

    // Método assíncrono para calcular o tempo decorrido
    public async Task CalcularTempoDecorridoAsync()
    {
        Console.WriteLine($"Veículo {Placa} estacionado. Iniciando contagem de minutos...");
        
        int segundos = 0; 

        CancellationToken cancellationToken = cancellationTokenSource.Token;

        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000, cancellationToken);
            
            segundos++; 

            // Atualiza os minutos decorridos a cada 60 segundos
            if (segundos % 60 == 0)
            {
                Minutos++;
               // Console.WriteLine($"Tempo decorrido para o veículo {Placa}: {Minutos} minutos ({Horas} horas)");
            }
        }

        Console.WriteLine($"Contagem de tempo para o veículo {Placa} interrompida.");
    }

    // Método para parar a contagem do tempo
    public void PararContagemTempo()
    {
        emEstacionamento = false;
        cancellationTokenSource.Cancel();
    }
}