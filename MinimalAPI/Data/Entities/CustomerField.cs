namespace MinimalAPI.Data.Entities
{
    public class CustomerField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FieldType { get; set; } // TextBox or DropDown
    }
}
