using System.Collections.Generic;
using System.Linq;
using TransportWebSystem.Models;

namespace TransportWebSystem.Services
{
    public class DirectRouteStrategy : IRouteSearchStrategy
    {
        public List<Transport>? FindRoute(Stop start, Stop end, List<Transport> routes)
        {
            // Використовуємо .Where, щоб знайти ВСІ маршрути, а не тільки перший
            var directRoutes = routes.Where(r => 
                r.Stops.Any(s => s.Id == start.Id) && 
                r.Stops.Any(s => s.Id == end.Id)).ToList();

            // Якщо знайшли хоча б один маршрут, повертаємо весь список
            if (directRoutes.Count > 0)
            {
                return directRoutes;
            }

            return null; // Жодного маршруту не знайдено
        }
    }
}