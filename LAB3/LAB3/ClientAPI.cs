namespace Lab;

public class ClientAPI
{
    private static ClientAPI instance;
    static readonly HttpClient client = new HttpClient();

    private const string BASE_URL = "http://radoslaw.idzikowski.staff.iiar.pwr.wroc.pl";

    public static ClientAPI Instance()
    {
        if (instance == null)
        {
            instance = new ClientAPI();
        }
        return instance;
    }
    
    public async Task Call(string call, Action<HttpResponseMessage> OnSuccessful = null , Action OnFailure = null)
    {
        try
        {
            using HttpResponseMessage response = await client.GetAsync(BASE_URL +  call);
            OnSuccessful?.Invoke(response);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
            OnFailure?.Invoke();
        }
    }
    
}