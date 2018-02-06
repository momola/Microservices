using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

public class Proj
{


internal static async Task<List<Invoice>> ProcessRepositories()
{
    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    //client.DefaultRequestHeaders.Add("Transaction", "Transactions Microservice");

    var streamTask = client.GetStreamAsync("http://localhost:8080/api/Transaction");
    var serializer = new DataContractJsonSerializer(typeof(List<Invoice>));
    var invoices = serializer.ReadObject(await streamTask) as List<Invoice>;

    return invoices;
}
    
}
