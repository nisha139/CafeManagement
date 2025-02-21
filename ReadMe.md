Open Visual Stdio and create new blank solution 
Create Folder "Src" which contains subfolders 1.Api, 2.Core, 3.Infrastructure
In Api folder add project ASP.NET web api give name CafeManagement.API
In Core folder add two class libraries for Application and Domain layer[CafeManagement.Application,CafeManagement.Domain] 
In Infrastructure folder add three class libraries for Identity, Infrastructure and Persistence layer [CafeManagement.Identity,CafeManagement.Infrastructure,CafeManagement.Persistence] 

In Api Add project reference 
1.   CafeManagement.Persistence
2.   CafeManagement.Application
3.   CafeManagement.Identity
4.   CafeManagement.Infrastructure

Add below packages for the Api 
1.   MediatR
2.   MediatR.Extensions.Microsoft.DependencyInjection
3.   Microsoft.AspNetCore.Authentication.JwtBearer
4.   Microsoft.AspNetCore.Mvc.Core
5.   Microsoft.EntityFrameworkCore.Design
6.   Microsoft.IdentityModel.Tokens
7.   Swashbuckle.AspNetCore

In Application layer Add below project reference
1.   CafeManagement.Domain

Add below packages for Application layer
1.   AutoMapper
2.   AutoMapper.Extensions.Microsoft.DependencyInjection
3.   MediatR
4.   Microsoft.EntityFrameworkCore
5.   Microsoft.EntityFrameworkCore.Abstractions
6.   Ardalis.Specification

In Domain Layer there is no any project reference and packages because it always Independent 

In Identity layer add below project references
1.   CafeManagement.Application
2.   CafeManagement.Domain

Add below packages for Identity Layer
1.   Microsoft.AspNetCore.Identity
2.   Microsoft.AspNetCore.Identity.EntityFrameworkCore
3.   Microsoft.EntityFrameworkCore.SqlServer
4.   Microsoft.Extensions.Identity.Core
5.   Microsoft.AspNetCore.Authentication.JwtBearer

In Infrastruture layer add below project reference 
1.   CafeManagement.Application
	
Add below packages in Infrastructure layer
1.   Microsoft.EntityFrameworkCore
2.   Microsoft.EntityFrameworkCore.Design
3.   Microsoft.EntityFrameworkCore.SqlServer
4.   Microsoft.Extensions.Configuration.Json
5.   Microsoft.Extensions.DependencyInjection

In Persistence layer add below project reference 
1.   CafeManagement.Application

Add below packages in Persistence layer
1.   Microsoft.EntityFrameworkCore
2.   Microsoft.EntityFrameworkCore.Design
3.	 Microsoft.EntityFrameworkCore.SqlServer
4.   Microsoft.EntityFrameworkCore.Tools
5.   Ardalis.Specification.EntityFrameworkCore
6.   Ardalis.Specification

In Api.csproject file  InvariantGlobalization false /InvariantGlobalization change true to false before migration

Go to Tool-> Nuget packager manager-> package manager console-> select persistence top right side 

Add-Migration InitialCreate -Project CafeManagement.Persistence -StartupProject CafeManagement.API

dotnet ef database update --project CafeManagement.Persistence --startup-project CafeManagement.API

for migration in Identity layer 
Add-Migration InitIdentity -Context CafeManagementIdentityDbContext
Update-Database -Context CafeManagementIdentityDbContext

for search GetAllCafe menu search formate:

{
  "paginationFilter": {
    "pageNumber": 1,
    "pageSize": 20,
    "orderBy":
      []
  }
}


