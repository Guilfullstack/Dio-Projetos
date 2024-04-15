const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

function pergunta(texto) {
    return new Promise((resolve, reject) => {
        rl.question(texto, (resposta) => {
            resolve(resposta);
        });
    });
}

let saldoVitorias = 0;
let saldoDerrotas = 0;
let saldoRankeadas = 0;
let nivelHeroi = "Sem classificação";
let continuar = false;
let nomeHeroi="Nika"
async function main() {
    do {
        console.log("#Calculadora de partidas Rankeadas#");
        let vitorias= await pergunta("Informe a quantidade de Vitorias: ");
        let derrotas= await pergunta("Informe a quantidade de Derrotas: ");
        saldoVitorias=parseInt(vitorias)
        saldoDerrotas=parseInt(derrotas)
        saldoRankeadas=calcularSaldoRankeadas(saldoVitorias,saldoDerrotas)
        nivelHeroi=calcularNivelHeroi(saldoRankeadas)
        console.log(`O Herói ${nomeHeroi} tem de saldo de ${saldoRankeadas} está no nível de ${nivelHeroi}`)
        let resposta= await pergunta("Deseja continuar: y/n");
        if (resposta.toLowerCase() === 'y') {
            continuar=true
            console.log("\n")
        }else if (resposta.toLowerCase() == 'n') {
            console.log("Encerrando o programa...");
            rl.close();
            break;
        }
        

        
    }while(continuar)
}


function calcularSaldoRankeadas(quantidadeVitorias,quantidadeDerrotas) {
    let saldoRankeadas=parseInt(quantidadeVitorias-quantidadeDerrotas)
    return saldoRankeadas
}

function calcularNivelHeroi(saldoRankeadas) {
    /*
        Se vitórias for menor do que 10 = Ferro
        Se vitórias for entre 11 e 20 = Bronze
        Se vitórias for entre 21 e 50 = Prata
        Se vitórias for entre 51 e 80 = Ouro
        Se vitórias for entre 81 e 90 = Diamante
        Se vitórias for entre 91 e 100= Lendário
        Se vitórias for maior ou igual a 101 = Imortal
    */
    let resultado="Sem resultado"
    if (saldoRankeadas < 10) {
        resultado = "Ferro";
    } else if (saldoRankeadas >= 11 && saldoRankeadas <= 20) {
        resultado = "Bronze";
    } else if (saldoRankeadas >= 21 && saldoRankeadas <= 50) {
        resultado = "Prata";
    } else if (saldoRankeadas >= 51 && saldoRankeadas <= 80) {
        resultado = "Ouro";
    } else if (saldoRankeadas >= 81 && saldoRankeadas <= 90) {
        resultado = "Diamante";
    } else if (saldoRankeadas >= 91 && saldoRankeadas <= 100) {
        resultado = "Lendário";
    } else if (saldoRankeadas >= 101) {
        resultado = "Imortal";
    }

    return resultado
}

main();