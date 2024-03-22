using System.Text.Json;

namespace Lab;

class Program
{
    static void Main()
    {
        ClientAPI client = ClientAPI.Instance;
        client.Call<List<Student>>("/instruction/students.json",
            OnSuccessful: async (body, response) =>
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Student> students = body;
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