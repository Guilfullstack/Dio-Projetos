class Heroi{
    constructor(nome,idade,tipo){
        this.nome=nome
        this.idade=idade
        this.tipo=tipo
        this.tipoAtaque=this.definirAtaque(this.tipo)
    }
    definirAtaque(tipo){
        let ataque ="Ataque Indefinido"
        switch (tipo) {
            case "mago":
                    ataque="magia"
                break;
            case "guerreiro":
                    ataque="espada"
                break;
            case "monge":
                    ataque="arte marciaial"
                break;
            case "ninja":
                    ataque="shuriken"
                break;
        
            default:
                break;
        }
        return ataque
    }
    atacar(){
        console.log(`${this.nome} o ${this.tipo} atacou usando sua ${this.tipoAtaque}`)
    }

}

function main(){
    const heroi = new Heroi("Guilherme",22,"MAGO".toLowerCase());
    heroi.atacar()

}

main()