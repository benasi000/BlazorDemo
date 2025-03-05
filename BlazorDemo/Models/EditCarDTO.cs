using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Model
{
  public class EditCarDTO : BaseCarDTO
  {
    public int? Id { get; set; }
  }
}
