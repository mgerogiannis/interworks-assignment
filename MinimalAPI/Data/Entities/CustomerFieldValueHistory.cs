namespace MinimalAPI.Data.Entities
{
    public class CustomerFieldValueHistory
    {
        public int Id { get; set; }
        public int FieldValueId { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ChangeDate { get; set; }
    }
}
