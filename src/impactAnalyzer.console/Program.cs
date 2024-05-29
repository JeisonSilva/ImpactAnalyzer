using impactAnalyzer.models;



var analisador = new AnalisadorProjeto();
var metodo = new Metodo(args);
var grupoProjeto = new GrupoProjeto(args);

var result = await analisador.Analisar(metodo, grupoProjeto);

foreach (var kvp in result)
{
    Console.WriteLine($"Método '{kvp.Key}' é chamado pelos seguintes métodos:");
    Console.WriteLine(string.Join(", ", kvp.Value));
    
}