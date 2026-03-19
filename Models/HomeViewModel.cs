using System.Collections.Generic;

namespace TransportWebSystem.Models
{
    public class HomeViewModel
    {
        public List<Stop>? Stops { get; set; } = new();
        public List<Transport>? Routes { get; set; } = new();
        
        public int? StartStopId { get; set; }
        public int? EndStopId { get; set; }
        
        // БУЛО: public Transport? SearchResult { get; set; }
        // СТАЛО:
        public List<Transport>? SearchResult { get; set; } 
    }
}