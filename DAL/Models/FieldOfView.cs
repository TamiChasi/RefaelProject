using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class FieldOfView
    {
        private static int counter = 0;

        public int FieldOfViewId { get; }
        [Required]
        public decimal Engle { get; set; }
        [Required]
        [Range(1, 360)]
        public decimal Degrees{ get; set; }

        public FieldOfView()
        {
        }

        public FieldOfView(decimal engle, decimal degrees)
        {
            FieldOfViewId = ++counter;
            Engle = engle;
            Degrees = degrees;
        }
    }
}
