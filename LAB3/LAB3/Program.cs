using System.Text.Json;

namespace Lab;

class Program
{
    static void Main()
    {
        ClientAPI client = ClientAPI.Instance();
        client.Call("/instruction/students.json",
            OnSuccessful: async response =>
            {
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<Student> students = JsonSerializer.Deserialize<List<Student>>(responseBody);
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine(students[i]);
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