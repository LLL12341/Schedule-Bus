namespace TransportWebSystem.Models
{
    public class Stop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // Властивість для мікрорайону (для сортування на головній)
        public string District { get; set; } 
    }
}