namespace CarLease.Feature.Cars.Models
{
    public interface ICarModel
    {
        string Image { get; set; }
        string ShortDescription { get; set; }
        string Title { get; set; }
        string Type { get; set; }
    }
}