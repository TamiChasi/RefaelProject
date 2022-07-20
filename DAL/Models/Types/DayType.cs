namespace Application.Models.Types
{
    public class DayType : Type
    {
        private static int counter = 0;
        public int TypeId { get; }
        public int TypeCode => 2;
        public string TypeName { get; set; }

        public DayType()
        {
            TypeId = ++counter;
            TypeName = "Day";
        }
    }
}
