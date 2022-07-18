namespace Application.Models.Types
{
    public class NightType : Type
    {
        private static int counter = 0;
        public int TypeId { get; set; }
        public int TypeCode => 1;

        public string Name => "Night";

        public NightType()
        {
            TypeId = ++counter;
        }
    }
}
