using car.Controller;
using car.Services;
using car.views;

class Program
{
    static async Task Main(string[] args)
    {
        string baseUrl = "http://localhost:3000/";

        CarView view = new CarView();
        JsonServer jsonServer = new JsonServer(baseUrl);
        CarController controller = new CarController(view, jsonServer);

        await controller.RunAsync();
    }
}
