namespace Application.Models.Types
{
    public class DayType : Type
    {
        private static int counter = 0;
        public int TypeId { get; set; }
        public int TypeCode => 2;
        public string Name => "Day";

        public DayType()
        {
            TypeId = ++counter;
        }
    }
}
