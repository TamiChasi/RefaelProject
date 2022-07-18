namespace Application.Models
{
    public class ViewDevice
    {
        private static int counter = 0;
        public int Id { get; set; }
        public Type Type { get; set; }
        public Range Rang { get; set; }
        public FieldOfView FieldOfView { get; set; }

        public ViewDevice(Type type, Range rang, FieldOfView fieldOfView)
        {
            Id = ++counter;
            Type = type;
            Rang = rang;
            FieldOfView = fieldOfView;
        }
        public ViewDevice()
        {

        }
    }
}
