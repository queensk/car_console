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
                _view.DisplayMessage("1. Create Car");
                _view.DisplayMessage("2. Read Car");
                _view.DisplayMessage("3. Update Car");
                _view.DisplayMessage("4. Delete Car");
                _view.DisplayMessage("5. Exit");
                _view.DisplayMessage("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        await CreateCarAsync();
                        break;
                    case 2:
                        await ReadCarAsync();
                        break;
                    case 3:
                        await UpdateCarAsync();
                        break;
                    case 4:
                        await DeleteCarAsync();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        _view.DisplayMessage("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private async Task CreateCarAsync()
        {
            Car car = _view.GetCarInput();

            if (await _jsonServer.CreateCarAsync(car))
            {
                _view.DisplayMessage("Car created successfully.");
            }
            else
            {
                _view.DisplayMessage("Failed to create car.");
            }
        }

        private async Task ReadCarAsync()
        {
            _view.DisplayMessage("Enter car ID: ");
            string id = Console.ReadLine();

            Car car = await _jsonServer.GetCarAsync(id);

            if (car != null)
            {
                _view.DisplayMessage($"Car Details:\nMake: {car.Make}\nModel: {car.Model}\nColor: {car.Color}\nYear: {car.Year}");
            }
            else
            {
                _view.DisplayMessage("Car not found.");
            }
        }

        private async Task UpdateCarAsync()
        {
            _view.DisplayMessage("Enter car ID: ");
            string id = Console.ReadLine();

            Car car = await _jsonServer.GetCarAsync(id);

            if (car != null)
            {
                Car updatedCar = _view.GetCarInput();
                if (await _jsonServer.UpdateCarAsync(id, updatedCar))
                {
                    _view.DisplayMessage("Car updated successfully.");
                }
                else
                {
                    _view.DisplayMessage("Failed to update car.");
                }
            }
            else
            {
                _view.DisplayMessage("Car not found.");
            }
        }

        private async Task DeleteCarAsync()
        {
            _view.DisplayMessage("Enter car ID: ");
            string id = Console.ReadLine();

            if (await _jsonServer.DeleteCarAsync(id))
            {
                _view.DisplayMessage("Car deleted successfully.");
            }
            else
            {
                _view.DisplayMessage("Failed to delete car.");
            }
        }
    }
}