using Application.Models.Types;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class ViewDevice
    {
        private static int counter = 0;
        public int Id { get; }
        [Required]
        public Range Range { get; set; }
        [Required]

        public Type Type { get; set; }
        [Required]
        public FieldOfView FieldOfView { get; set; }

        public ViewDevice(Range range, Type type, FieldOfView fieldOfView)
        {
            Id = ++counter;
            Type = type;
            Range = range;
            FieldOfView = fieldOfView;
        }
        public ViewDevice()
        {

        }
    }
}
