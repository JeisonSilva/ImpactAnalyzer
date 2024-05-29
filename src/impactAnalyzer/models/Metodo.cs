namespace impactAnalyzer.models
{
    public struct Metodo
    {
        private readonly string _nome;

        public Metodo(string[] args)
        {
            _nome = args.FirstOrDefault(arg => arg.StartsWith("--metodo=")).Split("=")[1];
        }

        public static implicit operator string(Metodo metodo)
            => metodo._nome;
    }
}