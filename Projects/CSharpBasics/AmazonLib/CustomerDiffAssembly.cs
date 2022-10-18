namespace AmazonLib;

public class CustmerDiffAsembly
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Promote()
    {
        var calculator = new RateCalculator(); //it's not recommended as we're creating coupling
        var rating = calculator.Calculate(this);


        Console.WriteLine("Promote logic changed.");
    }
}

