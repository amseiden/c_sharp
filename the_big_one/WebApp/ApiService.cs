namespace WebApp;

using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiService 
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetFromWebApi()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/controller/action");

            response.EnsureSuccessStatusCode(); // Ensure a successful response

            return await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            return ex.Message; // Handle any exceptions
        }
    }
}
