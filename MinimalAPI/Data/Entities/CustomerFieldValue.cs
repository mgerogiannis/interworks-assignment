namespace MinimalAPI.Data.Entities
{
    public class CustomerFieldValue
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; }
    }
}
