import 'dart:io';

import 'package:calculadora_imc_dart/class/pessoa.dart';

double calculateImc(Pessoa pessoa) {
  if (pessoa.altura > 3) pessoa.altura /= 100;
  return pessoa.peso / (pessoa.altura * pessoa.altura);
}

String classificacaoImc(double imc) {
  if (imc < 16) {
    return "Magreza Grave";
  } else if (imc < 17) {
    return "Magreza Moderada";
  } else if (imc < 18.5) {
    return "Magreza Leve";
  } else if (imc < 25) {
    return "Saudável";
  } else if (imc < 30) {
    return "Sobrepeso";
  } else if (imc < 35) {
    return "Obesidade Grau I";
  } else if (imc < 40) {
    return "Obesidade Grau II (severa)";
  } else {
    return "Obesidade Grau III (mórbida)";
  }
}

double leitorEntradaDouble(String texto) {
  while (true) {
    try {
      stdout.write(texto);
      var entrada = double.parse(stdin.readLineSync()!);
      return entrada;
    } catch (e) {
      print("Número inválido! Tente novamente... [Erro: ${e.toString()}]");
    }
  }
}

String lerEntradaString(String texto) {
  print(texto);
  var entrada = stdin.readLineSync();
  return entrada ?? "";
}
