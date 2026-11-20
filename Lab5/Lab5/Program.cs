public class Product
{
    private double price;
    public string Code {  get; set; }
    public string Name { get; set; }
    public int Stock { get; private set; }

    public double Price
    {
        get { return price; }
        set
        {
            if (value > 0)
            {
                price = value;
            }

            else
            {
                Console.WriteLine($"Invalid price {value}");
                price = 1.0;
            }   
        }
    }

    public Product(string code, string name, int price, int stock)
    {
        Code = code;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void Info()
    {
        Console.WriteLine($"[{Code}] {Name} - {price}$ ({Stock} Stock)");
    }

    public void ReStock(int amount)
    {
        Stock += amount;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product[] products =
        {
            new Product("P101","Mouse",30 , 15),
            new Product("P102","Keyboard",20, 5),
            new Product("P103","USB Cable",60 , 3),
            new Product("P104","Monitor",10, 0)
        };

        Console.WriteLine("---------- Urunler ---------");
        
        foreach (var product in products)
        {
            product.Info();
        }
        products[0].ReStock(5);
        products[2].ReStock(5);
        Console.WriteLine("\n--- Re-Stocked Devices ---");
        products[0].Info();
        products[2].Info();

        double maxPrice = products.Max(p => p.Price);
        double minPrice = products.Min(p => p.Price);
        double avg = products.Average(p => p.Price);

        Console.WriteLine($"\nMaximum Price : {maxPrice:F2}");
        Console.WriteLine($"Minimum Price : {minPrice:F2}");
        Console.WriteLine($"Average Price : {avg:F2}");

        Console.WriteLine("-- Products which are expensive than 50 --");
        foreach (Product expensive in products)
        {
            if (expensive.Price > 50)
            {
                expensive.Info();
            }
        }

        Console.WriteLine("\n---Sorted Prices Low to High ---");
        var sorted = products
            .Select(p => p.Price)
            .OrderBy(price => price);
        foreach (double price in sorted)
        {
            Console.WriteLine($"{price:F2}");
        }

        double goalPrice = 60;
        int index = Array.BinarySearch(sorted.ToArray(), goalPrice);
        Console.WriteLine("--Search--");
        if (index >= 0) Console.WriteLine($"{goalPrice}$ device is at {index}. index");
        else Console.WriteLine($"There is no device with {goalPrice}$");
    }

}