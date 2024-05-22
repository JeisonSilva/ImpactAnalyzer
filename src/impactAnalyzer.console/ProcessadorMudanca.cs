using System.Text.RegularExpressions;
using LibGit2Sharp;
using Microsoft.CodeAnalysis.MSBuild;

namespace impactAnalyzer.console
{
    public class ProcessadorMudanca
    {
        private readonly AnalisadorDiff _analisadorDiff;

        public ProcessadorMudanca(AnalisadorDiff analisadorDiff)
        {
            _analisadorDiff = analisadorDiff;
        }

        public async Task ProcessarMudancas()
        {
            var repo = new Repository("/home/jeison/Documentos/projetos/ImpactAnalyzer/.git");
            var workspace = MSBuildWorkspace.Create();
            var solution = await workspace.OpenSolutionAsync("/home/jeison/Documentos/projetos/ImpactAnalyzer/ImpactAnalyzer.sln");

            var oldCommit = repo.Branches["main"].Tip;
            var newCommit = repo.Branches["feature/TestesReferencia"].Tip;
            var changes = repo.Diff.Compare<TreeChanges>(oldCommit.Tree, newCommit.Tree);
            var modifiedFiles = changes.Where(c => c.Status == ChangeKind.Modified).Select(c => c.Path).ToList();

            foreach (var file in modifiedFiles)
            {
                var oldBlob = repo.Lookup<Blob>(changes.Single(c => c.Path == file).Oid);
                var documents = solution.Projects.SelectMany(p => p.Documents).Where(d =>
                {
                    var filePath = d.FilePath;
                    var pattern = @".*/" + Regex.Escape(file).Replace(@"\.", @"\.");
                    var isMatch = Regex.IsMatch(filePath, pattern);

                    return isMatch;
                }).ToList();

                await _analisadorDiff.AnalisarMetodo(documents, solution);

            }
        }                                                                                         
        
    }
}