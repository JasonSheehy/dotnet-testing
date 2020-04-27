# Installing dotnet core

* Install the dotnet sdk through brew `brew cask install dotnet`

* Initialize new sln: `dotnet new sln -o [solution name]`
  * `cd [solution name]`
  * Adding new project `dotnet new reactredux -o [project name]`
    * Add project to sln `dotnet sln add [path to project .csproj file]`
  * Add new test project `dotnet new xunit -o [<project name>.Test]`
    * Add test project to sln `dotnet sln add [path to test project .csproj file]`

* To add dependencies (equivalent of `npm install [dependency]`) run `dotnet add package [package-name]` in the root folder

* To run test project `dotnet test [test project name]`

* Add services for Dependency Injection in *ConfigureServices* function, will be provided to a class if declare constructor with the service as an input
