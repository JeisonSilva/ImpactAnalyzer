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

                    foreach (var method in root.DescendantNodes().OfType<MethodDeclarationSyntax>())
                    {
                        Console.WriteLine($"Method: {method.Identifier.ValueText}");
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