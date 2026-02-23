### Hiscox.RaterApiWrapper.Infrastructure

This project contains code to access external services and data stores. Currenly, it only conatins code to access the application database.
In future, it may contain code to access infratructure services like Redis Cache, and Hiscox services, e.g., Magic.

The Data folder contains:
1. Configurations - These directy map one-to-one to the database tables.
1. Repositories - These contain code to access the database, and map the data to the domain models. They are used by the services in the Application layer.

<b>Note: The Application layer contain the interfaces that are implemented by the repositories.</b>

The Scripts folder contains SQL scripts to seed database tables with data.

In order to setup the database, do the following:
1. Create a database in SQL Server called RaterApiWrapper, using SSMS.
1. Delete the Migrations folder
1. Open the Nuget Package Manger Console in Visual Studio.
1. Change directory to the Infrastructure project: `cd c:\repos\Hiscox.RaterApiWrapper\src\Hiscox.RaterApiWrapper.Infrastructure`
1. Set the startup project to Hiscox.RaterApiWrapper.Infrastructure 
1. Set the default project in Nuget Package Manger Console to Hiscox.RaterApiWrapper.Infrastructure
1. Run this command: `Add-Migration Create_Database`
1. Run this command: `dotnet ef database update --project Hiscox.RaterApiWrapper.Infrastructure.csproj --connection "Data Source=(local);Initial Catalog=RaterApiWrapper;Integrated Security=True;Trust Server Certificate=True"`
1. After running the commands above, change the the default project back to Hiscox.RaterApiWrapper.Aspire.AppHost.
