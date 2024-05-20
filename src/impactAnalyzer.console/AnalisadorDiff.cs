using Microsoft.CodeAnalysis;

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
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}