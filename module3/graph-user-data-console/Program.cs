using System;
using System.Collections.Generic;
using System.Security;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using Microsoft.Extensions.Configuration;
using Helpers;

IConfigurationRoot? LoadAppSettings()
{
    try
    {
        var config = new ConfigurationBuilder()
                          .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", false, true)
                          .Build();

        if (string.IsNullOrEmpty(config["applicationId"]) ||
            string.IsNullOrEmpty(config["tenantId"]))
        {
            return null;
        }

        return config;
    }
    catch (System.IO.FileNotFoundException)
    {
        return null;
    }
}

IAuthenticationProvider CreateAuthorizationProvider(IConfigurationRoot config, string userName, SecureString userPassword)
{
    var clientId = config["applicationId"];
    var authority = $"https://login.microsoftonline.com/{config["tenantId"]}/v2.0";

    List<string> scopes = new List<string>();
    scopes.Add("User.Read");
    scopes.Add("User.Read.All");

    var cca = PublicClientApplicationBuilder.Create(clientId)
                                            .WithAuthority(authority)
                                            .Build();
    return MsalAuthenticationProvider.GetInstance(cca, scopes.ToArray(), userName, userPassword);
}

GraphServiceClient GetAuthenticatedGraphClient(IConfigurationRoot config, string userName, SecureString userPassword)
{
    var authenticationProvider = CreateAuthorizationProvider(config, userName, userPassword);
    var graphClient = new GraphServiceClient(authenticationProvider);
    return graphClient;
}

SecureString ReadPassword()
{
    Console.WriteLine("Enter your password");
    SecureString password = new SecureString();
    while (true)
    {
        ConsoleKeyInfo c = Console.ReadKey(true);
        if (c.Key == ConsoleKey.Enter)
        {
            break;
        }
        password.AppendChar(c.KeyChar);
        Console.Write("*");
    }
    Console.WriteLine();
    return password;
}

string ReadUsername()
{
    string? username;
    Console.WriteLine("Enter your username");
    username = Console.ReadLine();
    return username ?? "";
}

var config = LoadAppSettings();
if (config == null)
{
    Console.WriteLine("Invalid appsettings.json file.");
    return;
}


var userName = ReadUsername();
var userPassword = ReadPassword();

var client = GetAuthenticatedGraphClient(config, userName, userPassword);

// request 1 - all users
var requestAllUsers = client.Users.Request();

var results = requestAllUsers.GetAsync().Result;
foreach (var user in results)
{
    Console.WriteLine(user.Id + ": " + user.DisplayName + " <" + user.Mail + ">");
}

Console.WriteLine("\nGraph Request:");
Console.WriteLine(requestAllUsers.GetHttpRequestMessage().RequestUri);



// request 2 - current user
var requestMeUser = client.Me.Request();

var resultMe = requestMeUser.GetAsync().Result;
Console.WriteLine(resultMe.Id + ": " + resultMe.DisplayName + " <" + resultMe.Mail + ">");

Console.WriteLine("\nGraph Request:");
Console.WriteLine(requestMeUser.GetHttpRequestMessage().RequestUri);


// request 3 - specific user
var requestSpecificUser = client.Users["548afd0e-2ab7-4d78-aa7c-e34dfcb05287"].Request();
var resultOtherUser = requestSpecificUser.GetAsync().Result;
Console.WriteLine(resultOtherUser.Id + ": " + resultOtherUser.DisplayName + " <" + resultOtherUser.Mail + ">");

Console.WriteLine("\nGraph Request:");
Console.WriteLine(requestSpecificUser.GetHttpRequestMessage().RequestUri);


