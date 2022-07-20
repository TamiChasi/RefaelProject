namespace Application.Models
{
    public interface Type
    {
        public int TypeId { get; }
        public int TypeCode { get; }
        string TypeName { get; set; }
    }
}
