namespace OrderPizzaEncapsulatePriciple;

class Program
{
    static void Main(string[] args)
    {
        Pizza pizza = Pizza.Order(PizzaConstants.Vegetable);
        System.Console.WriteLine(pizza);
        Console.ReadKey();
    }
}

class Pizza
{
    public virtual string Title => $"{nameof(Pizza)}";
    public virtual decimal Price => 10m;
    private static Pizza Create(string type)
    {
        Pizza pizza;
        if (type.Equals("Cheese")) return new Cheese();
        else if (type.Equals("Chicken")) return new Chicken();
        else return new Vegetables();
    }
    public static Pizza Order(string type)
    {
        Pizza pizza = Create(type);

        Prepare();
        Cook();
        Cut();
        return pizza;
    }
    public static void Prepare()
    {
        System.Console.WriteLine("Preparing...");
        Thread.Sleep(500);
        System.Console.WriteLine("Complete...");
    }
    public static void Cook()
    {
        System.Console.WriteLine("Cooking...");
        Thread.Sleep(500);
        System.Console.WriteLine("Complete...");
    }
    public static void Cut()
    {
        System.Console.WriteLine("Cutting...");
        Thread.Sleep(500);
        System.Console.WriteLine("Complete...");
    }
    public override string ToString()
    {
        return $"{Title} \n your price is  {Price.ToString("C")}";
    }
}

class Cheese : Pizza
{
    public override string Title => $"{base.Title} {nameof(Cheese)}";
    public override decimal Price => base.Price + 3m;
}

class Chicken : Pizza
{
    public override string Title => $"{base.Title} {nameof(Chicken)}";
    public override decimal Price => base.Price + 5m;
}

class Vegetables : Pizza
{
    public override string Title => $"{base.Title} {nameof(Vegetables)}";
    public override decimal Price => base.Price + 4m;
}

