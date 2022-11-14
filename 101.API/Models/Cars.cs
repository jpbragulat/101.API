using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace _101.API.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Age { get; set; }
        public string ColorAuto { get; set; }

    }
}
