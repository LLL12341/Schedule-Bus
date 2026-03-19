// Файл: Models/TransportFactory.cs
namespace TransportWebSystem.Models
{
    // Патерн Factory Method (Фабричний метод) - 1 з 3 необхідних патернів
    public abstract class TransportFactory
    {
        public abstract Transport CreateTransport(string routeNumber);
    }

    public class BusFactory : TransportFactory
    {
        public override Transport CreateTransport(string routeNumber)
        {
            return new Bus { RouteNumber = routeNumber };
        }
    }


    public class TrolleybusFactory : TransportFactory
    {
        public override Transport CreateTransport(string routeNumber)
        {
            return new Trolleybus { RouteNumber = routeNumber };
        }
    }
}