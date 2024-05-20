using impactAnalyzer.console;

var processador = new ProcessadorMudanca(new AnalisadorDiff());
await processador.ProcessarMudancas();