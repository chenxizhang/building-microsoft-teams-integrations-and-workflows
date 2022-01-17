// See https://aka.ms/new-console-template for more information
//https://login.microsoftonline.com/common/adminconsent?client_id=cfa98752-d098-4288-b13c-6282f807fc6c
using System.Text.Json;
using Microsoft.Identity.Client;

IConfidentialClientApplication app = ConfidentialClientApplicationBuilder
    .Create("bd596583-55df-4277-9a3d-79159f3dc59a")
    .WithClientSecret("oqw7Q~xM~KrRu2iWCdAG6GEVfgHpPh2v6M_4A")
    .WithAuthority(new Uri("https://login.microsoftonline.com/3a6831ab-6304-4c72-8d08-3afe544555dd"))
    .Build();

string[] scopes = new string[]{
    "api://cfa98752-d098-4288-b13c-6282f807fc6c/.default"
};


AuthenticationResult result = await app.AcquireTokenForClient(scopes).ExecuteAsync();

var client = new HttpClient();

var defaultHeaders = client.DefaultRequestHeaders;

if (defaultHeaders.Accept == null || !defaultHeaders.Accept.Any(x => x.MediaType == "application/json"))
{
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
}


client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", result.AccessToken);

HttpResponseMessage response = await client.GetAsync("https://localhost:5050/api/Products");

if (response.IsSuccessStatusCode)
{
    string json = await response.Content.ReadAsStringAsync();
    Console.WriteLine(json);
}
else
{
    Console.WriteLine(response.StatusCode);
}


