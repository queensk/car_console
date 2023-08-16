using car.models;
using car.Services;
using car.views;
namespace car.Controller
{
    public class CarController
{
    private readonly CarView _view;
    private readonly JsonServer _jsonServer;

    public CarController(CarView view, JsonServer jsonServer)
    {
        _view = view;
        _jsonServer = jsonServer;
    }

    public async Task RunAsync()
    {
        bool running = true;

        while (running)
        {
            _view.DisplayMessage("1. Create Car and Send to Server");
            _view.DisplayMessage("2. Exit");
            _view.DisplayMessage("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    await CreateAndSendCarAsync();
                    break;
                case 2:
                    running = false;
                    break;
                default:
                    _view.DisplayMessage("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private async Task CreateAndSendCarAsync()
    {
        Car car = _view.GetCarInput();

        if (await _jsonServer.SendCarToServerAsync(car))
        {
            _view.DisplayMessage("Car sent to server successfully.");
        }
        else
        {
            _view.DisplayMessage("Failed to send car to server.");
        }
    }
}

}