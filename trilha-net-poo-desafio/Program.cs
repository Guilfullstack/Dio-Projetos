using DesafioPOO.Models;
//erro pois a classe é abstrata
//Smartphone smartphone= new Smartphone();
Iphone iphone=new Iphone("2212","iPhone 14 Pro","33333",16);
iphone.ReceberLigacao();
iphone.Ligar();
iphone.InstalarAplicativo("Instagran");
Nokia nokia=new Nokia("7080","Nokia 8.3 5G","7777",5);
nokia.ReceberLigacao();
nokia.Ligar();
nokia.InstalarAplicativo("Jogo da cobrinha");