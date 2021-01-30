# Desafio Código para todxs

### Purpouse

The Alf school apply multiple choices exams for the students. The student's score is determined by weighted average of questions with weights of each questions. Each correct question sum 1 point, multiplicated by weight of each wrong question 0. The final score is the aritmetic avarage of all scores's exams.


### Technologies Used

* C#
* SQL Database
* Docker
* Xunit
* Microsoft.NET


### Requirements

* Docker-Compose
* Visual Studio Code
* VSCode SQL extention
* Install cli migration as a `global tool dotnet tool install --global dotnet-ef`.
* (Optional) Program utilized for requisition: Postman


### Funcionalities

Start with the first migration `dotnet ef migrations add InitialCreate`. The system automatically register an admin users (teacher), that is necessary for criation of others users and exams. After starting migration, you need to create others users, students or teachers, then create another admin(teacher), that you will use his id for everthing.

For register the answer sheet of the exam is necessary the id of a teacher, after registering you can answer the exam with users(student) using the exam id that the api delivers for you after registering the exam.

After answered the exam, the program inform you with the score.

### CheckList

* Cadastrar gabarito da prova. Check
* Cadastrar as respostas de cada aluno para cada prova.
* Verificar a nota final de cada aluno.
* Listar os alunos aprovados.

* A nota total da prova é sempre maior que 0 e menor que 10. Check
* A quantidade máxima de alunos é 100. Check
* O peso de cada questão é sempre um inteiro maior que 0. Check
* Os alunos aprovados tem média de notas maior do que 7.
* A entrada e saída de dados deverá ser em JSON. Check

* Entrega dos requisitos obrigatórios: 6 pontos.
* Documentação: 1 ponto. Check
* Testes unitários: 1 ponto. Check
* Separação de camadas: 1 ponto. Check
* API RESTFul: 1 ponto. Check
