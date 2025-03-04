namespace BlazorDemo.Model
{
  public class CarDetails
  {
    public int Id { get; set; }
    public string CarBrand { get; set; }
    public string CarDescription { get; set; }
    public double CarPrice { get; set; }
    public bool Damage { get; set; } = false;
    public DateTime CreatedDate { get; set; }
    public DateTime? EditedDate { get; set; }
  }
}
