using car.models;

namespace car.views
{
    public class CarView
{
    public Car GetCarInput()
    {
        Console.Write("Enter car make: ");
        string make = Console.ReadLine();

        Console.Write("Enter car model: ");
        string model = Console.ReadLine();

        Console.Write("Enter car color: ");
        string color = Console.ReadLine();

        Console.Write("Enter car year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        return new Car { Make = make, Model = model, Color = color, Year = year };
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}

}