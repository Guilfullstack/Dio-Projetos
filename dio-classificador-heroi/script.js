//Variáveis
const readline = require('readline');

let nomeHeroi = "Nika";
let xpHeroi = 0;
let classeHeroi = definirClasse(xpHeroi);


let continuar = true;
//inicio 
console.log("O Herói de nome " + nomeHeroi + " está no nível de: " + classeHeroi);

function definirClasse(xp) {
    if (xp < 1000) {
        return "Ferro";
    } else if (xp <= 2000) {
        return "Bronze";
    } else if (xp <= 5000) {
        return "Prata";
    } else if (xp <= 7000) {
        return "Ouro";
    } else if (xp <= 8000) {
        return "Platina";
    } else if (xp <= 9000) {
        return "Ascendente";
    } else if (xp <= 10000) {
        return "Imortal";
    } else {
        return "Radiante";
    }
}

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

async function adicionarXP() {
    do{
        resposta = await pergunta('Deseja adicionar XP? (y/n): ');
        if (resposta.toLowerCase() === 'y') {
            let xp = await pergunta("Informe a quantidade de XP ganha: ");
            xpHeroi += parseInt(xp);
            console.log(`XP adicionada. Novo total de XP: ${xpHeroi}`);
            classeHeroi = definirClasse(xpHeroi);
            console.log("O Herói de nome " + nomeHeroi + " está no nível de: " + classeHeroi + "\n");
            continuar=true
        } else if (resposta.toLowerCase() == 'n') {
            console.log("Encerrando o programa...");
            rl.close();
            break;
        }else{
            console.log("Opção inválida. Tente novamente...\n");
            continuar=true
        }
    }while(continuar)
}

adicionarXP();
