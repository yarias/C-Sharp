namespace CSharpIntermidiate.UnitTest;
// Project -> Add -> Reference: To add source code to test

public class OrderProcessorTests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void Procees_OrdrIsAlreadyShiooed_ThrowsAnException()
    {
        var orderProcessor = new OrderProcessor(new FakeShippingCalculator());
        var order = new Order { Shipment = new Shipment() }; // {}: initialization of class attributes
        //orderProcessor.Process(order);
        Assert.Throws<InvalidOperationException>(() => orderProcessor.Process(order));
    }

    [Test]
    public void Process_OrderIsNotShipped_ShouldSetTheShipmentPropertyOfTheOrder()
    {
        var orderProcessor = new OrderProcessor(new FakeShippingCalculator());
        var order = new Order();
        orderProcessor.Process(order);
        Assert.IsTrue(order.IsShipped);
        Assert.AreEqual(1, order.Shipment.Cost);
        Assert.AreEqual(DateTime.Today.AddDays(1), order.Shipment.ShippingDate);
    }
}

public class FakeShippingCalculator : IShippingCalculator
{
    public float CalculateShipping(Order order)
    {
        return 1;
    }
}