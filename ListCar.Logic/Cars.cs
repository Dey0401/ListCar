using System.Xml.Linq;

namespace ListCar.Logic
{
    public class Cars
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }

        public Cars(string? brand, string? model, int year, string? color, decimal price)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
        }

        public override string ToString()
        {
            return $"The Car is brand : {Brand}, model {Model}, year {Year}, color {Color} and you price is ~${Price}";
        }


    }
}