using LibGit2Sharp;

var repo = new Repository("/home/jeison/Documentos/projetos/ImpactAnalyzer/.git");
var oldCommit = repo.Branches["main"].Tip;
var newCommit = repo.Branches["feature/CloneArquivoDiff"].Tip;

var changes = repo.Diff.Compare<TreeChanges>(oldCommit.Tree, newCommit.Tree);
var modifiedFiles = changes.Where(c => c.Status == ChangeKind.Modified).Select(c => c.Path).ToList();

foreach (var file in modifiedFiles)
{
    Console.WriteLine($"Diff for {file}");
    // transforma o arquivo em um blob
    var oldBlob = repo.Lookup<Blob>(changes.Single(c => c.Path == file).Oid);
    Console.WriteLine($"Old: {oldBlob.GetContentText()}");
}