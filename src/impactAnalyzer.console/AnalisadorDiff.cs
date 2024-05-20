using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;

namespace impactAnalyzer.console
{
    public class AnalisadorDiff
    {
        public async Task AnalisarMetodo(List<Document> documents, Solution solution)
        {
            foreach (var item in documents)
            {
                try
                {
                    var semanticModel = await item.GetSemanticModelAsync();
                    var syntaxTree = await item.GetSyntaxTreeAsync();
                    var root = await syntaxTree.GetRootAsync();

                    var metodos = root.DescendantNodes().OfType<MethodDeclarationSyntax>();
                    foreach (var method in metodos )
                    {
                        var methodSymbol = semanticModel.GetDeclaredSymbol(method);
                        if (methodSymbol != null)
                        {
                            var references = await SymbolFinder.FindReferencesAsync(methodSymbol, solution);

                            var methodText = method.ToFullString();
                            Console.WriteLine($"Method: {method.Identifier.Text}");
                            Console.WriteLine("Code:");
                            Console.WriteLine(methodText);
                            Console.WriteLine();
                            ExibirReferencias(references);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void ExibirReferencias(IEnumerable<ReferencedSymbol> references)
        {
            foreach (var reference in references)
            {
                foreach (var location in reference.Locations)
                {
                    var referenceLocation = location.Location;

                    // Obter a linha e posição da referência
                    var lineSpan = referenceLocation.GetLineSpan();
                    var lineNumber = lineSpan.StartLinePosition.Line;
                    var charPosition = lineSpan.StartLinePosition.Character;

                    Console.WriteLine($"  Referenced at: {referenceLocation.SourceTree.FilePath} (Line {lineNumber + 1}, Char {charPosition + 1})");
                }
            }
        }
    }
}