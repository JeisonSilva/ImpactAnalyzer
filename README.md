# ImpactAnalyzer
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=jeisonsilva-github_impactanalyzer&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=jeisonsilva-github_impactanalyzer)

[![.NET](https://github.com/JeisonSilva/ImpactAnalyzer/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/JeisonSilva/ImpactAnalyzer/actions/workflows/dotnet.yml)


ImpactAnalyzer é uma ferramenta de linha de comando (.NET CLI) desenvolvida para analisar o impacto de alterações em métodos dentro de uma solução .NET. Esta ferramenta ajuda desenvolvedores a identificar todos os métodos que são afetados por uma alteração em um método específico, proporcionando uma visão clara do impacto potencial da mudança.

## Funcionalidades

- **Análise de impacto de métodos:** Identifica todos os métodos que são direta ou indiretamente afetados por uma alteração em um método específico.
- **Compatibilidade com soluções .NET:** Suporta análise de soluções .NET (.sln).
- **Saída clara e detalhada:** Gera uma lista de métodos impactados que pode ser usada para revisão de código, testes e planejamento de desenvolvimento.

## Requisitos

- .NET SDK 5.0 ou superior
- Sistema operacional Windows, macOS ou Linux

## Instalação

Para instalar o ImpactAnalyzer, siga os passos abaixo:

1. Clone o repositório do projeto:
   ```sh
   git clone https://github.com/seu-usuario/ImpactAnalyzer.git
   ```
2. Navegue até o diretório do projeto:
   ```sh
   cd ImpactAnalyzer
   ```
3. Compile o projeto:
   ```sh
   dotnet build
   ```

## Uso

Para usar o ImpactAnalyzer, execute o comando a seguir:

```sh
analyzer --metodo=<NomeDoMetodo> --path-solution=<CaminhoParaSln>
```

### Exemplos

1. Analisando o impacto da alteração no método `Analisar` na solução `ImpactAnalyzer.sln`:
   ```sh
   analyzer --metodo=Analisar --path-solution=./ImpactAnalyzer.sln
   ```

### Parâmetros

- `--metodo`: Especifica o nome do método que sofreu a alteração. Deve ser o nome completo do método, incluindo namespace e classe, se necessário.
- `--path-solution`: Especifica o caminho para a solução .NET (.sln) que será analisada.

## Saída

A ferramenta gera uma lista de métodos impactados que será exibida diretamente no terminal. Cada método listado é identificado pelo nome completo, incluindo namespace e classe.

## Contribuição

Se você deseja contribuir com o desenvolvimento do ImpactAnalyzer, siga as etapas abaixo:

1. Faça um fork do repositório.
2. Crie uma nova branch para sua feature ou correção de bug:
   ```sh
   git checkout -b minha-nova-feature
   ```
3. Faça commit das suas alterações:
   ```sh
   git commit -m "Adiciona nova feature"
   ```
4. Envie suas alterações para o repositório remoto:
   ```sh
   git push origin minha-nova-feature
   ```
5. Abra um Pull Request detalhando suas alterações.

## Licença

Este projeto é licenciado sob a Licença MIT. Consulte o arquivo LICENSE para obter mais informações.

---

Esperamos que o ImpactAnalyzer seja uma ferramenta útil para o seu fluxo de trabalho de desenvolvimento. Se você tiver dúvidas ou problemas, sinta-se à vontade para abrir uma issue no repositório do projeto.