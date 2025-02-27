LibraryManagementApp is a ASP.NET Core Web API Project using a SOLID Principle,Interface Segregation Principle.
Here is a implementation of JWT-based authentication for two roles: Admin and User.
Data is stored locally.
  Note:Please check appsetting.json file for database setting.
This application allows admin to add,edit and delete books data but user have only read permissions.
User can retieve data by authorwise and they can see most borrowed books.
API end points are included for Login,Registation of use where user can add name,email,passowrd ans their role.
  End Point for register:/api/auth/register 
  End point for login /api/auth/login
API End point are included for books to get book details,add,update and delete book,group by author and top 3 most borrowed books.




