using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondHandCarDemoRepo.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Brand")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter the Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Please enter the Kilometer")]
        public long Kilometer { get; set; }
        [Required(ErrorMessage = "Please enter the price")]
        public long Price { get; set; }
    }
}
