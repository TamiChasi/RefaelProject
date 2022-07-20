namespace Application.Models.Types
{
    public class NightType : Type
    {
        private static int counter = 0;
        public int TypeId { get;}
        public int TypeCode => 1;

        public string TypeName { get; set; }
        public NightType()
        {
            TypeId = ++counter;
            TypeName = "Night";
        }
    }
}
