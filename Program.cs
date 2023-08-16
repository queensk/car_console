using car.Controller;
using car.models;
using car.Services;
using car.views;

class Program
{
    static async Task Main(string[] args)
    {
        string baseUrl = "http://your-json-server-url/";
        string apiKey = "your-api-key";

        CarView view = new CarView();
        JsonServer jsonServer = new JsonServer(baseUrl, apiKey);
        CarController controller = new CarController(view, jsonServer);

        await controller.RunAsync();
    }
}
