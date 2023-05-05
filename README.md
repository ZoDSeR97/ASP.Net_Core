# ASP.Net_Core
Learn ASP.Net Core
## :white_check_mark: Requirements ##
We are using MySQL in this journey
```bash
$ dotnet --version
7.0.203
$ dotnet tool install --global dotnet-ef # This install entity framework globally
```
## :checkered_flag: How to run ##
```bash
$ cd folder_name # cd into folder directory where .cs files are
$ dotnet restore # Restore the dependencies and tools of a project
$ dotnet run
```
## :coffee: Helpful Commands ##
For learning purpose, we use `--no-https` flag to disable Https protocal cert requirement and focusing on the development.

Basic web template
```bash
$ dotnet new web --no-https -o ProjectName
```
Using Full MVC project template
```bash
$ dotnet new mvc --no-https -o ProjectName
```
After created our mvc project, we add 2 packages of Entity Frameworks
```bash
$ dotnet add package Pomelo.EntityFrameworkCore.MySql
$ dotnet add package Microsoft.EntityFrameworkCore.Design
```
After created our models, we would like to create tables in our DB according to our models specification
```bash
$ dotnet ef migrations add FirstMigration -v
$ dotnet ef database update
```

## :white_check_mark: :shield: Https Certificate ##
[How To](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?WT.mc_id=dotnet-35129-website&view=aspnetcore-7.0&tabs=visual-studio-code) 
