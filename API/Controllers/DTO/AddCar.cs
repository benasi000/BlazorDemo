namespace API.Controllers.DTO
{
    public class AddCar
    {
        public string CarBrand { get; set; }
        public string CarDescription { get; set; }
        public double CarPrice { get; set; }
        public bool Damage { get; set; } = false;
    }
}
