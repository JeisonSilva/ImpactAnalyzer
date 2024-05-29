namespace impactAnalyzer.models
{
    public struct GrupoProjeto
    {
        private readonly string _path;

        public GrupoProjeto(string[] args)
        {
            _path = args.FirstOrDefault(arg => arg.StartsWith("--path-solution=")).Split("=")[1];
        }

        public static implicit operator string(GrupoProjeto grupoProjeto)
            => grupoProjeto._path;
    }
}