﻿namespace Lab;
using System.Text.Json;
public class ClientAPI : Singleton<ClientAPI>
{
    static readonly HttpClient client = new HttpClient();

    private const string BASE_URL = "http://radoslaw.idzikowski.staff.iiar.pwr.wroc.pl";
    
    public async Task Call<T>(string call, Action<T, HttpResponseMessage> OnSuccessful = null , Action OnFailure = null)
    {
        try
        {
            using HttpResponseMessage response = await client.GetAsync(BASE_URL +  call);
            string responseBody = await response.Content.ReadAsStringAsync();
            T t = JsonSerializer.Deserialize<T>(responseBody);
            OnSuccessful?.Invoke(t, response);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            OnFailure?.Invoke();
        }
    }
    
}