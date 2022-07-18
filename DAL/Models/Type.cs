namespace Application.Models
{
    public interface Type
    {
        public int TypeId { get; set; }
        public int TypeCode { get; }
        string Name { get; }
    }
}
