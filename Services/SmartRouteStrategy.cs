using System.Collections.Generic;
using System.Linq;
using TransportWebSystem.Models;

namespace TransportWebSystem.Services
{
    public class SmartRouteStrategy : IRouteSearchStrategy
    {
        public List<Transport>? FindRoute(Stop start, Stop end, List<Transport> routes)
        {
            // 1. Спочатку перевіряємо, чи є прямі маршрути
            var directRoutes = routes.Where(r => 
                r.Stops.Any(s => s.Id == start.Id) && 
                r.Stops.Any(s => s.Id == end.Id)).ToList();

            if (directRoutes.Count > 0)
            {
                return directRoutes; // Якщо є прямі, повертаємо їх
            }

            // 2. Якщо прямих немає, шукаємо пересадку (1 спільна зупинка)
            var startRoutes = routes.Where(r => r.Stops.Any(s => s.Id == start.Id)).ToList();
            var endRoutes = routes.Where(r => r.Stops.Any(s => s.Id == end.Id)).ToList();

            foreach (var firstTransport in startRoutes)
            {
                foreach (var secondTransport in endRoutes)
                {
                    // Шукаємо спільну зупинку (де маршрути перетинаються)
                    var commonStop = firstTransport.Stops.FirstOrDefault(s1 => 
                        secondTransport.Stops.Any(s2 => s2.Id == s1.Id));

                    if (commonStop != null)
                    {
                        // Знайшли! Повертаємо 2 транспорти: на якому виїхати і на який пересісти
                        return new List<Transport> { firstTransport, secondTransport };
                    }
                }
            }

            return null; // Якщо навіть з пересадкою неможливо доїхати
        }
    }
}