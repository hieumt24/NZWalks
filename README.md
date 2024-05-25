# NZWalks

Asp.Net Core 8 Web Api

## 🚀 About Me

I'm a full stack developer...

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
    1.Install nuget package:
            + Microsoft.AspNetCore.Authentication.JwtBearer
            + Microsoft.IdentityModel.Tokens
            + System.IdentityModel.Tokens.Jwt
            + Microsoft.AspNetCore.Identity.EntityFrameworkCore
    2.Add JWT to appsetting.json:
             "Jwt": {
                    "Key": "Random key ",
                    "Issuer": "Your local host",
                    "Audience": "Your local host"
                    }
    3.Add Jwt to service file program.cs:
                builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = builder.Configuration["Jwt:Issuer"],
                            ValidAudience = builder.Configuration["JWt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                        };
                    });
    4. Using Authentication in file program.cs:
                app.UseAuthentication();
    5. Use the [Authorize] controller you need authentication
    6. Setting Up Identity DbContext
