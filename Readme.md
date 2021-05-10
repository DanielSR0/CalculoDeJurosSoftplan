# Overview da solução
## APIs
As APIs de consulta de taxa de juros e cálculo de juros, foram implementadas utilizando .NET 5 e são hospedadas em Docker.

Para a comunicação entre elas, foi utilizada a biblioteca _Refit_ junto com uma implementação seguindo o pattern _Factory_ para centralizar a regra de criação da comunicação com outra API.

## Testes
Todas as funcionalidades possuem testes unitários e de API,utilizando a ferramenta _XUnit_ para a descrição e execução dos testes, e a biblioteca _FluentAssertions_ para validação dos resultados.
- Para os testes unitários, também foi utilizado o framework _NSubstitute_ para mock de outras camadas (por exemplo, as comunicação de uma api com a outra).
- Para os testes de API, utilizei novamente a biblioteca _Refit_ para facilitar a chamada às APIs.

# Executando as aplicações
Para executar as aplicações, rodar os seguintes comandos no powershell, na pasta raiz da solution:
1) docker-compose build
2) docker-compose up

Feito isto, as aplicações estarão disponíveis através das URLs:
- consulta de taxa de juros: http://localhost:51200;
- cálculo de juros e consulta à URL dos fontes: https://localhost:51301.
- ambas aplicações possuem uma página de documentação que podem ser acessadas ao colocar no final da URL _"/swagger"_.