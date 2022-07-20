namespace Application.Models.Types
{
    public class FogType : Type
    {
        private static int counter = 0;
        public int TypeId { get; }
        public int TypeCode => 3;
        public string TypeName { get; set ; }

        public FogType()
        {
            TypeId = ++counter;
            TypeName = "Fog";
        }
    }
}
