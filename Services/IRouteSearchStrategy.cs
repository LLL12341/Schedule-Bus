using TransportWebSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace TransportWebSystem.Services;

public interface IRouteSearchStrategy
{
    // Тепер повертає список транспорту
    List<Transport>? FindRoute(Stop start, Stop end, List<Transport> routes);
}

// Нова стратегія, яка шукає прямий маршрут АБО маршрут з 1 пересадкою
public class SmartTransferStrategy : IRouteSearchStrategy
{
    public List<Transport>? FindRoute(Stop start, Stop end, List<Transport> routes)
    {
        // 1. ШУКАЄМО ПРЯМИЙ МАРШРУТ (Виправлено зворотний пошук!)
        // Метод Any() перевіряє просто наявність зупинки, тому порядок (туди чи назад) більше не має значення
        var directRoute = routes.FirstOrDefault(r => 
            r.Stops.Any(s => s.Id == start.Id) && 
            r.Stops.Any(s => s.Id == end.Id));

        if (directRoute != null)
        {
            return new List<Transport> { directRoute }; // Повертаємо 1 прямий транспорт
        }

        // 2. ЯКЩО ПРЯМОГО НЕМАЄ - ШУКАЄМО ПЕРЕСАДКУ
        var routesFromStart = routes.Where(r => r.Stops.Any(s => s.Id == start.Id)).ToList();
        var routesToEnd = routes.Where(r => r.Stops.Any(s => s.Id == end.Id)).ToList();

        foreach (var firstLeg in routesFromStart)
        {
            foreach (var secondLeg in routesToEnd)
            {
                // Перевіряємо, чи є у цих двох маршрутів спільна зупинка для пересадки
                var commonStops = firstLeg.Stops.Where(s1 => secondLeg.Stops.Any(s2 => s2.Id == s1.Id)).ToList();

                if (commonStops.Any())
                {
                    // Знайшли пересадку! Повертаємо обидва маршрути
                    return new List<Transport> { firstLeg, secondLeg };
                }
            }
        }

        return null; // Якщо взагалі нічого не знайдено
    }
}