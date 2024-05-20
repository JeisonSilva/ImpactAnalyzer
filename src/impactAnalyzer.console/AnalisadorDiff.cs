using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace impactAnalyzer.console
{
    public class AnalisadorDiff
    {
        public async Task AnalisarMetodo(List<Document> documents)
        {
            foreach (var item in documents)
            {
                try
                {
                    var syntaxTree = await item.GetSyntaxTreeAsync();
                    var root = await syntaxTree.GetRootAsync();

                    var metodos = root.DescendantNodes().OfType<MethodDeclarationSyntax>();
                    foreach (var method in metodos )
                    {
                        Console.WriteLine($"Method: {method.Identifier}");
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}