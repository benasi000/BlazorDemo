namespace API.Controllers.DTO
{
    public class BaseCarDTO
    {
        public string CarBrand { get; set; }
        public string CarDescription { get; set; }
        public double CarPrice { get; set; }
        public bool Damage { get; set; } = false;
    }
}
