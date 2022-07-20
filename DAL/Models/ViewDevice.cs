using Application.Models.Types;

namespace Application.Models
{
    public class ViewDevice
    {
        private static int counter = 0;
        public int Id { get; }
        public Type Type { get; set; }
        public Range Range { get; set; }
        public FieldOfView FieldOfView { get; set; }

        public ViewDevice( Range range, Type type, FieldOfView fieldOfView)
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
