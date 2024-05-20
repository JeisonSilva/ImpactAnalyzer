using impactAnalyzer.console;

var processador = new ProcessadorMudanca(new AnalisadorDiff());

await Processar(processador);

static async Task Processar(ProcessadorMudanca processador)
{
    await processador.ProcessarMudancas();
}