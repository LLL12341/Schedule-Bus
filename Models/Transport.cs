using System.Collections.Generic;

namespace TransportWebSystem.Models
{
    public abstract class Transport
    {
        public string RouteNumber { get; set; }

        public List<Stop> Stops { get; set; } = new List<Stop>();

        public abstract string TransportType { get; }
    }

    public class Bus : Transport
    {
        public override string TransportType => "Автобус";
    }

    public class Trolleybus : Transport
    {
        public override string TransportType => "Тролейбус";
    }
}