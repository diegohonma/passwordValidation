### Tecnologias:

- .net core 2.2

### Fluxos:

- [Sequencia](docs/Sequencia.png)

### Executando a aplicação:

- Para executar a aplicação, é necessário ter o runtime do .net core 2.2:

    https://dotnet.microsoft.com/download/linux-package-manager/centos/runtime-2.2.4

- Com a runtime instalada, basta entrar dentro da pasta [src/passwordValidation](src/passwordValidation) e executar o comando:    
    `dotnet run`

### Detalhes sobre a solução

- A solução usa uma arquitetura bem simples, o controller comunica com o handler que chama os serviços cadastrados para validação da senha.
- Visando facilitar a construção de novas validações sem impactar as existentes, foi criado uma interface `IPasswordValidationService` e para cada validação essa interface foi herdada e implementada de acordo com a regra da validação.
- As validações foram criadas recebendo a configuração de quantidades mínimas de digitos, caracter maiúsculo/mininúsculo, etc para evitar alterações no código em caso dessas regras serem alteradas.