using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using impactAnalyzer.models;
using Moq.AutoMock;

namespace impactAnalyzer.tests
{
    public class AnalisadorProjetoTest
    {
        private readonly AutoMocker _mocker;
        private readonly AnalisadorProjeto _analisadorProjeto;

        public AnalisadorProjetoTest()
        {
            _mocker = new AutoMocker();
            _analisadorProjeto = _mocker.CreateInstance<AnalisadorProjeto>();
        }

        [Fact]
        public async Task DeveRetornarUmMetodoAnalisado()
        {
            string? directory = RetornarDiretorioSolucao();

            var grupoProjeto = new GrupoProjeto(new[] { @$"--path-solution={directory}\ImpactAnalyzer.sln" });
            var metodo = new Metodo(new[] { "--metodo=Analisar" });

            var metodoReferente = await _analisadorProjeto.Analisar(metodo, grupoProjeto);

            metodoReferente.SelectMany(x => x.Key).Should().Contain((string)metodo);

        }

        private static string? RetornarDiretorioSolucao()
        {
            var directory = Directory.GetCurrentDirectory();
            for (int i = 0; i < 5; i++)
            {

                if (Directory.GetParent(directory)?.Name.Equals("ImpactAnalyzer", StringComparison.CurrentCultureIgnoreCase) == true)
                {
                    directory = Directory.GetParent(directory)?.FullName;
                    break;
                }
                else
                {
                    directory = Directory.GetParent(directory)?.FullName;
                }
            }

            return directory;
        }

        [Fact]
        public void DeveRetornarUmaException()
        {
            var grupoProjeto = new GrupoProjeto(new[]{"--path-solution=ImpactAnalyzer.sln"});
            var metodo = new Metodo(new[]{"--metodo=Analisar"});

            _analisadorProjeto.Invoking(x=>x.Analisar(metodo, grupoProjeto)).Should().ThrowAsync<ArgumentException>();
        }
    }
}