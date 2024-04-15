class Pessoa {
  String nome;
  double peso;
  double altura;
  double? imc;
  String? classe;
  Pessoa(this.nome, this.altura, this.peso);
  @override
  String toString() {
    return "Nome: $nome\nPeso: $peso\nAltura: $altura";
  }

  String ExibirImcCalasse() {
    return "O imc de $nome equivale a $imc - Se enquadra no estado: ($classe)";
  }
}
