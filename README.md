# NZWalks
If you find this project useful, please give it a star. Thanks! ⭐

##Technology stack
    - Using ASP.NET CORE WEB API 8

## Reposioty Pattern

    - Design pattern to separete data access layer from the application
    - Provides interface without exposing implementation
    - Helps create abstraction

## Benefit Repository Pattern

    -Decoupling
    -Consistency
    -Performance
    -Multiple data source(switching)

## Automapper

    - Object-to-object mapping
    - Simplification
    - Map between DTOs and Domain Models and Vice-versa
    - Quite powerful apart from just simple object-to-object mapping

## Navigation Properties

    - Allow to Navigate From one Entity To Another
    - Walks Domain model will have Region Navigation Property

## Authenticatin

    - The process to determine a user's Identity
    - Username and Password
    - By using authenticatin, we check if we trust the user

## Authorization

    - User permission
    - Roles, Policies, Claims
    - Check if User has ReadOnly or ReadWrite Role

## JWT token

    - JWT or Json web token is an open standard the defines a compact and seft-contained way for securely transmitting information between parties as a Json object.
    Install nuget package:
            + Microsoft.AspNetCore.Authentication.JwtBearer
            + Microsoft.IdentityModel.Tokens
            + System.IdentityModel.Tokens.Jwt
            + Microsoft.AspNetCore.Identity.EntityFrameworkCore

## Image Upload

    -Add migration : Add-Migration "Adding Images Table" -Context "NZWalksDbContext"
    -Update database : Update-Database -Context "NZWalksDbContext"
