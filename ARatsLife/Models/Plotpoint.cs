using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ARatsLife.Models;
  public class Plotpoint
  {
    public int PlotpointId { get; set; }
    [Required(ErrorMessage = "The plotpoint needs a title!")]
    public string Title { get; set; }
    [Required(ErrorMessage = "The plotpoint needs a description!")]
    public string Description { get; set; }
    public List<Choice> Choices { get; set; }
  }