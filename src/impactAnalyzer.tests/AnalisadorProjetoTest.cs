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
           
            var directory = Directory.GetCurrentDirectory();
            for (int i = 0; i < 5; i++)
                directory = Directory.GetParent(directory)?.FullName;

            var grupoProjeto = new GrupoProjeto(new[]{@$"--path-solution={directory}\ImpactAnalyzer.sln"});
             var metodo = new Metodo(new[]{"--metodo=Analisar"});

           var metodoReferente = await _analisadorProjeto.Analisar(metodo, grupoProjeto);

           metodoReferente.SelectMany(x=>x.Key).Should().Contain((string)metodo);

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