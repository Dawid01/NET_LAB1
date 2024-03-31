using System.Text.Json;

namespace Lab;

class Program
{
    static void Main()
    {
        ClientAPI client = ClientAPI.Instance;
        
        client.Call<List<Game>>("/games",
            OnSuccessful: async (body, response) =>
            {
                if (response.IsSuccessStatusCode)
                {
                    for (int i = 0; i < body.Count; i++)
                    {
                        Console.WriteLine(body[i]);
                    }
                }
                else
                {
                    Console.WriteLine("RESPONSE CODE: " + response.StatusCode);
                }
            },
            OnFailure: () =>
            {
                Console.WriteLine("Conection failure");
            }).Wait();
    }
    
}