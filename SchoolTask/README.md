# BornInteractive Task

### Task for CRUD operations using .Net 5 MVC, EF and MySQL

#### The task is a simple school project where we can add, edit and delete students and subject and it's consisted from:

- *Context Folder*: StudentContext and SubjectContext files for the EF usage
- *Controllers Folder*: StudentController and SubjectController with multiple functions
  #### StudentController
  - Index function. (GET)
  - AddOrEdit function. (GET & POST)
  - Delete function. (POST)
  #### SubjectController
  - Index function. (GET)
  - Create function. (GET & POST)
  - Edit function. (GET & POST)
  - Delete function. (POST)
  - Detail function. (GET)
  

- *Models Folder*: StudentModel and SubjectModel with multiple variables and validation.
- *Views Folder*: I edited the *Home* page by adding 2 card like a simple dashboard page and created Student and Subject Folder with multiple views pages:
  #### StudentController
  - Index page
  - AddOrEdit page
  #### SubjectController
  - Index page
  - Create page
  - Edit page
  - Detail page

### Database Connection

I used MySQL as my database and added schoolTask.sql generated file to the project zip folder for testing.
To edit the database credentials:
- Open appsettings.json file.
- Change the database credentials in the *ConnectionStrings* 

### Dependencies

- Microsoft.EntityFrameworkCore.Tools.DotNet 2.0.3
- Microsoft.EntityFrameworkCore.Tools 5.0.11
- Microsoft.EntityFrameworkCore 5.0.11
- MySql.Data 8.0.27
- MySql.EntityFrameworkCore 5.0.8

### Paging

- Created Paging folder and new Pagination class.
- Create an instance of pagination inside the index methods in the student and subjcet controller that took as argument the total count of items, pages count and the limit of items in each page.
- Create a _Pagination partial view that pass the controller name as model.
- Use _Pagination partial class inside each Index page (or whenever we need it) to show the pagination.

