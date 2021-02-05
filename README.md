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
* Install cli migration `global tool dotnet tool install --global dotnet-ef`.
* (Optional) Program utilized for requisition: Postman


### Start the Application

To start the project use `docker-compose up` on the main paste then in the paste: Infra execute the command `dotnet ef migrations add <any name>`, last but not least at the WebApi paste use `dotnet run`.


### Funcionalities

The system automatically register an admin users (teacher), that is necessary for criation of others users and exams. After starting migration, you need to create others users, students or teachers, then create another admin(teacher), that you will use his id for everthing.

For register the answer sheet of the exam is necessary the id of a teacher and a list of questions.

After registering you can answer the exam with users(student), list of questions and using the answer sheet id that the api delivers for you after registering the answer sheet.

After answered the exam, the program inform you with the score.

To get approved students just need to send a Get request


### Business Rules

* Cadastrar gabarito da prova. ✔
* Cadastrar as respostas de cada aluno para cada prova. ❌
* Verificar a nota final de cada aluno. ❌
* Listar os alunos aprovados. ✔

* A nota total da prova é sempre maior que 0 e menor que 10. ✔
* A quantidade máxima de alunos é 100. ✔
* O peso de cada questão é sempre um inteiro maior que 0. ✔
* Os alunos aprovados tem média de notas maior do que 7. ✔
* A entrada e saída de dados deverá ser em JSON. ✔

* Entrega dos requisitos obrigatórios: 6 point. ❌
* Documentação: 1 point. ✔
* Testes unitários: 1 point. ✔
* Separação de camadas: 1 point. ✔
* API RESTFul: 1 point. ✔


##### Special thanks to: MATHEUS TALLMANN that helped with readme.