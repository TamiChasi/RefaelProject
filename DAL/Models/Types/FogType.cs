namespace Application.Models.Types
{
    public class FogType : Type
    {
        private static int counter = 0;
        public int TypeId { get; set; }
        public int TypeCode => 3;
        public string Name => "Fog";
        public FogType()
        {
            TypeId = ++counter;
        }
    }
}
