using System.Collections.Generic;
using TransportWebSystem.Models;

namespace TransportWebSystem.Services
{
    public class RoutePlanner
    {
        private IRouteSearchStrategy _strategy;

        public RoutePlanner(IRouteSearchStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IRouteSearchStrategy strategy)
        {
            _strategy = strategy;
        }

        // ОСЬ ТУТ: тепер метод повертає List<Transport>?, а не string
        public List<Transport>? BuildRoute(Stop start, Stop end, List<Transport> routes)
        {
            return _strategy.FindRoute(start, end, routes);
        }
    }
}