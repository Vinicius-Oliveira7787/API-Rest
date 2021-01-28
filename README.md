# Desafio Código para todxs 

### Propósito 

A escola Alf aplica provas de múltipla escolha para os alunos. A nota do aluno na prova é determinada pela média ponderada das questões com os pesos de cada questão. Cada questão correta soma 1 ponto multiplicada pelo peso e cada questão errada 0. A nota final é a média aritmética das notas de todas as provas.

### Tecnologias Utilizadas 

* C#
* Banco de dados SQL
* Docker
* Xunit
* Microsoft.NET

### Requisitos 

* Docker-Compose
* Visual Studio Code
* VSCode SQL extention 
* Instalar a cli de migrations como ferramenta global `dotnet tool install --global dotnet-ef`.
* (Optional) Programa utilizado para requisições: Postman 

### Funcionalidades 

Comece rodando a primeira migração `dotnet ef migrations add InitialCreate`. 
O sistema automaticamente cadastra um usuário admin (teacher), que é necessário para criação de outros usuários e provas.

Após rodar a migration você deve criar outros usuários, alunos ou professores, em seguida crie outro admin(teacher), que você usará seu id para tudo.

Para o cadastro do gabarito da prova é necessário o id de um professor, após o cadastro você pode responder a prova com usuários estudantes utilizando o id da prova que a api lhe entrega após o cadastro da prova.

após responder a prova o programa lhe informa a nota automaticamente.