

using impactAnalyzer.console;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

var solutionPath = @"/home/jeison/Documentos/projetos/ImpactAnalyzer/ImpactAnalyzer.sln";
var methodToFind = "ExibirReferencias";

using var workspace = MSBuildWorkspace.Create();
var solution = await workspace.OpenSolutionAsync(solutionPath);

var methodCalls = new Dictionary<string, LinkedList<string>>();

foreach (var project in solution.Projects)
{
    foreach (var document in project.Documents)
    {
        var syntaxTree = await document.GetSyntaxTreeAsync();
        var root = await syntaxTree.GetRootAsync();

        var semanticModel = await document.GetSemanticModelAsync();

        var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();
        foreach (var method in methods)
        {
            var methodName = method.Identifier.ValueText;
            var calls = method.DescendantNodes().OfType<InvocationExpressionSyntax>();
            
            foreach (var call in calls)
            {
                var symbol = semanticModel.GetSymbolInfo(call).Symbol as IMethodSymbol;
                if (symbol != null && symbol.Name == methodToFind)
                {
                    if (!methodCalls.ContainsKey(methodToFind))
                    {
                        methodCalls[methodToFind] = new LinkedList<string>();
                    }
                    methodCalls[methodToFind].AddLast(methodName);
                }
            }
        }
    }
}

foreach (var kvp in methodCalls)
{
    Console.WriteLine($"Método '{kvp.Key}' é chamado pelos seguintes métodos:");
    Console.WriteLine(string.Join(", ", kvp.Value));
    
}


var processador = new ProcessadorMudanca(new AnalisadorDiff());

await Processar(processador);

static async Task Processar(ProcessadorMudanca processador)
{
    await processador.ProcessarMudancas();
}