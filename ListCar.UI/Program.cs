using ListCar.Logic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

Console.WriteLine("Hello, World!");
var cars = new DoubleList<Cars>();
FillListCars();
void FillListCars()
{
    cars.Add(new Cars("Renault", "Camry", 1980, "Azul", 7000000));
    cars.Add(new Cars("Renault", "Camry", 2001, "Verde", 80000000));
    cars.Add(new Cars("Renault", "Camry", 2015, "Amarillo", 230000000));
    cars.Add(new Cars("BMW", "X5", 2021, "Rosado", 7000000));
    cars.Add(new Cars("BMW", "X5", 1980, "Azul", 80000000));
    cars.Add(new Cars("BMW", "X5", 2001, "Verde", 230000000));
    cars.Add(new Cars("Audi", "Q7 ", 2015, "Amarillo", 7000000));
    cars.Add(new Cars("Audi", "Q7 ", 2021, "Rosado", 80000000));
    cars.Add(new Cars("Audi", "Q7 ", 1980, "Azul", 230000000));
    cars.Add(new Cars("Ford", "Mustang", 2001, "Verde", 7000000));
    cars.Add(new Cars("Ford", "Mustang", 2015, "Amarillo", 80000000));
    cars.Add(new Cars("Ford", "Mustang", 2021, "Rosado", 230000000));
}

int option = 0;

do
{
    option = Menu();
    switch (option)
    {
        case 1: GetCarsForBrand(); break;
        case 2: GetCarsRangeOfYears(); break;
        case 3: GetCarsRangeOfPrice(); break;
        case 4: GetCarsWithSpecifications(); break;
        case 5: GetCarsMinMaxPrice(); break;

        default: break;
    }
}
while (option != 0);

void GetCarsForBrand()
{
    Console.Write("Enter the brand you want to filter: ");
    var brand = Console.ReadLine();
    cars.GetBrand(brand!, cars);
    Console.WriteLine($"You result is: \n{cars.GetBrand(brand!, cars)}");
}

void GetCarsRangeOfYears()
{
    Console.Write("Enter the min the year: ");
    int min = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the max the year: ");
    int max = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"You result is: {cars.GetRangeYears(min, max)}");

}

void GetCarsRangeOfPrice()
{
    Console.Write("Enter the min the price: ");
    Decimal min = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Enter the max the price: ");
    Decimal max = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine($"You result is: {cars.GetRangePrice(min, max)}");
}

void GetCarsWithSpecifications()
{
    Console.Write("Enter the brand: ");
    String brand = Convert.ToString(Console.ReadLine())!;
    Console.Write("Enter the model: ");
    var model = Convert.ToString(Console.ReadLine());
    Console.Write("Enter the year: ");
    var year = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter the color: ");
    var color = Convert.ToString(Console.ReadLine());
    Console.Write("Enter the price: ");
    Decimal price = Convert.ToDecimal(Console.ReadLine());
   

    
    Console.WriteLine($"You result is: {cars.GetCarsWithParam(brand, model, year, color, price)}");
}

void GetCarsMinMaxPrice()
{
    throw new NotImplementedException();
}

int Menu()
{
    Console.WriteLine("1. Returns the cars of a brand \n" +
                      "2. Returns cars from the range of years \n" +
                      "3. Returns cars from the range of price \n" +
                      "4. Returns the cars depending on the following criteria \n" +
                      "5. Returns the car with the lowest price and the car with the highest \n" +
                      "0. Exit");
    Console.WriteLine("Enter your option: ");
    var option = Console.ReadLine();

    return Convert.ToInt32(option);
}
