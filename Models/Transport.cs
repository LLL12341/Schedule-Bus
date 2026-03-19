using System.Collections.Generic;

namespace TransportWebSystem.Models
{
    // Базовий абстрактний клас (виконує принцип відкритості/закритості - OCP з SOLID)
    public abstract class Transport
    {
        // Номер маршруту (наприклад, "5А", "12")
        public string RouteNumber { get; set; }

        // ОСЬ НАШ СПИСОК ЗУПИНОК:
        public List<Stop> Stops { get; set; } = new List<Stop>();

        // Абстрактна властивість, яку обов'язково мають реалізувати всі спадкоємці
        public abstract string TransportType { get; }
    }

    // Конкретний клас: Автобус
    public class Bus : Transport
    {
        public override string TransportType => "Автобус";
    }

    // Конкретний клас: Тролейбус
    public class Trolleybus : Transport
    {
        public override string TransportType => "Тролейбус";
    }
}