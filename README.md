![CommonPasswordsValidator logo](https://raw.githubusercontent.com/andrewlock/CommonPasswordsValidator/master/logo.png)

*The most popular password, making up nearly 17 percent of the 10 million passwords the company analyzed, was `123456`*

# CommonPasswordsValidator

[![Build status](https://ci.appveyor.com/api/projects/status/mqlpvis18ll4rj6f/branch/master?svg=true)](https://ci.appveyor.com/project/andrewlock/commonpasswordsvalidator/branch/master)
<!--[![Travis](https://img.shields.io/travis/andrewlock/CommonPasswordsValidator.svg?maxAge=3600&label=travis)](https://travis-ci.org/andrewlock/CommonPasswordsValidator)-->
[![NuGet](https://img.shields.io/nuget/v/CommonPasswordsValidator.svg)](https://www.nuget.org/packages/CommonPasswordsValidator/)
[![MyGet CI](https://img.shields.io/myget/andrewlock-ci/v/CommonPasswordsValidator.svg)](http://myget.org/gallery/acndrewlock-ci)

Implementations of [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity) `IPasswordValidators` that verify the provided password is not one of the most common passwords.

## Why should you care?

Password rules are a pain, and users hate them! Worse than that - even though they make the password mathematically stronger, the real-world benefit is questionable.

> Changing the ones to 'i's does not a strong password make!

This package lets you relax those rules, and instead simply require that passwords are not one of the top 100, top 1000, or even top 100,000  most common passwords.

## Quick start

Install into your project using

```
dotnet add package CommonPasswordValidator
```

You can add the password validator to you ASP.NET Core Identity configuration using one of the `IdentityBuilder` extension methods: 

```csharp
builder.AddTop100PasswordValidator<ApplicationUser>(); // top 100
builder.AddTop500PasswordValidator<ApplicationUser>(); // top 500
builder.AddTop1000PasswordValidator<ApplicationUser>(); // top 1,000
builder.AddTop10000PasswordValidator<ApplicationUser>(); // top 10,000
builder.AddTop100000PasswordValidator<ApplicationUser>(); // top 100,000
```

## Background 

This package is based [on an article by Jeff Attwood](https://blog.codinghorror.com/password-rules-are-bullshit/) about the rules they have decided on for [Discource](https://discourse.org/). 

Instead of requiring a multitude of character types, they demand a _minimum_ of 10 characters and at least 6 unque characters.

More importantly, they require that the password is not one of the most common passwords. 

This package provides a number of validators for the ASP.NET Core Identity system, that you can use in your ASP.NET Core 2.0 apps to check that the password entered is not on a list of the most common passwords. 

>*NOTE* This package is currently for ASP.NET Core Identity 2.0-preview-2, so requires .NET Core 2.0-preview2 is installed.

## Installing 

Install using the [CommonPasswordsValidator NuGet package](https://www.nuget.org/packages/CommonPasswordsValidator):

```
PM> Install-Package CommonPasswordsValidator
```

or

```
dotnet add package CommonPasswordValidator
```

## Usage 

When you install the package, it should be added to your `csproj`. Alternatively, you can add it directly by adding:

```xml
<PackageReference Include="NetEscapades.CommonPasswordValidator" Version="1.0.0" />
```

Extension methods exist for validating whether the password is in the top 

* 100 most common of the the 10 million password list
* 500 most common of the the 10 million password list
* 1,000 most common of the the 10 million password list
* 10,000 most common of the the 10 million password list
* 100,000 most common of the the 10 million password list

For example, to add the top 1000 password validator to a typical defulat ASP.NET Core project:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders()
        .AddTop1000PasswordValidator<ApplicationUser>(); // Add the custom validator

    services.AddTransient<IEmailSender, AuthMessageSender>();
    services.AddTransient<ISmsSender, AuthMessageSender>();

    services.AddMvc();
}
```

In adition, I recommend you update the length requirements, and the required number of unique characters too, e.g:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 10;
            options.Password.RequiredUniqueChars = 6;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders()
        .AddTop100000PasswordValidator<ApplicationUser>();

    services.AddTransient<IEmailSender, AuthMessageSender>();
    services.AddTransient<ISmsSender, AuthMessageSender>();

    services.AddMvc();
}
```

The package will automatically exclude any passwords that are less than the value specified in `IdentityBuilder.Password.RequiredLength` to reduce the number of passwords it needs to check against. 

> Tip: The most common passwords are short - if you increase the minimum `RequiredLength` to 10 characters, only 2,312 of the top 100,000 most common passwords will be valid!

## Additional Resources
* [Creating custom validators in ASP.NET Core](https://andrewlock.net/creating-custom-password-validators-for-asp-net-core-identity-2/)

* [Password Rules Are Bullshit](https://blog.codinghorror.com/password-rules-are-bullshit/)
* [Source passwords list](https://github.com/danielmiessler/SecLists/tree/master/Passwords)
* [Introduction to ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)
