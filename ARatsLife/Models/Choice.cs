using System.ComponentModel.DataAnnotations;

namespace ARatsLife.Models;
public class Choice
{
  public int ChoiceId { get; set; }
  [Required(ErrorMessage = "The choice needs a decription!")]
  public string Description { get; set; }
  public int PlotpointId { get; set; }
  public Plotpoint Plotpoint { get; set; }
}