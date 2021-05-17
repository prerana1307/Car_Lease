namespace CarLease.Feature.Cars.Models
{
    public class CarModel : ICarModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string Type { get; set; }
    }
}