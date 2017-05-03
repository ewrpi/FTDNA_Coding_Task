To run program:

1- attach database files to sql server instance (DB/*.mdf,*.ldf)
2- modify database connection string in Startup.cs, method ConfigureServices
3- build and run solution 

Note: may deploy demo here (WIP as of 5/3)
http://genebygene.hackerdevs.com


NOTES ------------
Task Repo
https://github.com/genebygene/FTDNA_Coding_Task

.NET Core
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc

Angular 2
dotnet new --install Microsoft.AspNetCore.SpaTemplates::*
cd C:\main\programs\GeneByGene\FTDNA_Coding_Task
dotnet new angular

EF
https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db

SQL Server
Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True;