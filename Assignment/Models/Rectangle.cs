using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Rectangle
    {
        [Required]
        public double Length { get;set; }
        [Required]
        public double Width { get;set; }

    }
}
